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
    [Route("api/carts")]
    public class CartsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CartsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<CartGetDto>>> GetAllCarts()
        {
            var response = new Response<List<CartGetDto>>();

            var carts = _dataContext.Carts
                .Include(p => p.Account)
                .Include(p => p.Session)
                .Select(p => new CartGetDto
                {
                    Id = p.Id,
                    AccountId = p.AccountId,
                    SessionId = p.SessionId,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    IsActive = p.IsActive,
                })
                .ToList();

            response.Data = carts;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<CartGetDto>> GetCartById(int id)
        {
            var response = new Response<CartGetDto>();

            var cart = _dataContext.Carts
                .Include(p => p.Account)
                .Include(p => p.Session)
                .Include(p => p.CartItems)
                .Where(p => p.Id == id)
                .Select(p => new CartGetDto
                {
                    Id = p.Id,
                    AccountId = p.AccountId,
                    SessionId = p.SessionId,
                    CreatedDate = p.CreatedDate,
                    UpdatedDate = p.UpdatedDate,
                    IsActive = p.IsActive,
                    CartItems = p.CartItems.Select(p => new CartItemGetDto
                    {
                     Id = p.Id,
                     CartId = p.CartId,
                     ProductId = p.ProductId,
                     VariantId = p.VariantId,
                     Quantity = p.Quantity,
                     Price = p.Price,
                        
                    }).ToList(),
                })
           .FirstOrDefault(cart => cart.Id == id);

            if (cart == null)
            {
                response.AddError("id", "Cart not found");
                return NotFound(response);
            }

            response.Data = cart;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<CartGetDto>> CreateCart([FromBody] CartCreateDto cartDto)
        {
            var response = new Response<CartGetDto>();

            var cart = new Cart
            {
                AccountId = cartDto.AccountId,
                SessionId = cartDto.SessionId,
                CreatedDate = cartDto.CreatedDate,
                UpdatedDate = cartDto.UpdatedDate,
                IsActive = cartDto.IsActive,
            };

            _dataContext.Carts.Add(cart);
            _dataContext.SaveChanges();

            var createdCartDto = new CartGetDto
            {
                Id = cart.Id,
                AccountId = cart.AccountId,
                SessionId = cart.SessionId,
                CreatedDate = cart.CreatedDate,
                UpdatedDate = cart.UpdatedDate,
                IsActive = cart.IsActive,
            };

            response.Data = createdCartDto;
            return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<CartGetDto>> UpdateCart(int id, [FromBody] CartUpdateDto cartDto)
        {
            var response = new Response<CartGetDto>();

            var cart = _dataContext.Carts.FirstOrDefault(p => p.Id == id);

            if (cart == null)
            {
                response.AddError("id", "Cart not found");
                return NotFound(response);
            }

            cart.UpdatedDate = cartDto.UpdatedDate;
            cart.IsActive = cartDto.IsActive;

            _dataContext.SaveChanges();

            var updatedCartDto = new CartGetDto
            {
                Id = cart.Id,
                AccountId = cart.AccountId,
                SessionId = cart.SessionId,
                CreatedDate = cart.CreatedDate,
                UpdatedDate = cart.UpdatedDate,
                IsActive = cart.IsActive,
            };

            response.Data = updatedCartDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteCart(int id)
        {
            var response = new Response<bool>();

            var cart = _dataContext.Carts.FirstOrDefault(p => p.Id == id);

            if (cart == null)
            {
                response.AddError("id", "Cart not found");
                return NotFound(response);
            }

            _dataContext.Carts.Remove(cart);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
