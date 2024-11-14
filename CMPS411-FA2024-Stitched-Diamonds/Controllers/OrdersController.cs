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
        public ActionResult<Response<List<OrderGetDto>>> GetAllOrders()
        {
            var response = new Response<List<OrderGetDto>>();

            var orders = _dataContext.Orders
                .Include(p => p.Account)
                .Include(p => p.Session)
                .Select(p => new OrderGetDto
                {
                    Id = p.Id,
                    OrderDate = p.OrderDate,
                    OrderNumber = p.OrderNumber,
                    TotalPrice = p.TotalPrice,
                    PaymentMethod = p.PaymentMethod,
                    PaymentStatus = p.PaymentStatus,
                    OrderStatus = p.OrderStatus,
                    AccountId = p.AccountId,
                    SessionId = p.SessionId,
                })
                .ToList();

            response.Data = orders;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<OrderGetDto>> GetOrderById(int id)
        {
            var response = new Response<OrderGetDto>();

            var order = _dataContext.Orders
                .Include(p => p.Account)
                .Include(p => p.Session)
                .Where(p => p.Id == id)
                .Select(p => new OrderGetDto
                {
                    Id = p.Id,
                    OrderDate = p.OrderDate,
                    OrderNumber = p.OrderNumber,
                    TotalPrice = p.TotalPrice,
                    PaymentMethod = p.PaymentMethod,
                    PaymentStatus = p.PaymentStatus,
                    OrderStatus = p.OrderStatus,
                    AccountId = p.AccountId,
                    SessionId = p.SessionId,
                })
                .FirstOrDefault(order => order.Id == id);

            if (order == null)
            {
                response.AddError("id", "Order not found");
                return NotFound(response);
            }

            response.Data = order;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<OrderGetDto>> CreateOrder([FromBody] OrderCreateDto orderDto)
        {
            var response = new Response<OrderGetDto>();

            var order = new Order
            {
                OrderDate = orderDto.OrderDate,
                OrderNumber = orderDto.OrderNumber,
                TotalPrice = orderDto.TotalPrice,
                PaymentMethod = orderDto.PaymentMethod,
                PaymentStatus = orderDto.PaymentStatus,
                OrderStatus = orderDto.OrderStatus,
                AccountId = orderDto.AccountId,
                SessionId = orderDto.SessionId,
            };

            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();

            var createdOrderDto = new OrderGetDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                TotalPrice = order.TotalPrice,
                PaymentMethod = order.PaymentMethod,
                PaymentStatus = order.PaymentStatus,
                OrderStatus = order.OrderStatus,
                AccountId = order.AccountId,
                SessionId = order.SessionId,
            };

            response.Data = createdOrderDto;
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<OrderGetDto>> UpdateOrder(int id, [FromBody] OrderUpdateDto orderDto)
        {
            var response = new Response<OrderGetDto>();

            var order = _dataContext.Orders.FirstOrDefault(p => p.Id == id);

            if (order == null)
            {
                response.AddError("id", "Order not found");
                return NotFound(response);
            }

            order.OrderStatus = orderDto.OrderStatus;
            order.PaymentStatus = orderDto.PaymentStatus;
            _dataContext.SaveChanges();

            var updatedOrderDto = new OrderGetDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderNumber = order.OrderNumber,
                TotalPrice = order.TotalPrice,
                PaymentMethod = order.PaymentMethod,
                PaymentStatus = order.PaymentStatus,
                OrderStatus = order.OrderStatus,
                AccountId = order.AccountId,
                SessionId = order.SessionId,
            };

            response.Data = updatedOrderDto;
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
