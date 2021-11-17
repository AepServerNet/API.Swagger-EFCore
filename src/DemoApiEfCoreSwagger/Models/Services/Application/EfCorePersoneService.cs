using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApiEfCoreSwagger.Models.Entities;
using DemoApiEfCoreSwagger.Models.Services.Infrastructure;
using DemoApiEfCoreSwagger.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DemoApiEfCoreSwagger.Models.Services.Application
{
    public class EfCorePersoneService : IPersoneService
    {
        private readonly ILogger<EfCorePersoneService> logger;
        private readonly MyDatabaseDbContext dbContext;

        public EfCorePersoneService(ILogger<EfCorePersoneService> logger, MyDatabaseDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<ListViewModel<PersonaViewModel>> GetPersoneAsync()
        {
            IQueryable<Persona> baseQuery = dbContext.Persone;

            IQueryable<Persona> queryLinq = baseQuery
                .AsNoTracking();

            List<PersonaViewModel> persone = await queryLinq
                .Select(persona => PersonaViewModel.FromEntity(persona))
                .ToListAsync();

            ListViewModel<PersonaViewModel> result = new()
            {
                Results = persone
            };

            return result;
        }
    }
}