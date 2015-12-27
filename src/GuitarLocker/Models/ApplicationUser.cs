using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace GuitarLocker.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int UserId { get; set; }

        public virtual ApplicationUser RealUser { get; set; }

        [MaxLength(161)]
        public string Description { get; set; }
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z\d]+[-_a-zA-Z\d]{0,2}[a-zA-Z\d]+")]
        public string newUserName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]

        public string LastName { get; set; }
        public string Picture { get; set; }

        // ICollection, IEnumerable, IQueryable
        //public List<Jot> Jots { get; set; }
        //public List<JitterUser> Following { get; set; }
    }
}
