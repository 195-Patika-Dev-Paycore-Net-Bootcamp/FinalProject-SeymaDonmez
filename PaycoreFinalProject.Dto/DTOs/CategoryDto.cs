using System.ComponentModel.DataAnnotations;

namespace PaycoreFinalProject.Dto.DTOs
{
    public class CategoryDto
    {
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
