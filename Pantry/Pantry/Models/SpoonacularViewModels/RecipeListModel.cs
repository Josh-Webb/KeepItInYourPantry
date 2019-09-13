using Pantry.Models.CategoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models.SpoonacularViewModels
{
    public class RecipeListModel
    {
        public virtual List<SpoonacularViewModels.RecipeForListModel> RecipeList { get; set; }
    }
}
