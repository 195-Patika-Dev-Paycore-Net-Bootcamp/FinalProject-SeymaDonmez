using System;
using System.ComponentModel.DataAnnotations;

namespace PaycoreFinalProject.Data.Model
{
    public class Offer 
    {
        [Required]
        public virtual int OfferId { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public virtual int OfferedPrice { get; set; }
        public virtual int? OfferPercentage { get; set; }
        public virtual OfferStatus OfferStatus { get; set; } = (OfferStatus)2;
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual bool IsActive { get; set; } = true;
        public virtual DateTime OfferDate { get; set; } = DateTime.Now;
    }
}
