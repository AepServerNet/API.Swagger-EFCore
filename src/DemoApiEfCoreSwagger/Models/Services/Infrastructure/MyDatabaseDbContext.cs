using DemoApiEfCoreSwagger.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApiEfCoreSwagger.Models.Services.Infrastructure
{
    public partial class MyDatabaseDbContext : DbContext
    {
        public MyDatabaseDbContext(DbContextOptions<MyDatabaseDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Persona> Persone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>(entity => 
            {
                entity.ToTable("Persone");
                entity.HasKey(persona => persona.Id);
            });
        }
    }
}