using AutoMapper;
using HoneyStore.Api.ViewModels;
using HoneyStore.BusinessLogic.Models;

namespace HoneyStore.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreationModel, OrderDto>().ReverseMap();
        }
    }
}
