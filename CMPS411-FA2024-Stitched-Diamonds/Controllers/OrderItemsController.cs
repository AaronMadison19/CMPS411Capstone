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
    [Route("api/orderItems")]
    public class OrderItemsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public OrderItemsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<OrderItemGetDto>>> GetAllOrderItems()
        {
            var response = new Response<List<OrderItemGetDto>>();

            var orderItems = _dataContext.OrderItems
                .Include(p => p.Order)
                .Include(p => p.Product)
                .Include(p => p.ProductVariant)
                .Select(p => new OrderItemGetDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    ProductId = p.ProductId,
                    VariantId = p.VariantId,
                    Quantity = p.Quantity,
                    Price = p.Price,
                })
                .ToList();

            response.Data = orderItems;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<OrderItemGetDto>> GetOrderItemById(int id)
        {
            var response = new Response<OrderItemGetDto>();

            var orderItem = _dataContext.OrderItems
                .Include(p => p.Order)
                .Include(p => p.Product)
                .Include(p => p.ProductVariant)
                .Where(p => p.Id == id)
                .Select(p => new OrderItemGetDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    ProductId = p.ProductId,
                    VariantId = p.VariantId,
                    Quantity = p.Quantity,
                    Price = p.Price
                })
                .FirstOrDefault(orderItem => orderItem.Id == id);

            if (orderItem == null)
            {
                response.AddError("id", "OrderItem not found");
                return NotFound(response);
            }

            response.Data = orderItem;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<OrderItemGetDto>> CreateOrderItem([FromBody] OrderItemCreateDto orderItemDto)
        {
            var response = new Response<OrderItemGetDto>();

            var orderItem = new OrderItem
            {
                OrderId = orderItemDto.OrderId,
                ProductId = orderItemDto.ProductId,
                VariantId = orderItemDto.VariantId,
                Quantity = orderItemDto.Quantity,
                Price = orderItemDto.Price,
            };

            _dataContext.OrderItems.Add(orderItem);
            _dataContext.SaveChanges();

            var createdOrderItemDto = new OrderItemGetDto
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                VariantId = orderItem.VariantId,
                Quantity = orderItem.Quantity,
                Price = orderItem.Price
            };

            response.Data = createdOrderItemDto;
            return CreatedAtAction(nameof(GetOrderItemById), new { id = orderItem.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<OrderItemGetDto>> UpdateOrderItem(int id, [FromBody] OrderItemUpdateDto orderItemDto)
        {
            var response = new Response<OrderItemGetDto>();

            var orderItem = _dataContext.OrderItems.FirstOrDefault(p => p.Id == id);

            if (orderItem == null)
            {
                response.AddError("id", "OrderItem not found");
                return NotFound(response);
            }

            orderItem.ProductId = orderItemDto.ProductId;
            orderItem.VariantId = orderItemDto.VariantId;
            orderItem.Quantity = orderItemDto.Quantity;
            orderItem.Price = orderItemDto.Price;
            _dataContext.SaveChanges();

            var updatedOrderItemDto = new OrderItemGetDto
            {
                Id = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                VariantId = orderItem.VariantId,
                Quantity = orderItem.Quantity,
                Price = orderItem.Price
            };

            response.Data = updatedOrderItemDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteOrderItem(int id)
        {
            var response = new Response<bool>();

            var orderItem = _dataContext.OrderItems.FirstOrDefault(p => p.Id == id);

            if (orderItem == null)
            {
                response.AddError("id", "OrderItem not found");
                return NotFound(response);
            }

            _dataContext.OrderItems.Remove(orderItem);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
