using System.Collections.Generic;
using System.Linq;
using CMPS411_FA2024_Stitched_Diamonds.Data;
using CMPS411_FA2024_Stitched_Diamonds.Entities;
using CMPS411_FA2024_Stitched_Diamonds.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMPS411_FA2024_Stitched_Diamonds.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<ProductGetDto>>> GetAllProducts()
        {
            var response = new Response<List<ProductGetDto>>();

            var products = _dataContext.Products
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .Include(p => p.Material)
                .Select(p => new ProductGetDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Details = p.Details,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    SubcategoryId = p.SubcategoryId,
                    MaterialId = p.MaterialId,
                    QuantityInStock = p.QuantityInStock
                })
                .ToList();

            response.Data = products;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<ProductGetDto>> GetProductById(int id)
        {
            var response = new Response<ProductGetDto>();

            var product = _dataContext.Products
                .Include(p => p.Category)
                .Include(p => p.Subcategory)
                .Include(p => p.Material)
                .Where(p => p.Id == id)
                .Select(p => new ProductGetDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Details = p.Details,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    SubcategoryId = p.SubcategoryId,
                    MaterialId = p.MaterialId,
                    QuantityInStock = p.QuantityInStock
                })
                .FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                response.AddError("id", "Product not found");
                return NotFound(response);
            }

            response.Data = product;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<ProductGetDto>> CreateProduct([FromBody] ProductCreateDto productDto)
        {
            var response = new Response<ProductGetDto>();

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                Details = productDto.Details,
                ImageUrl = productDto.ImageUrl,
                SubcategoryId = productDto.SubcategoryId,
                MaterialId = productDto.MaterialId,
                QuantityInStock = productDto.QuantityInStock
            };

            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();

            var createdProductDto = new ProductGetDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                SubcategoryId = product.SubcategoryId,
                MaterialId = product.MaterialId,
                QuantityInStock = product.QuantityInStock
            };

            response.Data = createdProductDto;
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<ProductGetDto>> UpdateProduct(int id, [FromBody] ProductUpdateDto productDto)
        {
            var response = new Response<ProductGetDto>();

            var product = _dataContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                response.AddError("id", "Product not found");
                return NotFound(response);
            }

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.ImageUrl = productDto.ImageUrl;
            product.CategoryId = productDto.CategoryId;
            product.SubcategoryId = productDto.SubcategoryId;
            product.MaterialId = productDto.MaterialId;
            product.QuantityInStock = productDto.QuantityInStock;
            _dataContext.SaveChanges();

            var updatedProductDto = new ProductGetDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                SubcategoryId = product.SubcategoryId,
                MaterialId = product.MaterialId,
                QuantityInStock = product.QuantityInStock
            };

            response.Data = updatedProductDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteProduct(int id)
        {
            var response = new Response<bool>();

            var product = _dataContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                response.AddError("id", "Product not found");
                return NotFound(response);
            }

            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
