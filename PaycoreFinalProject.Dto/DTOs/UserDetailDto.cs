using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaycoreFinalProject.Data.Model;

namespace PaycoreFinalProject.Dto.DTOs
{
    public class UserDetailDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8), MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public  byte Status { get; set; }
        public  DateTime LastActivity { get; set; }
        public  string Role { get; set; }
        public  IList<Offer> Offers { get; set; }
    }
}
