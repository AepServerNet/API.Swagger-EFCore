using System.Collections.Generic;
using System.Net.Mime;
using DemoApiEfCoreSwagger.Models.Entities;
using DemoApiEfCoreSwagger.Models.InputModels;
using DemoApiEfCoreSwagger.Models.Services.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApiEfCoreSwagger.Controllers
{
    // [ApiController]
    // [Produces(MediaTypeNames.Application.Json)]
    // [Route("api/[controller]")]
    public class ClientiController : ControllerBase
    {
        private readonly ILogger<ClientiController> logger;
        //private readonly IPersoneService personeService;
        private readonly ClientiDataAccessLayer objCliente;

        //public ClientiController(ILogger<ClientiController> logger, IPersoneService personeService)
        public ClientiController(ILogger<ClientiController> logger, ClientiDataAccessLayer objCliente)
        {
            this.logger = logger;
            //this.personeService = personeService;
            this.objCliente = objCliente;
        }

        [HttpGet]  
        [Route("api/Clienti/Index")] 
        public IEnumerable<Cliente> GetList()
        {
            return objCliente.GetClienti();
        }

        [HttpPost]  
        [Route("api/Clienti/Create")]  
        public int Create(Cliente cliente)  
        {  
            return objCliente.AddCliente(cliente);  
        } 

        [HttpGet]  
        [Route("api/Clienti/Details/{id}")]  
        public Cliente Details(int id)  
        {  
            return objCliente.GetCliente(id);  
        } 

        [HttpPut]  
        [Route("api/Clienti/Edit")]  
        public int Edit(Cliente cliente)  
        {  
            return objCliente.UpdateCliente(cliente);  
        }  
  
        [HttpDelete]  
        [Route("api/Clienti/Delete/{id}")]  
        public int Delete(int id)  
        {  
            return objCliente.DeleteCliente(id);  
        }  

        // [HttpGet]
        // public JsonResult GetList()
        // {
        //     var persone = personeService.GetPersoneAsync();
        //     return new JsonResult(persone);
        // }

        // [HttpPost]
        // public JsonResult Create(PersonaCreateInputModel inputModel)
        // {
        //     personeService.CreatePersonaAsync(inputModel);
        //     return new JsonResult("Persona aggiunta con successo !");
        // }

        // [HttpGet("{id}")]
        // public JsonResult Detail(int id)
        // {
        //     var persona = personeService.GetPersonaAsync(id);
        //     return new JsonResult(persona);
        // }

        // [HttpDelete("{id}")]
        // public JsonResult Delete(PersonaDeleteInputModel inputModel)
        // {
        //     personeService.DeletePersonaAsync(inputModel);
        //     return new JsonResult("Persona cancellata con successo !");
        // }
    }
}