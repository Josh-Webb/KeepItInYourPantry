using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models.SpoonacularViewModels
{
    public class AnalyzedInstructions
    {
        public int Id { get; set; }

        public IList<StepsViewModel> Steps { get; set; }
    }
}
