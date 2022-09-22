using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaycoreFinalProject.Data.Model
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsOfferable { get; set; } = false;
        public virtual bool IsSold { get; set; } = false;
        public virtual byte Status { get; set; } 
        public virtual int CategoryId { get; set; }
        public virtual string Color { get; set; } 
        public virtual string Brand { get; set; }
        public virtual int Price { get; set; }
        public virtual IList<Offer> Offers { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
