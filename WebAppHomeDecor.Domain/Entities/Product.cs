using System.ComponentModel.DataAnnotations;
using WebAppHomeDecor.Domain.BaseEntities;

namespace WebAppHomeDecor.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string ProductName { get; set; } = null!;
        [Required]
        public string ProductDescription { get; set; } = null!;
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        [Range(5, int.MaxValue, ErrorMessage = "Quantity must be at least 10.")]
        public int Quanlity { get; set; }
        public string ImageKey { get; set; } = null!;
        [Required]
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
