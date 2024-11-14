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
    [Route("api/subcategories")]
    public class SubcategoriesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SubcategoriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<SubcategoryGetDto>>> GetAllSubcategories()
        {
            var response = new Response<List<SubcategoryGetDto>>();

            var subcategories = _dataContext.Subcategories
                .Include(p => p.Category)
                .Select(p => new SubcategoryGetDto
                {
                    Id = p.Id,
                    Subtype = p.Subtype,
                    CategoryId = p.CategoryId
                })
                .ToList();

            response.Data = subcategories;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<SubcategoryGetDto>> GetSubcategoryById(int id)
        {
            var response = new Response<SubcategoryGetDto>();

            var subcategory = _dataContext.Subcategories
                .Include(p => p.Category)
                .Where(p => p.Id == id)
                .Select(p => new SubcategoryGetDto
                {
                    Id = p.Id,
                    Subtype = p.Subtype,
                    CategoryId = p.CategoryId
                })
                .FirstOrDefault(subcategory => subcategory.Id == id);

            if (subcategory == null)
            {
                response.AddError("id", "Subcategory not found");
                return NotFound(response);
            }

            response.Data = subcategory;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<SubcategoryGetDto>> CreateSubcategory([FromBody] SubcategoryCreateDto subcategoryDto)
        {
            var response = new Response<SubcategoryGetDto>();

            var subcategory = new Subcategory
            {
                CategoryId = subcategoryDto.CategoryId,
                Subtype = subcategoryDto.Subtype,
            };

            _dataContext.Subcategories.Add(subcategory);
            _dataContext.SaveChanges();

            var createdSubcategoryDto = new SubcategoryGetDto
            {
                Id = subcategory.Id,
                Subtype = subcategoryDto.Subtype,
                CategoryId = subcategoryDto.CategoryId
            };

            response.Data = createdSubcategoryDto;
            return CreatedAtAction(nameof(GetSubcategoryById), new { id = subcategory.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<SubcategoryGetDto>> UpdateSubcategory(int id, [FromBody] SubcategoryUpdateDto subcategoryDto)
        {
            var response = new Response<SubcategoryGetDto>();

            var subcategory = _dataContext.Subcategories.FirstOrDefault(p => p.Id == id);

            if (subcategory == null)
            {
                response.AddError("id", "Subcategory not found");
                return NotFound(response);
            }

            subcategory.CategoryId = subcategoryDto.CategoryId;
            subcategory.Subtype = subcategoryDto.Subtype;
            _dataContext.SaveChanges();

            var updatedSubcategoryDto = new SubcategoryGetDto
            {
                Id = subcategory.Id,
                CategoryId = subcategory.CategoryId,
                Subtype = subcategory.Subtype
            };

            response.Data = updatedSubcategoryDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteSubcategory(int id)
        {
            var response = new Response<bool>();

            var subcategory = _dataContext.Subcategories.FirstOrDefault(p => p.Id == id);

            if (subcategory == null)
            {
                response.AddError("id", "Subcategory not found");
                return NotFound(response);
            }

            _dataContext.Subcategories.Remove(subcategory);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
