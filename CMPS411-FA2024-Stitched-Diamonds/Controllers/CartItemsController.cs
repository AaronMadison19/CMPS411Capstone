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
    [Route("api/cartItems")]
    public class CartItemsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CartItemsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<CartItemGetDto>>> GetAllCartItems()
        {
            var response = new Response<List<CartItemGetDto>>();

            var cartItems = _dataContext.CartItems
                .Include(p => p.Cart)
                .Include(p => p.Product)
                .Include(p => p.ProductVariant)
                .Select(p => new CartItemGetDto
                {
                    Id = p.Id,
                    CartId = p.CartId,
                    ProductId = p.ProductId,
                    VariantId = p.VariantId,
                    Quantity = p.Quantity,
                    Price = p.Price,
                })
                .ToList();

            response.Data = cartItems;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<CartItemGetDto>> GetCartItemById(int id)
        {
            var response = new Response<CartItemGetDto>();

            var cartItem = _dataContext.CartItems
                .Include(p => p.Cart)
                .Include(p => p.Product)
                .Include(p => p.ProductVariant)
                .Where(p => p.Id == id)
                .Select(p => new CartItemGetDto
                {
                    Id = p.Id,
                    CartId = p.CartId,
                    ProductId = p.ProductId,
                    VariantId = p.VariantId,
                    Quantity = p.Quantity,
                    Price = p.Price
                })
                .FirstOrDefault();

            if (cartItem == null)
            {
                response.AddError("id", "CartItem not found");
                return NotFound(response);
            }

            response.Data = cartItem;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<CartItemGetDto>> CreateCartItem([FromBody] CartItemCreateDto cartItemDto)
        {
            var response = new Response<CartItemGetDto>();

            // Check if the product already exists in the cart with the same variant
            var existingCartItem = _dataContext.CartItems
                .FirstOrDefault(ci => ci.CartId == cartItemDto.CartId && ci.ProductId == cartItemDto.ProductId && ci.VariantId == cartItemDto.VariantId);

            if (existingCartItem != null)
            {
                // Update the quantity of the existing cart item
                existingCartItem.Quantity += cartItemDto.Quantity;
                existingCartItem.Price = cartItemDto.Price;  // Ensure the price is updated if necessary
                _dataContext.SaveChanges();

                var updatedCartItemDto = new CartItemGetDto
                {
                    Id = existingCartItem.Id,
                    CartId = existingCartItem.CartId,
                    ProductId = existingCartItem.ProductId,
                    VariantId = existingCartItem.VariantId,
                    Quantity = existingCartItem.Quantity,
                    Price = existingCartItem.Price
                };

                response.Data = updatedCartItemDto;
                return Ok(response);
            }
            else
            {
                // Create a new cart item
                var cartItem = new CartItem
                {
                    CartId = cartItemDto.CartId,
                    ProductId = cartItemDto.ProductId,
                    VariantId = cartItemDto.VariantId,
                    Quantity = cartItemDto.Quantity,
                    Price = cartItemDto.Price,
                };

                _dataContext.CartItems.Add(cartItem);
                _dataContext.SaveChanges();

                var createdCartItemDto = new CartItemGetDto
                {
                    Id = cartItem.Id,
                    CartId = cartItem.CartId,
                    ProductId = cartItem.ProductId,
                    VariantId = cartItem.VariantId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Price
                };

                response.Data = createdCartItemDto;
                return CreatedAtAction(nameof(GetCartItemById), new { id = cartItem.Id }, response);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Response<CartItemGetDto>> UpdateCartItem(int id, [FromBody] CartItemUpdateDto cartItemDto)
        {
            var response = new Response<CartItemGetDto>();

            var cartItem = _dataContext.CartItems.FirstOrDefault(p => p.Id == id);

            if (cartItem == null)
            {
                response.AddError("id", "CartItem not found");
                return NotFound(response);
            }

            cartItem.ProductId = cartItemDto.ProductId;
            cartItem.VariantId = cartItemDto.VariantId;
            cartItem.Quantity = cartItemDto.Quantity;
            cartItem.Price = cartItemDto.Price;
            _dataContext.SaveChanges();

            var updatedCartItemDto = new CartItemGetDto
            {
                Id = cartItem.Id,
                CartId = cartItem.CartId,
                ProductId = cartItem.ProductId,
                VariantId = cartItem.VariantId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price
            };

            response.Data = updatedCartItemDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteCartItem(int id)
        {
            var response = new Response<bool>();

            var cartItem = _dataContext.CartItems.FirstOrDefault(p => p.Id == id);

            if (cartItem == null)
            {
                response.AddError("id", "CartItem not found");
                return NotFound(response);
            }

            _dataContext.CartItems.Remove(cartItem);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
