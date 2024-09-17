
using System.ComponentModel.DataAnnotations;
using WebAppHomeDecor.Domain.BaseEntities;

namespace WebAppHomeDecor.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; } = null!;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
