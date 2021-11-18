using System.Collections.Generic;
using DemoApiEfCoreSwagger.Models.Entities;
using DemoApiEfCoreSwagger.Models.Services.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApiEfCoreSwagger.Controllers
{
    public class ClientiController : ControllerBase
    {
        private readonly ILogger<ClientiController> logger;
        private readonly ClientiDataAccessLayer objCliente;

        public ClientiController(ILogger<ClientiController> logger, ClientiDataAccessLayer objCliente)
        {
            this.logger = logger;
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
    }
}