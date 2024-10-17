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
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OrdersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<Order>>> GetAllOrders()
        {
            var response = new Response<List<Order>>();

            var orders = _dataContext.Orders.ToList();
            response.Data = orders;

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Order>> GetOrderById(int id)
        {
            var response = new Response<Order>();

            var order = _dataContext.Orders.FirstOrDefault(p => p.Id == id);

            if (order == null)
            {
                response.AddError("id", "Order not found");
                return NotFound(response);
            }

            response.Data = order;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<Order>> CreateOrder([FromBody] Order order)
        {
            var response = new Response<Order>();

            // Optionally validate order data here
            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();

            response.Data = order;
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Order>> UpdateOrder(int id, [FromBody] Order orderUpdate)
        {
            var response = new Response<Order>();

            var order = _dataContext.Orders.FirstOrDefault(p => p.Id == id);

            if (order == null)
            {
                response.AddError("id", "Order not found");
                return NotFound(response);
            }

            order.Date = orderUpdate.Date;
            order.Number = orderUpdate.Number;
            order.Total_Price = orderUpdate.Total_Price;
            order.Payment_Method = orderUpdate.Payment_Method;

            _dataContext.SaveChanges();

            response.Data = order;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteOrder(int id)
        {
            var response = new Response<bool>();

            var order = _dataContext.Orders.FirstOrDefault(p => p.Id == id);

            if (order == null)
            {
                response.AddError("id", "Order not found");
                return NotFound(response);
            }

            _dataContext.Orders.Remove(order);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
