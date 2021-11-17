using DemoApiEfCoreSwagger.Models.Entities;

namespace DemoApiEfCoreSwagger.Models.ViewModels
{
    public class PersonaViewModel
    {
        public int Id { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public static PersonaViewModel FromEntity(Persona persona)
        {
            return new PersonaViewModel {
                Id = persona.Id,
                Cognome = persona.Cognome,
                Nome = persona.Nome,
                Telefono = persona.Telefono,
                Email = persona.Email
            };
        }
    }
}