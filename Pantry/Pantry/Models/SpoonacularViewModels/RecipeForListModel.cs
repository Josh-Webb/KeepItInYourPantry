 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models.SpoonacularViewModels
{
    public class RecipeForListModel
    {
        public int Id { get; set; }
        public int SpoonacularId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public int UsedIngredientCount { get; set; }
        public int MissedIngredientCount { get; set; }

    }
}
