using System.Drawing;
using HoneyStore.BusinessLogic.Interfaces;
using HoneyStore.BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HoneyStore.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            if (products == null)
            {
                return NoContent();
            }

            return Ok(products);
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var products = await _productService.GetProductsByNameAsync(name);

            if (products == null)
            {
                return NoContent();
            }

            return Ok(GetDummyProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);
            
            //product = new ProductDto
            //{
            //    Id = 1,
            //    Description = "Honey black",
            //    Name = "Honey test",
            //    Categories = new List<CategoryDto>
            //    {
            //        new CategoryDto
            //        {
            //            Id = 1,
            //            Name = "test category"
            //        }
            //    },
            //    Comments = new List<CommentDto>
            //    {
            //        new CommentDto
            //        {
            //            Id = 1,
            //            Content = "good honey!",
            //            CreatedOn = DateTime.Now,
            //            Headline = "remove headline",
            //            Mark = 3,
            //            ProductId = 1,
            //            UserId = 1,
            //            UserName = "Ivan Freiuk"
            //        }
            //    },
            //    CommentsEnabled = true,
            //    ImageUrl = null,
            //    Mark = 5,
            //    Price = 100,
            //    ProducerId = 1,
            //    Producer = new ProducerDto
            //    {
            //        Id = 1,
            //        Description = "Honey producer description",
            //        Name = "Honey producer",
            //    }

            //};

            if (product == null)
            {
                return NotFound();
            }


            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] IFormFile file, [FromForm] string jsonProduct)
        {
            try
            {
                if (file.Length <= 0)
                {
                    return BadRequest();
                }

                //var folderName = Path.Combine("Resources", "Images");
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim('"');
                //var fullPath = Path.Combine(pathToSave, fileName);

                //await using (var stream = new FileStream(fullPath, FileMode.Create))
                //{
                //    await file.CopyToAsync(stream);
                //}

                await using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var photo = new ProductPhotoDto
                {
                    FileName = file.FileName,
                    FileBytes = memoryStream.ToArray()
                };
                
                var product = JsonConvert.DeserializeObject<ProductDto>(jsonProduct);
                //product.ImageUrl = Path.Combine(folderName, fileName);

                await _productService.AddProductAsync(product, photo);

                return Ok(new
                {
                    product.Id,
                    ProductPhoto = photo
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var productFromDb = await _productService.GetProductAsync(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            await _productService.RemoveProductAsync(id);

            return Ok(product);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            var product = await _productService.GetProductsByCategoryId(id);

            if (product == null)
            {
                return NoContent();
            }

            return Ok(product);
        }

        private static IEnumerable<ProductDto> GetDummyProducts()
        {
            return new List<ProductDto>
            {
                new ProductDto
                {
                    Id = 1,
                    Description = "Honey black",
                    Name = "Honey test",
                    Categories = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = 1,
                            Name = "test category"
                        }
                    },
                    Comments = new List<CommentDto>
                    {
                        new CommentDto
                        {
                            Id = 1,
                            Content = "good honey!",
                            CreatedOn = DateTime.Now,
                            Headline = "remove headline",
                            Mark = 3,
                            ProductId = 1,
                            UserId = 1,
                            UserName = "Ivan Freiuk"
                        }
                    },
                    CommentsEnabled = true,
                    ImageUrl = null,
                    Mark = 5,
                    Price = 100,
                    ProducerId = 1,
                    Producer = new ProducerDto
                    {
                        Id = 1,
                        Description = "Honey producer description",
                        Name = "Honey producer",
                    }

                }
            };
        }
    }
}