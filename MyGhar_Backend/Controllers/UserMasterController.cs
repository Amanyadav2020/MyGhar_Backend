using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyGhar_Backend.Contract;
using MyGhar_Backend.DBContext;
using MyGhar_Backend.Service;

namespace MyGhar_Backend.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserMasterController : ControllerBase
    {

        private readonly IUserMaster _UserMaster;
        private readonly IConfiguration _Configuration;
        private readonly ILogger<UserMasterController> _logger;

        public UserMasterController(ILogger<UserMasterController> logger,IUserMaster UserMaster, IConfiguration configuration)
        {
            _Configuration = configuration;
            _logger = logger;
            _UserMaster = UserMaster;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IResult> GetAll()
        {
            try
            {
                return Results.Ok(await _UserMaster.GetAll());

            }
            catch (Exception ex) 
            {
                return Results.BadRequest(ex.Message);
            }


        }
    }
}
