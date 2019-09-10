using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pantry.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser ()
        {

        }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

    }
}
