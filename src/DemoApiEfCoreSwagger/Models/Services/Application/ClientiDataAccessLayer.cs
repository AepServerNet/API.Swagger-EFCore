using System;
using System.Collections.Generic;
using System.Linq;
using DemoApiEfCoreSwagger.Models.Entities;
using DemoApiEfCoreSwagger.Models.Services.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoApiEfCoreSwagger.Models.Services.Application
{
    public class ClientiDataAccessLayer
    {
        private readonly ILogger<ClientiDataAccessLayer> logger;
        private readonly MyDatabaseDbContext dbContext;

        public ClientiDataAccessLayer(ILogger<ClientiDataAccessLayer> logger, MyDatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public IEnumerable<Cliente> GetClienti()  
        {  
            try  
            {  
                return dbContext.Clienti.ToList();
            }  
            catch  
            {  
                throw new Exception();
            }  
        }

        public int AddCliente(Cliente cliente)  
        {  
            try  
            {  
                dbContext.Clienti.Add(cliente);  
                dbContext.SaveChanges(); 

                return 1;
            }  
            catch  
            {  
                throw new Exception();
            }  
        }

        public int UpdateCliente(Cliente cliente) 
        {  
            try  
            {  
                dbContext.Entry(cliente).State = EntityState.Modified;  
                dbContext.SaveChanges();  
  
                return 1;  
            }  
            catch  
            {  
                throw new Exception();
            }  
        }  

        public Cliente GetCliente(int id)  
        {  
            try  
            {  
                Cliente cliente = dbContext.Clienti.Find(id);  
                return cliente;  
            }  
            catch  
            {  
                throw new Exception();
            }  
        } 

        public int DeleteCliente(int id)  
        {  
            try  
            {  
                Cliente cliente = dbContext.Clienti.Find(id);  
                dbContext.Clienti.Remove(cliente);  
                dbContext.SaveChanges();  

                return 1;  
            }  
            catch  
            {  
                throw new Exception();
            }  
        } 
    }
}