using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId
        { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$")]
        public string Title { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public Category Category { get; set; }

    }
}
