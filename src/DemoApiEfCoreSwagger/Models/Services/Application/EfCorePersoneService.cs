using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApiEfCoreSwagger.Models.Entities;
using DemoApiEfCoreSwagger.Models.InputModels;
using DemoApiEfCoreSwagger.Models.Services.Infrastructure;
using DemoApiEfCoreSwagger.Models.ViewModels;
using Microsoft.Data.Sqlite;
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

        public async Task<PersonaDetailViewModel> CreatePersonaAsync(PersonaCreateInputModel inputModel)
        {
            var persona = new Persona()
            {
                Cognome = inputModel.Cognome,
                Nome = inputModel.Nome,
                Telefono = inputModel.Telefono,
                Email = inputModel.Email
            };

            dbContext.Add(persona);

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException exc) when ((exc.InnerException as SqliteException)?.SqliteErrorCode == 19)
            {
                throw new Exception();
            }

            return PersonaDetailViewModel.FromEntity(persona);
        }
    }
}