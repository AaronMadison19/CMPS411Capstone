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
        public ActionResult<Response<List<CategoryGetDto>>> GetAllCategories()
        {
            var response = new Response<List<CategoryGetDto>>();

            var categories = _dataContext.Categories
                .Select(p => new CategoryGetDto
                {
                    Id = p.Id,
                    Type = p.Type,
                })
                .ToList();

            response.Data = categories;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<CategoryGetDto>> GetCategoryById(int id)
        {
            var response = new Response<CategoryGetDto>();

            var category = _dataContext.Categories
                .Include(p => p.Products)
                .Where(p => p.Id == id)
                .Select(p => new CategoryGetDto
                {
                    Id = p.Id,
                    Type = p.Type,
                    Products = p.Products.Select(p => new ProductGetDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        CategoryId = p.CategoryId,
                        SubcategoryId = p.SubcategoryId,
                        Details = p.Details,
                        MaterialId = p.MaterialId,
                        QuantityInStock = p.QuantityInStock,
                        ImageUrl = p.ImageUrl

                    }).ToList(),
                })
                .FirstOrDefault(category => category.Id == id);

            if (category == null)
            {
                response.AddError("id", "Category not found");
                return NotFound(response);
            }

            response.Data = category;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<CategoryGetDto>> CreateCategory([FromBody] CategoryCreateDto categoryDto)
        {
            var response = new Response<CategoryGetDto>();

            var category = new Category
            {
                Type = categoryDto.Type,
            };

            _dataContext.Categories.Add(category);
            _dataContext.SaveChanges();

            var createdCategoryDto = new CategoryGetDto
            {
                Id = category.Id,
                Type = category.Type,
            };

            response.Data = createdCategoryDto;
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<CategoryGetDto>> UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryDto)
        {
            var response = new Response<CategoryGetDto>();

            var category = _dataContext.Categories.FirstOrDefault(p => p.Id == id);

            if (category == null)
            {
                response.AddError("id", "Category not found");
                return NotFound(response);
            }

            category.Type = categoryDto.Type;
            _dataContext.SaveChanges();

            var updatedCategoryDto = new CategoryGetDto
            {
                Id = category.Id,
                Type = category.Type,
            };

            response.Data = updatedCategoryDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteCategory(int id)
        {
            var response = new Response<bool>();

            var category = _dataContext.Categories.FirstOrDefault(p => p.Id == id);

            if (category == null)
            {
                response.AddError("id", "Category not found");
                return NotFound(response);
            }

            _dataContext.Categories.Remove(category);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
