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
    [Route("api/materials")]
    public class MaterialsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public MaterialsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<MaterialGetDto>>> GetAllMaterials()
        {
            var response = new Response<List<MaterialGetDto>>();

            var materials = _dataContext.Materials
                .Select(p => new MaterialGetDto
                {
                    Id = p.Id,
                    Type = p.Type,
                    IsAllergenFree = p.IsAllergenFree,
                    QuantityInStock = p.QuantityInStock,
                    Cost = p.Cost,
                })
                .ToList();

            response.Data = materials;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<MaterialGetDto>> GetMaterialById(int id)
        {
            var response = new Response<MaterialGetDto>();

            var material = _dataContext.Materials
                .Where(p => p.Id == id)
                .Select(p => new MaterialGetDto
                {
                    Id = p.Id,
                    Type = p.Type,
                    IsAllergenFree = p.IsAllergenFree,
                    QuantityInStock = p.QuantityInStock,
                    Cost = p.Cost,
                })
                .FirstOrDefault(material => material.Id == id);

            if (material == null)
            {
                response.AddError("id", "Material not found");
                return NotFound(response);
            }

            response.Data = material;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<MaterialGetDto>> CreateMaterial([FromBody] MaterialCreateDto materialDto)
        {
            var response = new Response<MaterialGetDto>();

            var material = new Material
            {
                Type = materialDto.Type,
                IsAllergenFree = materialDto.IsAllergenFree,
                QuantityInStock = materialDto.QuantityInStock,
                Cost = materialDto.Cost,
            };

            _dataContext.Materials.Add(material);
            _dataContext.SaveChanges();

            var createdMaterialDto = new MaterialGetDto
            {
                Id = material.Id,
                Type = material.Type,
                IsAllergenFree = material.IsAllergenFree,
                QuantityInStock = material.QuantityInStock,
                Cost = material.Cost,
            };

            response.Data = createdMaterialDto;
            return CreatedAtAction(nameof(GetMaterialById), new { id = material.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<MaterialGetDto>> UpdateMaterial(int id, [FromBody] MaterialUpdateDto materialDto)
        {
            var response = new Response<MaterialGetDto>();

            var material = _dataContext.Materials.FirstOrDefault(p => p.Id == id);

            if (material == null)
            {
                response.AddError("id", "Material not found");
                return NotFound(response);
            }

            material.Type = materialDto.Type;
            material.IsAllergenFree = materialDto.IsAllergenFree;
            material.QuantityInStock = materialDto.QuantityInStock;
            material.Cost = materialDto.Cost;
            _dataContext.SaveChanges();

            var updatedMaterialDto = new MaterialGetDto
            {
                Id = material.Id,
                Type = material.Type,
                IsAllergenFree = material.IsAllergenFree,
                QuantityInStock = materialDto.QuantityInStock,
                Cost = materialDto.Cost,
            };

            response.Data = updatedMaterialDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteMaterial(int id)
        {
            var response = new Response<bool>();

            var material = _dataContext.Materials.FirstOrDefault(p => p.Id == id);

            if (material == null)
            {
                response.AddError("id", "Material not found");
                return NotFound(response);
            }

            _dataContext.Materials.Remove(material);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response); 
        }
    }
}
