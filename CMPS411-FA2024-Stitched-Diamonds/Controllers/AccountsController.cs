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
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AccountsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<AccountGetDto>>> GetAllAccounts()
        {
            var response = new Response<List<AccountGetDto>>();

            var accounts = _dataContext.Accounts
                .Select(p => new AccountGetDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    Username = p.Username,
                    PhoneNumber = p.PhoneNumber,
                    BillingAddress = p.BillingAddress,
                    ShippingAddress = p.ShippingAddress,
                    CreateDate = p.CreateDate,
                    IsActive = p.IsActive,
                    Role = p.Role,
                })
                .ToList();

            response.Data = accounts;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<AccountGetDto>> GetAccountById(int id)
        {
            var response = new Response<AccountGetDto>();

            var account = _dataContext.Accounts
                .Select(p => new AccountGetDto
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Email = p.Email,
                    Username = p.Username,
                    PhoneNumber = p.PhoneNumber,
                    BillingAddress = p.BillingAddress,
                    ShippingAddress = p.ShippingAddress,
                    CreateDate = p.CreateDate,
                    IsActive = p.IsActive,
                    Role = p.Role,
                })
                .FirstOrDefault(account => account.Id == id);

            if (account == null)
            {
                response.AddError("id", "Account not found");
                return NotFound(response);
            }

            response.Data = account;
            return Ok(response);
        }

        [HttpGet("login")]
        public ActionResult<Response<AccountGetDto>> GetAccountByCredentials(string username, string password)
        {
            var response = new Response<AccountGetDto>();

            // Find the account based on username
            var account = _dataContext.Accounts
                .Where(a => a.Username == username)
                .FirstOrDefault();

            if (account == null)
            {
                response.AddError("username", "Account not found");
                return NotFound(response);
            }

            // Validate the password
            if (account.Password != password)
            {
                response.AddError("password", "Invalid password");
                return Unauthorized(response); // Unauthorized status code
            }

            // Map to AccountGetDto if the login is successful
            var accountDto = new AccountGetDto
            {
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Username = account.Username,
                PhoneNumber = account.PhoneNumber,
                BillingAddress = account.BillingAddress,
                ShippingAddress = account.ShippingAddress,
                CreateDate = account.CreateDate,
                IsActive = account.IsActive,
                Role = account.Role,
            };

            response.Data = accountDto;

            return Ok(response); // Return the account data with ID if the login is successful
        }

        [HttpPost]
        public ActionResult<Response<AccountGetDto>> CreateAccount([FromBody] AccountCreateDto accountDto)
        {
            var response = new Response<AccountGetDto>();

            var account = new Account
            {
                FirstName = accountDto.FirstName,
                LastName = accountDto.LastName,
                Email = accountDto.Email,
                Username = accountDto.Username,
                Password = accountDto.Password,
                //PhoneNumber = accountDto.PhoneNumber,
                //BillingAddress = accountDto.BillingAddress,
                //ShippingAddress = accountDto.ShippingAddress,
                //Role = accountDto.Role,
                CreateDate = DateTime.UtcNow,
                IsActive = accountDto.IsActive,
            };

            _dataContext.Accounts.Add(account);
            _dataContext.SaveChanges();

            var createdAccountDto = new AccountGetDto
            {
                Id = account.Id,
                FirstName = accountDto.FirstName,
                LastName = accountDto.LastName,
                Email = accountDto.Email,
                Username= accountDto.Username,
                //PhoneNumber= accountDto.PhoneNumber,
                //BillingAddress= accountDto.BillingAddress,
                //ShippingAddress= accountDto.ShippingAddress,
                //Role = accountDto.Role,
                CreateDate = accountDto.CreateDate,
                IsActive = accountDto.IsActive,
            };

            response.Data = createdAccountDto;
            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<AccountGetDto>> UpdateAccount(int id, [FromBody] AccountUpdateDto accountDto)
        {
            var response = new Response<AccountGetDto>();

            var account = _dataContext.Accounts.FirstOrDefault(p => p.Id == id);

            if (account == null)
            {
                response.AddError("id", "Account not found");
                return NotFound(response);
            }

            account.FirstName = accountDto.FirstName;
            account.LastName = accountDto.LastName;
            account.Email = accountDto.Email;
            account.Username = accountDto.Username;
            account.PhoneNumber = accountDto.PhoneNumber;
            account.BillingAddress = accountDto.BillingAddress;
            account.ShippingAddress = accountDto.ShippingAddress;
            account.Password = accountDto.Password;
            _dataContext.SaveChanges();

            var updatedAccountDto = new AccountGetDto
            {
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Username = account.Username,
                PhoneNumber = account.PhoneNumber,
                BillingAddress = account.BillingAddress,
                ShippingAddress = account.ShippingAddress,
                CreateDate = account.CreateDate,
                IsActive = account.IsActive,
                Role = account.Role,
            };

            response.Data = updatedAccountDto;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteAccount(int id)
        {
            var response = new Response<bool>();

            var account = _dataContext.Accounts.FirstOrDefault(p => p.Id == id);

            if (account == null)
            {
                response.AddError("id", "Account not found");
                return NotFound(response);
            }

            _dataContext.Accounts.Remove(account);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
