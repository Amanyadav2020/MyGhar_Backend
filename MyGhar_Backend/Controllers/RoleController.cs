using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGhar_Backend.Contract;

namespace MyGhar_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _Role;

        public RoleController(IRole role)
        {
            _Role = role;
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var result = await _Role.GetAll();
            return Results.Ok(result);
        }
    }
}
