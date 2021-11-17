using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApiEfCoreSwagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("Orario")]
        public IActionResult Orario()
        {
            return Ok(string.Concat("Ciao sono le ore: ", DateTime.Now.ToShortTimeString()));
        }

        [HttpGet("Saluti")]
        public IActionResult Saluti()
        {
            return Ok("Ciao sono il tuo webService in ASP.NET Core");
        }
    }
}