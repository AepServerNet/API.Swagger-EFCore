using System.ComponentModel.DataAnnotations;

namespace DemoApiEfCoreSwagger.Models.InputModels
{
    public class PersonaDeleteInputModel
    {
        [Required]
        public int Id { get; set; }
    }
}