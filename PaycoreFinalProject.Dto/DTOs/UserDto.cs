using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaycoreFinalProject.Base.Attribute;
using PaycoreFinalProject.Data.Model;

namespace PaycoreFinalProject.Dto.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte Status { get; set; }
        public DateTime LastActivity { get; set; }
        [RoleAttribute]
        public string Role { get; set; }
    }
}
