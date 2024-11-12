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
    [Route("api/shippings")]
    public class ShippingsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ShippingsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<ShippingGetDto>>> GetAllShippings()
        {
            var response = new Response<List<ShippingGetDto>>();

            var shippings = _dataContext.Shippings
                .Include(p => p.Session)
                .Include(p => p.Account)
                .Include(p => p.Order)
                .Select(p => new ShippingGetDto
                {
                    Id = p.Id,
                    SessionId = p.SessionId,
                    AccountId = p.AccountId,
                    OrderId = p.OrderId,
                    ShippingAddress = p.ShippingAddress,
                    ShippedDate = p.ShippedDate,
                    ShippingCost = p.ShippingCost,
                    ShippingMethod = p.ShippingMethod,
                    TrackingNumber = p.TrackingNumber,
                })
                .ToList();

            response.Data = shippings;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<ShippingGetDto>> GetShippingById(int id)
        {
            var response = new Response<ShippingGetDto>();

            var shipping = _dataContext.Shippings
                .Include(p => p.Session)
                .Include(p => p.Account)
                .Include(p => p.Order)
                .Where(p => p.Id == id)
                .Select(p => new ShippingGetDto
                {
                    Id = p.Id,
                    SessionId = p.SessionId,
                    AccountId = p.AccountId,
                    OrderId = p.OrderId,
                    ShippingAddress = p.ShippingAddress,
                    ShippedDate = p.ShippedDate,
                    ShippingCost = p.ShippingCost,
                    ShippingMethod = p.ShippingMethod,
                    TrackingNumber = p.TrackingNumber,
                })
                .FirstOrDefault(shipping => shipping.Id == id);

            if (shipping == null)
            {
                response.AddError("id", "Shipping not found");
                return NotFound(response);
            }

            response.Data = shipping;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<ShippingGetDto>> CreateShipping([FromBody] ShippingCreateDto shippingDto)
        {
            var response = new Response<ShippingGetDto>();

            var shipping = new Shipping
            {
                SessionId = shippingDto.SessionId,
                AccountId = shippingDto.AccountId,
                OrderId = shippingDto.OrderId,
                ShippingAddress = shippingDto.ShippingAddress,
                ShippedDate = shippingDto.ShippedDate,
                ShippingCost = shippingDto.ShippingCost,
                ShippingMethod = shippingDto.ShippingMethod,
                TrackingNumber = shippingDto.TrackingNumber,
            };

            _dataContext.Shippings.Add(shipping);
            _dataContext.SaveChanges();

            var createdShippingDto = new ShippingGetDto
            {
                Id = shipping.Id,
                SessionId = shipping.SessionId,
                AccountId = shipping.AccountId,
                OrderId = shipping.OrderId,
                ShippingAddress = shipping.ShippingAddress,
                ShippedDate = shipping.ShippedDate,
                ShippingCost = shipping.ShippingCost,
                ShippingMethod = shipping.ShippingMethod,
                TrackingNumber = shipping.TrackingNumber,
            };

            response.Data = createdShippingDto;
            return CreatedAtAction(nameof(GetShippingById), new { id = shipping.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<ShippingGetDto>> UpdateShipping(int id, [FromBody] ShippingUpdateDto shippingDto)
        {
            var response = new Response<ShippingGetDto>();

            var shipping = _dataContext.Shippings.FirstOrDefault(p => p.Id == id);

            if (shipping == null)
            {
                response.AddError("id", "Shipping not found");
                return NotFound(response);
            }

            shipping.ShippingMethod = shippingDto.ShippingMethod;
            shipping.ShippingAddress = shippingDto.ShippingAddress;
            shipping.ShippedDate = shippingDto.ShippedDate;
            shipping.ShippingCost = shippingDto.ShippingCost;
            shipping.TrackingNumber = shippingDto.TrackingNumber;
            _dataContext.SaveChanges();

            var updatedShippingDto = new ShippingGetDto
            {
                Id = shipping.Id,
                SessionId = shipping.SessionId,
                AccountId = shipping.AccountId,
                OrderId = shipping.OrderId,
                ShippingAddress = shipping.ShippingAddress,
                ShippedDate = shipping.ShippedDate,
                ShippingCost = shipping.ShippingCost,
                ShippingMethod = shipping.ShippingMethod,
                TrackingNumber = shipping.TrackingNumber,
            };

            response.Data = updatedShippingDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteShipping(int id)
        {
            var response = new Response<bool>();

            var shipping = _dataContext.Shippings.FirstOrDefault(p => p.Id == id);

            if (shipping == null)
            {
                response.AddError("id", "Shipping not found");
                return NotFound(response);
            }

            _dataContext.Shippings.Remove(shipping);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
