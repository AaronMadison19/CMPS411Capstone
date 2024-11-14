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
    [Route("api/productVariants")]
    public class ProductVariantsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductVariantsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<ProductVariantGetDto>>> GetAllProductVariants()
        {
            var response = new Response<List<ProductVariantGetDto>>();

            var productVariants = _dataContext.ProductVariants
                .Include(p => p.Product)
                .Select(p => new ProductVariantGetDto
                {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    VariantName = p.VariantName,
                    VariantValue = p.VariantValue,
                    AdditionalPrice = p.AdditionalPrice,
                })
                .ToList();

            response.Data = productVariants;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<ProductVariantGetDto>> GetProductVariantById(int id)
        {
            var response = new Response<ProductVariantGetDto>();

            var productVariant = _dataContext.ProductVariants
                .Include(p => p.Product)
                .Where(p => p.Id == id)
                .Select(p => new ProductVariantGetDto
                {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    VariantName = p.VariantName,
                    VariantValue = p.VariantValue,
                    AdditionalPrice = p.AdditionalPrice,
                })
                .FirstOrDefault(productVariant => productVariant.Id == id);

            if (productVariant == null)
            {
                response.AddError("id", "ProductVariant not found");
                return NotFound(response);
            }

            response.Data = productVariant;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<ProductVariantGetDto>> CreateProductVariant([FromBody] ProductVariantCreateDto productVariantDto)
        {
            var response = new Response<ProductVariantGetDto>();

            var productVariant = new ProductVariant
            {
                ProductId = productVariantDto.ProductId,
                VariantName = productVariantDto.VariantName,
                VariantValue = productVariantDto.VariantValue,
                AdditionalPrice = productVariantDto.AdditionalPrice,
            };

            _dataContext.ProductVariants.Add(productVariant);
            _dataContext.SaveChanges();

            var createdProductVariantDto = new ProductVariantGetDto
            {
                Id = productVariant.Id,
                ProductId = productVariant.ProductId,
                VariantName = productVariant.VariantName,
                VariantValue = productVariant.VariantValue,
                AdditionalPrice = productVariant.AdditionalPrice,
            };

            response.Data = createdProductVariantDto;
            return CreatedAtAction(nameof(GetProductVariantById), new { id = productVariant.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<ProductVariantGetDto>> UpdateProductVariant(int id, [FromBody] ProductVariantUpdateDto productVariantDto)
        {
            var response = new Response<ProductVariantGetDto>();

            var productVariant = _dataContext.ProductVariants.FirstOrDefault(p => p.Id == id);

            if (productVariant == null)
            {
                response.AddError("id", "ProductVariant not found");
                return NotFound(response);
            }

            productVariant.VariantName = productVariantDto.VariantName;
            productVariant.VariantValue = productVariantDto.VariantValue;
            productVariant.AdditionalPrice = productVariantDto.AdditionalPrice;
            _dataContext.SaveChanges();

            var updatedProductVariantDto = new ProductVariantGetDto
            {
                Id = productVariant.Id,
                ProductId = productVariant.ProductId,
                VariantName = productVariant.VariantName,
                VariantValue = productVariant.VariantValue,
                AdditionalPrice = productVariant.AdditionalPrice,
            };

            response.Data = updatedProductVariantDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteProductVariant(int id)
        {
            var response = new Response<bool>();

            var productVariant = _dataContext.ProductVariants.FirstOrDefault(p => p.Id == id);

            if (productVariant == null)
            {
                response.AddError("id", "ProductVariant not found");
                return NotFound(response);
            }

            _dataContext.ProductVariants.Remove(productVariant);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
