﻿using HoneyStore.DataAccess.Entities;

namespace HoneyStore.BusinessLogic.Models
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<CartItemDto> CartItems { get; set; }
    }
}