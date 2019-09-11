using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryId { get; set; }
        public int IngredientId { get; set; }
        public List<Category> Categories { get; set; }
        public virtual List<GroupedCategories> GroupedCategories { get; set; }
    }
}
