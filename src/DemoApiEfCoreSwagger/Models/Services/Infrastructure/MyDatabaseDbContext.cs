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
        public virtual DbSet<Cliente> Clienti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>(entity => 
            {
                entity.ToTable("Persone");
                entity.HasKey(persona => persona.Id);
            });

            modelBuilder.Entity<Cliente>(entity => 
            {
                entity.ToTable("Clienti");
                entity.HasKey(cliente => cliente.ClienteId);
            });
        }
    }
}