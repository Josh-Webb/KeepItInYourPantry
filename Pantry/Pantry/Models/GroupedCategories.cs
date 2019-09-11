using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models
{
    public class GroupedCategories
    {
        [Key]
        public int CatId { get; set; }
        public string CategoryName { get; set; }
        public int IngredientCount { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
