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
        public ActionResult<Response<List<Material>>> GetAllMaterials()
        {
            var response = new Response<List<Material>>();

            var materials = _dataContext.Materials.ToList();
            response.Data = materials;

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Material>> GetMaterialById(int id)
        {
            var response = new Response<Material>();

            var material = _dataContext.Materials.FirstOrDefault(p => p.Id == id);

            if (material == null)
            {
                response.AddError("id", "Material not found");
                return NotFound(response);
            }

            response.Data = material;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<Material>> CreateMaterial([FromBody] Material material)
        {
            var response = new Response<Material>();

            // Optionally validate product data here
            _dataContext.Materials.Add(material);
            _dataContext.SaveChanges();

            response.Data = material;
            return CreatedAtAction(nameof(GetMaterialById), new { id = material.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Material>> UpdateMaterial(int id, [FromBody] Material materialUpdate)
        {
            var response = new Response<Material>();

            var material = _dataContext.Materials.FirstOrDefault(p => p.Id == id);

            if (material == null)
            {
                response.AddError("id", "Material not found");
                return NotFound(response);
            }

            material.Type = materialUpdate.Type;
            material.Is_Allergen_Free = materialUpdate.Is_Allergen_Free;
            material.Quantity_In_Stock = materialUpdate.Quantity_In_Stock;

            _dataContext.SaveChanges();

            response.Data = material;
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
