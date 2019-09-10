using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public string Title { get; set; }
        public string ServingSize { get; set; }
        public string CookTime { get; set; }
        public int SpoonacularId { get; set; }
        public string Image { get; set; }
        [Required]
        public int UserId { get; set;  }
        public ApplicationUser User { get; set; }
    }
}
