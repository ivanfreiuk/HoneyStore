using AutoMapper;
using HoneyStore.BusinessLogic.Models;
using HoneyStore.DataAccess.Entities;

namespace HoneyStore.BusinessLogic.Profiles
{
    public class CartItemProfile: Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItem, CartItemDto>().ReverseMap();
        }
    }
}
