using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PaycoreFinalProject.Dto.DTOs
{
    public class ProductDto
    {
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public bool IsOfferable { get; set; } = false;
        public bool IsSold { get; set; } = false;
        public byte Status { get; set; } = 1;

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Price { get; set; }
        public  IList<OfferDto> Offers { get; set; }
        public  int UserId { get; set; }

    }
}
