﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models.SpoonacularViewModels
{
    public class RecipeDetailsView
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        public int CookTime { get; set; }

        public int Servings { get; set; }

        public string Image { get; set; }
        public string ImageType { get; set; }

        public virtual ICollection<ExtendedIngredientsViewModel> ExtendedIngredients { get; set; }

        public virtual ICollection<AnalyzedInstruction> AnalyzedInstructions { get; set; }
    }
}
