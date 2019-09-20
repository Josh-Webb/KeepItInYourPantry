using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pantry.Data;
using Pantry.Models;
using Pantry.Models.CategoryViewModels;

namespace Pantry.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IngredientsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            var user = await GetUserAsync();

            var applicationDbContext = _context.Ingredient
                .Where(p => p.UserId == user.Id)
                .Include(p => p.User)
                .Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/Create
        public IActionResult Create()
        {
            var categoryList = _context.Category.ToList();
            var categoryListSelectList = categoryList.Select(type => new SelectListItem
            {
                Text = type.Title,
                Value = type.CategoryId.ToString()
            }).ToList();
            categoryListSelectList.Insert(0, new SelectListItem
            {
                Text = "Choose Category...",
                Value = ""
            });
            
            ViewData["CategoryId"] = categoryListSelectList;
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,Title,CategoryId,Quantity,UserId")] Ingredient ingredient)
        {
            var user = await GetUserAsync();
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                ingredient.UserId = user.Id;
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Categories));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "Label", ingredient.CategoryId);
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", ingredient.UserId);
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,Title,CategoryId,Quantity,UserId")] Ingredient ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", ingredient.UserId);
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredient.FindAsync(id);
            _context.Ingredient.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Categories));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.IngredientId == id);
        }

        private Task<ApplicationUser> GetUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        //Ingredient Category View
        public async Task<IActionResult> Categories()
        {
            var loggedUser = await GetUserAsync();
            var model = new CategoryViewModel();

            model.GroupedCategories = await (
                from t in _context.Category
                join p in _context.Ingredient
                on t.CategoryId equals p.CategoryId
                where p.UserId == loggedUser.Id
                group new { t, p } by new { t.CategoryId, t.Title } into grouped
                select new GroupedCategories
                {
                    CatId = grouped.Key.CategoryId,
                    CategoryName = grouped.Key.Title,
                    IngredientCount = grouped.Select(x => x.p.IngredientId).Count(),
                    Ingredients = grouped.Select(x => x.p).Take(5)
                }).ToListAsync();
            return View(model);
        }
    }
}
