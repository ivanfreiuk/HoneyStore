﻿using AutoMapper;
using HoneyStore.BusinessLogic.Helpers;
using HoneyStore.BusinessLogic.Interfaces;
using HoneyStore.BusinessLogic.Models;
using HoneyStore.DataAccess.Entities;
using HoneyStore.DataAccess.UnitOfWork;

namespace HoneyStore.BusinessLogic.Services
{
    public class ProductService: BaseService, IProductService
    {
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapperFactory factory) : base(unitOfWork)
        {
            _mapper = factory.CreateMapper();
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var productEntity = await _uow.Products.GetAsync(id);

            var productDto = _mapper.Map<Product, ProductDto>(productEntity);

            return productDto;
        }

        public async Task<ICollection<ProductDto>> GetAllProductsAsync()
        {
            var productEntities = await _uow.Products.GetAllAsync();

            var productDtos = _mapper.Map<IEnumerable<Product>, ICollection<ProductDto>>(productEntities);

            return productDtos;
        }

        public async Task<ICollection<ProductDto>> GetProductsByCategoryId(int categoryId)
        {
            var productEntities = await _uow.Products.GetProductsByCategoryIdAsync(categoryId);

            var productDtos = _mapper.Map<IEnumerable<Product>, ICollection<ProductDto>>(productEntities);

            return productDtos;
        }

        public async Task<ICollection<ProductDto>> GetProductsByNameAsync(string name)
        {
            var productEntities = await _uow.Products.GetProductsByNameAsync(name);

            var productDtos = _mapper.Map<IEnumerable<Product>, ICollection<ProductDto>>(productEntities);

            return productDtos;
        }

        public async Task AddProductAsync(ProductDto product)
        {
            var productEntity = _mapper.Map<ProductDto, Product>(product);
            await _uow.Products.AddAsync(productEntity);
            await _uow.SaveAsync();

            var productFromDb = await _uow.Products.GetAsync(productEntity.Id);

            foreach (var category in product.Categories)
            {
                productFromDb.ProductCategories.Add(new ProductCategory
                {
                    ProductId = productFromDb.Id,
                    CategoryId = category.Id
                });
            }
            
            await _uow.Products.UpdateAsync(productFromDb);

            await _uow.SaveAsync();

            product.Id = productEntity.Id;
        }

        public async Task RemoveProductAsync(int id)
        {
            var product = await _uow.Products.GetAsync(id);

            await _uow.Products.RemoveAsync(product);

            await _uow.SaveAsync();
        }

        public async Task UpdateProductAsync(ProductDto product)
        {
            var productEntity = _mapper.Map<ProductDto, Product>(product);

            await _uow.Products.UpdateAsync(productEntity);

            await _uow.SaveAsync();
        }
    }
}