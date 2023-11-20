using AutoMapper;
using HoneyStore.BusinessLogic.Profiles;
using HoneyStore.DataAccess.UnitOfWork;

namespace HoneyStore.BusinessLogic.Helpers
{
    public interface IMapperFactory
    {
        IMapper CreateMapper();
    }

    public class MapperFactory : IMapperFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        public MapperFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IMapper CreateMapper()
        {
           var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductPhotoProfile>();
                cfg.AddProfile<ProducerProfile>();
                cfg.AddProfile<CategoryProfile>();
                cfg.AddProfile<WishProfile>();
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<CartItemProfile>();
                cfg.AddProfile(new ProductProfile(_unitOfWork));
                cfg.AddProfile(new CommentProfile(_unitOfWork));
            });
            return new Mapper(config);
        }
    }
}
