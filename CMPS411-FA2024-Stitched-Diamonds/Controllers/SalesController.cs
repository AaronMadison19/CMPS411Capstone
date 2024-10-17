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
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SalesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<Sale>>> GetAllSales()
        {
            var response = new Response<List<Sale>>();

            var sales = _dataContext.Sales.ToList();
            response.Data = sales;

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Sale>> GetSaleById(int id)
        {
            var response = new Response<Sale>();

            var sale = _dataContext.Sales.FirstOrDefault(p => p.Id == id);

            if (sale == null)
            {
                response.AddError("id", "Sale not found");
                return NotFound(response);
            }

            response.Data = sale;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<Sale>> CreateOrder([FromBody] Sale sale)
        {
            var response = new Response<Sale>();

            // Optionally validate sale data here
            _dataContext.Sales.Add(sale);
            _dataContext.SaveChanges();

            response.Data = sale;
            return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Sale>> UpdateSale(int id, [FromBody] Sale saleUpdate)
        {
            var response = new Response<Sale>();

            var sale = _dataContext.Sales.FirstOrDefault(p => p.Id == id);

            if (sale == null)
            {
                response.AddError("id", "Sale not found");
                return NotFound(response);
            }

            sale.Quantity_Sold = saleUpdate.Quantity_Sold;
            sale.Unit_Price = saleUpdate.Unit_Price;

            _dataContext.SaveChanges();

            response.Data = sale;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteSale(int id)
        {
            var response = new Response<bool>();

            var sale = _dataContext.Sales.FirstOrDefault(p => p.Id == id);

            if (sale == null)
            {
                response.AddError("id", "Sale not found");
                return NotFound(response);
            }

            _dataContext.Sales.Remove(sale);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
