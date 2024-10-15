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
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CategoriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<Categories>>> GetAllCategories()
        {
            var response = new Response<List<Categories>>();

            var categories = _dataContext.Categories.ToList();
            response.Data = categories;

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Categories>> GetCategoriesById(int id)
        {
            var response = new Response<Categories>();

            var categories = _dataContext.Categories.FirstOrDefault(p => p.Id == id);

            if (categories == null)
            {
                response.AddError("id", "Category not found");
                return NotFound(response);
            }

            response.Data = categories;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<Categories>> CreateCategories([FromBody] Categories categories)
        {
            var response = new Response<Categories>();

            // Optionally validate product data here
            _dataContext.Categories.Add(categories);
            _dataContext.SaveChanges();

            response.Data = categories;
            return CreatedAtAction(nameof(GetCategoriesById), new { id = categories.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Categories>> UpdateCategories(int id, [FromBody] Categories categoriesUpdate)
        {
            var response = new Response<Categories>();

            var categories = _dataContext.Categories.FirstOrDefault(p => p.Id == id);

            if (categories == null)
            {
                response.AddError("id", "Category not found");
                return NotFound(response);
            }

            categories.Type = categoriesUpdate.Type;
            categories.Category_Type = categoriesUpdate.Category_Type;

            _dataContext.SaveChanges();

            response.Data = categories;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteCategories(int id)
        {
            var response = new Response<bool>();

            var categories = _dataContext.Categories.FirstOrDefault(p => p.Id == id);

            if (categories == null)
            {
                response.AddError("id", "Categories not found");
                return NotFound(response);
            }

            _dataContext.Categories.Remove(categories);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
