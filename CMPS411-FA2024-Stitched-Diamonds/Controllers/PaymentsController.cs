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
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PaymentsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<PaymentGetDto>>> GetAllPayments()
        {
            var response = new Response<List<PaymentGetDto>>();

            var payments = _dataContext.Payments
                .Include(p => p.Order)
                .Select(p => new PaymentGetDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    PaymentDate = p.PaymentDate,
                    Amount = p.Amount,
                    PaymentMethod = p.PaymentMethod,
                    Status = p.Status,
                })
                .ToList();

            response.Data = payments;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<PaymentGetDto>> GetPaymentById(int id)
        {
            var response = new Response<PaymentGetDto>();

            var payment = _dataContext.Payments
                .Include(p => p.Order)
                .Where(p => p.Id == id)
                .Select(p => new PaymentGetDto
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    PaymentDate = p.PaymentDate,
                    Amount = p.Amount,
                    PaymentMethod = p.PaymentMethod,
                    Status = p.Status,
                })
                .FirstOrDefault(payment => payment.Id == id);

            if (payment == null)
            {
                response.AddError("id", "Payment not found");
                return NotFound(response);
            }

            response.Data = payment;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<PaymentGetDto>> CreatePayment([FromBody] PaymentCreateDto paymentDto)
        {
            var response = new Response<PaymentGetDto>();

            var payment = new Payment
            {
                OrderId = paymentDto.OrderId,
                PaymentDate = paymentDto.PaymentDate,
                Amount = paymentDto.Amount,
                PaymentMethod = paymentDto.PaymentMethod,
                Status = paymentDto.Status,
            };

            _dataContext.Payments.Add(payment);
            _dataContext.SaveChanges();

            var createdPaymentDto = new PaymentGetDto
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,
            };

            response.Data = createdPaymentDto;
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<PaymentGetDto>> UpdatePayment(int id, [FromBody] PaymentUpdateDto paymentDto)
        {
            var response = new Response<PaymentGetDto>();

            var payment = _dataContext.Payments.FirstOrDefault(p => p.Id == id);

            if (payment == null)
            {
                response.AddError("id", "Payment not found");
                return NotFound(response);
            }

            payment.Status = paymentDto.Status;
            _dataContext.SaveChanges();

            var updatedPaymentDto = new PaymentGetDto
            {
                Id = payment.Id,
                OrderId = payment.OrderId,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,
            };

            response.Data = updatedPaymentDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeletePayment(int id)
        {
            var response = new Response<bool>();

            var payment = _dataContext.Payments.FirstOrDefault(p => p.Id == id);

            if (payment == null)
            {
                response.AddError("id", "Payment not found");
                return NotFound(response);
            }

            _dataContext.Payments.Remove(payment);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
