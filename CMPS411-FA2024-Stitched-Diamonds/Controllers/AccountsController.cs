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
        public ActionResult<Response<List<Account>>> GetAllAccounts()
        {
            var response = new Response<List<Account>>();

            var accounts = _dataContext.Accounts.ToList();
            response.Data = accounts;

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<Account>> GetAccountById(int id)
        {
            var response = new Response<Account>();

            var account = _dataContext.Accounts.FirstOrDefault(p => p.Id == id);

            if (account == null)
            {
                response.AddError("id", "Account not found");
                return NotFound(response);
            }

            response.Data = account;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<Account>> CreateAccount([FromBody] Account account)
        {
            var response = new Response<Account>();

            // Optionally validate account data here
            _dataContext.Accounts.Add(account);
            _dataContext.SaveChanges();

            response.Data = account;
            return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, response);
        }

        [HttpPut("{id}")]
        public ActionResult<Response<Account>> UpdateAccount(int id, [FromBody] Account accountUpdate)
        {
            var response = new Response<Account>();

            var account = _dataContext.Accounts.FirstOrDefault(p => p.Id == id);

            if (account == null)
            {
                response.AddError("id", "Account not found");
                return NotFound(response);
            }

            account.First_Name = accountUpdate.First_Name;
            account.Last_Name = accountUpdate.Last_Name;
            account.Email = accountUpdate.Email;
            account.Username = accountUpdate.Username;
            account.Password = accountUpdate.Password;
            account.Phone_Number = accountUpdate.Phone_Number;
            account.Billing_Address = accountUpdate.Billing_Address;
            account.Shipping_Address = accountUpdate.Shipping_Address;
            account.Create_Date = accountUpdate.Create_Date;
            account.Is_Active = accountUpdate.Is_Active;
            account.Role = accountUpdate.Role;

            _dataContext.SaveChanges();

            response.Data = account;
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
