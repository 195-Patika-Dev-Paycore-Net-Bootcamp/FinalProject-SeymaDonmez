using System.ComponentModel.DataAnnotations;

namespace PaycoreFinalProject.Data.Model
{
    public class Category
    {
        [Required]
        public virtual int CategoryId { get; set; }
        [Required]
        public virtual string CategoryName { get; set; }
        public virtual string Description { get; set; }
    }
}
