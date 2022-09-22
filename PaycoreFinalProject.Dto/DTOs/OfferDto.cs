using PaycoreFinalProject.Data.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaycoreFinalProject.Dto.DTOs
{
    public class OfferDto
    {
        [Required]
        public virtual int UserId { get; set; }
        [Required]
        public virtual int OfferedPrice { get; set; }
        public virtual int? OfferPercentage { get; set; }
        public virtual OfferStatus OfferStatus { get; set; } = (OfferStatus)2;
        public virtual int ProductId { get; set; }
        public virtual ProductDto Product { get; set; }
        public virtual bool IsActive { get; set; } = true;
        public virtual DateTime OfferDate { get; set; } = DateTime.Now;
    }
}
