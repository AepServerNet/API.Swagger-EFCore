using System.Net.Mime;
using System.Threading.Tasks;
using DemoApiEfCoreSwagger.Models.InputModels;
using DemoApiEfCoreSwagger.Models.Services.Application;
using DemoApiEfCoreSwagger.Models.ViewModels;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                PersonaDetailViewModel viewModel = await personeService.GetPersonaAsync(id);
                return Ok(viewModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] PersonaDeleteInputModel inputModel)
        {
            try
            {
                await personeService.DeletePersonaAsync(inputModel);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}