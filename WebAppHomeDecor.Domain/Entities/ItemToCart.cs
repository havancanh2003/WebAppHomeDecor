
namespace WebAppHomeDecor.Domain.Entities
{
    public class ItemToCart
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int QuantityAddToCart { get; set; }
        public bool IsRemoveToCart { get; set; }
    }
}
