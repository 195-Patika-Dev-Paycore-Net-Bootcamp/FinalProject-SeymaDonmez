using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycoreFinalProject.Data.Model
{
    public class User
    {
        [Required]
        public virtual int UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public virtual string Password { get; set; }
        public virtual byte Status { get; set; }
        public virtual DateTime LastActivity { get; set; }
        public virtual string Role { get; set; }
        public virtual IList<Offer> Offers { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
