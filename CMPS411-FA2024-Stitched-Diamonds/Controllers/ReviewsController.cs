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
    [Route("api/reviews")]
    public class ReviewsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ReviewsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<ReviewGetDto>>> GetAllReviews()
        {
            var response = new Response<List<ReviewGetDto>>();

            var reviews = _dataContext.Reviews
                .Include(p => p.Account)
                .Include(p => p.Product)
                .Select(p => new ReviewGetDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Comment = p.Comment,
                    AccountId = p.AccountId,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt,
                    Rating = p.Rating,
                    IsVisible = p.IsVisible,
                })
                .ToList();

            response.Data = reviews;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<ReviewGetDto>> GetReviewById(int id)
        {
            var response = new Response<ReviewGetDto>();

            var review = _dataContext.Reviews
                .Include(p => p.Account)
                .Include(p => p.Product)
                .Where(p => p.Id == id)
                .Select(p => new ReviewGetDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Comment = p.Comment,
                    AccountId = p.AccountId,
                    ProductId = p.ProductId,
                    CreatedAt = p.CreatedAt,
                    Rating = p.Rating,
                    IsVisible = p.IsVisible,
                })
                .FirstOrDefault(review => review.Id == id);

            if (review == null)
            {
                response.AddError("id", "Review not found");
                return NotFound(response);
            }

            response.Data = review;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<ReviewGetDto>> CreateReview([FromBody] ReviewCreateDto reviewDto)
        {
            var response = new Response<ReviewGetDto>();

            var review = new Review
            {
                ProductId = reviewDto.ProductId,
                AccountId = reviewDto.AccountId,
                Rating = reviewDto.Rating,
                Title = reviewDto.Title,
                Comment = reviewDto.Comment,
                CreatedAt = DateTime.UtcNow,
                IsVisible = reviewDto.IsVisible,
            };

            _dataContext.Reviews.Add(review);
            _dataContext.SaveChanges();

            var createdReviewDto = new ReviewGetDto
            {
                Id = review.Id,
                Title = review.Title,
                Comment = review.Comment,
                AccountId = review.AccountId,
                ProductId = review.ProductId,
                CreatedAt = review.CreatedAt,
                Rating = review.Rating,
                IsVisible = review.IsVisible,
            };

            response.Data = createdReviewDto;
            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<ReviewGetDto>> UpdateReview(int id, [FromBody] ReviewUpdateDto reviewDto)
        {
            var response = new Response<ReviewGetDto>();

            var review = _dataContext.Reviews.FirstOrDefault(p => p.Id == id);

            if (review == null)
            {
                response.AddError("id", "Review not found");
                return NotFound(response);
            }

            review.Rating = reviewDto.Rating;
            review.Title = reviewDto.Title;
            review.Comment = reviewDto.Comment;
            review.IsVisible = reviewDto.IsVisible;

            _dataContext.SaveChanges();

            var updatedReviewDto = new ReviewGetDto
            {
                Id = review.Id,
                Title = review.Title,
                Comment = review.Comment,
                AccountId = review.AccountId,
                ProductId = review.ProductId,
                CreatedAt = review.CreatedAt,
                Rating = review.Rating,
                IsVisible = review.IsVisible,
            };

            response.Data = updatedReviewDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteReview(int id)
        {
            var response = new Response<bool>();

            var review = _dataContext.Reviews.FirstOrDefault(p => p.Id == id);

            if (review == null)
            {
                response.AddError("id", "Review not found");
                return NotFound(response);
            }

            _dataContext.Reviews.Remove(review);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
