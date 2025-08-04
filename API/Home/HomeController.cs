using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace API.Home
{
    [ApiController()]
    [Route("api/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            return StatusCode(StatusCodes.Status200OK,"Hello!");
        }
    }
}