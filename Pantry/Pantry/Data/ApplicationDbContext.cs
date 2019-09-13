using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pantry.Models;
using Pantry.Models.CategoryViewModels;
using Pantry.Models.SpoonacularViewModels;

namespace Pantry.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Pantry.Models.Ingredient> Ingredient { get; set; }
        public DbSet<Pantry.Models.Category> Category { get; set; }
        public DbSet<Pantry.Models.Recipe> Recipe { get; set; }
        public DbSet<Pantry.Models.CategoryViewModels.CategoryViewModel> CategoryViewModel { get; set; }
        public DbSet<Pantry.Models.GroupedCategories> GroupedCategories { get; set; }
        public DbSet<Pantry.Models.SpoonacularViewModels.RecipeForListModel> RecipeForListModel { get; set; }
    }
}
