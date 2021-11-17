using System.ComponentModel.DataAnnotations;

namespace DemoApiEfCoreSwagger.Models.InputModels
{
    public class PersonaCreateInputModel
    {
        [Required]
        public string Cognome { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Email { get; set; }
    }
}