using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using DemoApiEfCoreSwagger.Models.Entities;
using DemoApiEfCoreSwagger.Models.InputModels;
using DemoApiEfCoreSwagger.Models.Services.Application;
using DemoApiEfCoreSwagger.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApiEfCoreSwagger.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    public class PersoneController : ControllerBase
    {
        private readonly ILogger<PersoneController> logger;
        private readonly IPersoneService personeService;

        public PersoneController(ILogger<PersoneController> logger, IPersoneService personeService)
        {
            this.logger = logger;
            this.personeService = personeService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(PersonaViewModel))]
        public async Task<IActionResult> GetList()
        {
            var persone = await personeService.GetPersoneAsync();
            return Ok(persone);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonaCreateInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PersonaDetailViewModel persona = await personeService.CreatePersonaAsync(inputModel);
                    return Ok(persona);
                }
                catch
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}