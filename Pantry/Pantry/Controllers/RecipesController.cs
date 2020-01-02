using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pantry.Data;
using Pantry.Models;
using Pantry.Models.SpoonacularViewModels;

namespace Pantry.Controllers
{
    public class RecipesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly string _byIngredientsUrl = "https://api.spoonacular.com/recipes/findByIngredients?apiKey=";
        private readonly string _fullRecipeUrl = "https://api.spoonacular.com/recipes/";
        private readonly string key = "f98f348f39f1439b84a56d3abfda1a7e";


        public RecipesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var rec = await GetRecipesAsync();
            return View(rec);
           //return View(await _context.Recipe.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {

            }
            

            var recipe = await GetFullRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,Title,ServingSize,CookTime,SpoonacularId,Image,UserId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {

                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Title,ServingSize,CookTime,SpoonacularId,Image,UserId")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeId == id);
        }


        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        

        private async Task<IEnumerable<RecipeForListModel>> GetRecipesAsync()
        {
            var user = await GetUserAsync();
            var ingredientsList = String.Join(",+", _context.Ingredient
                .Where(p => p.UserId == user.Id)
                .Select(i => i.Title));
            //var key = _config["ApiKeys:Spoonacular"];
            var url = $"{_byIngredientsUrl}{key}&ingredients={ingredientsList}&ranking=2";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            //var model = new RecipeListModel();
            
            
            if (response.IsSuccessStatusCode)
            {
                //var model = new 
                
                var recipes = await response.Content.ReadAsAsync<IEnumerable<RecipeForListModel>>();
                return recipes;
            }
            else
            {
                return null;
            }
        }

        private async Task<RecipeDetailsView> GetFullRecipe(int? id)
        {
            //var key = _config["ApiKeys:Spoonacular"];
            var url = $"{_fullRecipeUrl}{id}/information?apiKey={key}";
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var instructions = await response.Content.ReadAsAsync<RecipeDetailsView>();
                return instructions;
            }
            else
            {
                return null;
            }

        }

        

        
    }
}
