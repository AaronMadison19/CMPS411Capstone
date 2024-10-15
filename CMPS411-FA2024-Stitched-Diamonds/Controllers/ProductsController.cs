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
        public ActionResult<Response<List<Product>>> GetAllProducts()
        {
            var response = new Response<List<Product>>();

            var products = _dataContext.Products.ToList();
            response.Data = products;

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Product>> GetProductById(int id)
        {
            var response = new Response<Product>();

            var product = _dataContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                response.AddError("id", "Product not found");
                return NotFound(response);
            }

            response.Data = product;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<Product>> CreateProduct([FromBody] Product product)
        {
            var response = new Response<Product>();

            // Optionally validate product data here
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();

            response.Data = product;
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Product>> UpdateProduct(int id, [FromBody] Product productUpdate)
        {
            var response = new Response<Product>();

            var product = _dataContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                response.AddError("id", "Product not found");
                return NotFound(response);
            }

            product.Name = productUpdate.Name;
            product.Description = productUpdate.Description;
            product.Price = productUpdate.Price;
            product.ImageUrl = productUpdate.ImageUrl;
            product.Details = productUpdate.Details;

            _dataContext.SaveChanges();

            response.Data = product;
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
