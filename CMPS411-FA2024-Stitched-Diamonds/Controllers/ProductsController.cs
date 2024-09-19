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
        new Product { Id = "1", Name = "Product 1", Description = "Description 1", Price = 19.99m, ImageUrl = "/images/product1.jpg" },
        new Product { Id = "2", Name = "Product 2", Description = "Description 2", Price = 29.99m, ImageUrl = "/images/product2.jpg" },
        // Add more products here...
    };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(string id)
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
