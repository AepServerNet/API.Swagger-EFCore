using System.Collections.Generic;
using DemoApiEfCoreSwagger.Models.Entities;
using DemoApiEfCoreSwagger.Models.Services.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoApiEfCoreSwagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public IEnumerable<Cliente> GetList()
        {
            return objCliente.GetClienti();
        }

        [HttpPost] 
        public int Create(Cliente cliente)  
        {  
            return objCliente.AddCliente(cliente);  
        } 

        [HttpGet]  
        [Route("{id}")]
        public Cliente Details(int id)  
        {  
            return objCliente.GetCliente(id);  
        } 

        [HttpPut]  
        public int Edit(Cliente cliente)  
        {  
            return objCliente.UpdateCliente(cliente);  
        }  
  
        [HttpDelete]  
        [Route("{id}")]  
        public int Delete(int id)  
        {  
            return objCliente.DeleteCliente(id);  
        }  
    }
}