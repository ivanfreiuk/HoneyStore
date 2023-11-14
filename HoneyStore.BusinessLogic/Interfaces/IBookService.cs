using HoneyStore.BusinessLogic.Models;

namespace HoneyStore.BusinessLogic.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetProductAsync(int id);

        Task<ICollection<ProductDto>> GetAllProductsAsync();

        Task<ICollection<ProductDto>> GetProductsByNameAsync(string name);

        Task AddProductAsync(ProductDto product);

        Task RemoveProductAsync(int id);

        Task UpdateProductAsync(ProductDto product);

        Task<ICollection<ProductDto>> GetProductsByCategoryId(int categoryId);
    }
}