namespace HoneyStore.BusinessLogic.Models
{
    public class WishDto
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
    }
}