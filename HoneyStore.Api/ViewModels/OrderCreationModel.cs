using HoneyStore.DataAccess.Entities;

namespace HoneyStore.Api.ViewModels
{
    public class OrderCreationModel
    {
        public int UserId { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public OrderStatus Status { get; set; }
    }
}
