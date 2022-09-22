using System.ComponentModel.DataAnnotations;
using PaycoreFinalProject.Base.Attribute;

namespace PaycoreFinalProject.Base.Token
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(125)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [PasswordAttribute]
        public string Password { get; set; }
    }
}
