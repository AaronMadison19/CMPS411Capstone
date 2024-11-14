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
    [Route("api/adminActions")]
    public class AdminActionsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AdminActionsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<AdminActionGetDto>>> GetAllAdminActions()
        {
            var response = new Response<List<AdminActionGetDto>>();

            var adminActions = _dataContext.AdminActions
                .Include(p => p.Account)
                .Include(p => p.Product)
                .Select(p => new AdminActionGetDto
                {
                    Id = p.Id,
                    AccountId = p.AccountId,
                    ProductId = p.ProductId,
                    ActionType = p.ActionType,
                    ActionDate = p.ActionDate,
                    Details = p.Details,
                })
                .ToList();

            response.Data = adminActions;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<AdminActionGetDto>> GetAdminActionById(int id)
        {
            var response = new Response<AdminActionGetDto>();

            var adminAction = _dataContext.AdminActions
                .Include(p => p.Account)
                .Include(p => p.Product)
                .Where(p => p.Id == id)
                .Select(p => new AdminActionGetDto
                {
                    Id = p.Id,
                    AccountId = p.AccountId,
                    ProductId = p.ProductId,
                    ActionType = p.ActionType,
                    ActionDate = p.ActionDate,
                    Details = p.Details,
                })
                .FirstOrDefault();

            if (adminAction == null)
            {
                response.AddError("id", "Admin Action not found");
                return NotFound(response);
            }

            response.Data = adminAction;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<AdminActionGetDto>> CreateAdminAction([FromBody] AdminActionCreateDto adminActionDto)
        {
            var response = new Response<AdminActionGetDto>();

            var adminAction = new AdminAction
            {
                AccountId = adminActionDto.AccountId,
                ProductId = adminActionDto.ProductId,
                ActionType= adminActionDto.ActionType,
                ActionDate = adminActionDto.ActionDate,
                Details = adminActionDto.Details,
            };

            _dataContext.AdminActions.Add(adminAction);
            _dataContext.SaveChanges();

            var createdAdminActionDto = new AdminActionGetDto
            {
                Id = adminAction.Id,
                AccountId = adminAction.AccountId,
                ProductId = adminAction.ProductId,
                ActionType = adminAction.ActionType,
                ActionDate = adminAction.ActionDate,
                Details = adminAction.Details,
            };

            response.Data = createdAdminActionDto;
            return CreatedAtAction(nameof(GetAdminActionById), new { id = adminAction.Id }, response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteAdminAction(int id)
        {
            var response = new Response<bool>();

            var adminAction = _dataContext.AdminActions.FirstOrDefault(p => p.Id == id);

            if (adminAction == null)
            {
                response.AddError("id", "AdminAction not found");
                return NotFound(response);
            }

            _dataContext.AdminActions.Remove(adminAction);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
