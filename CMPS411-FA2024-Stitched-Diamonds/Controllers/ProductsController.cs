using CMPS411_FA2024_Stitched_Diamonds.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMPS411_FA2024_Stitched_Diamonds.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 19.99m, ImageUrl = "/images/product1.jpg", Details = "Clothing top" },
        new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 29.99m, ImageUrl = "/images/product2.jpg", Details = "Jewelry Style" },
        new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 159.99m, ImageUrl = "/images/product3.jpg", Details = "Cardigan custom" },
        // Add more products here...
    };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}