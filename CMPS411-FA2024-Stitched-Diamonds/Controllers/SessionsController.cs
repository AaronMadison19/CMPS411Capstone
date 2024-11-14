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
    [Route("api/sessions")]
    public class SessionsController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SessionsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<Response<List<SessionGetDto>>> GetAllSessions()
        {
            var response = new Response<List<SessionGetDto>>();

            var sessions = _dataContext.Sessions
                .Include(p => p.Account)
                .Select(p => new SessionGetDto
                {
                    Id = p.Id,
                    AccountId = p.AccountId,
                    CreatedAt = p.CreatedAt,
                    ExpiresAt = p.ExpiresAt,
                })
                .ToList();

            response.Data = sessions;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Response<SessionGetDto>> GetSessionById(int id)
        {
            var response = new Response<SessionGetDto>();

            var session = _dataContext.Sessions
                .Include(p => p.Account)
                .Where(p => p.Id == id)
                .Select(p => new SessionGetDto
                {
                    Id = p.Id,
                    AccountId = p.AccountId,
                    CreatedAt = p.CreatedAt,
                    ExpiresAt = p.ExpiresAt,
                })
                .FirstOrDefault(session => session.Id == id);

            if (session == null)
            {
                response.AddError("id", "Session not found");
                return NotFound(response);
            }

            response.Data = session;
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Response<SessionGetDto>> CreateSession([FromBody] SessionCreateDto sessionDto)
        {
            var response = new Response<SessionGetDto>();

            var session = new Session
            {
                AccountId = sessionDto.AccountId,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow,
            };

            _dataContext.Sessions.Add(session);
            _dataContext.SaveChanges();

            var createdSessionDto = new SessionGetDto
            {
                Id = session.Id,
                AccountId = session.AccountId,
                CreatedAt = session.CreatedAt,
                ExpiresAt = session.ExpiresAt,
            };

            response.Data = createdSessionDto;
            return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response<bool>> DeleteSession(int id)
        {
            var response = new Response<bool>();

            var session = _dataContext.Sessions.FirstOrDefault(p => p.Id == id);

            if (session == null)
            {
                response.AddError("id", "Session not found");
                return NotFound(response);
            }

            _dataContext.Sessions.Remove(session);
            _dataContext.SaveChanges();

            response.Data = true;
            return Ok(response);
        }
    }
}
