using AutoMapper;
using HoneyStore.BusinessLogic.Models;
using HoneyStore.DataAccess.Entities;

namespace HoneyStore.BusinessLogic.Profiles
{
    public class CommentProfile: Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(c=>c.User.UserName));
            CreateMap<CommentDto, Comment>();
        }
    }
}