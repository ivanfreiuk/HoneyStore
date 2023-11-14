using HoneyStore.DataAccess.Identity;
using HoneyStore.DataAccess.Interfaces;

namespace HoneyStore.DataAccess.Entities
{
    public class Order : IIdentifier
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}