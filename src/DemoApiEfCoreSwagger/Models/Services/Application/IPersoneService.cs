using System.Threading.Tasks;
using DemoApiEfCoreSwagger.Models.InputModels;
using DemoApiEfCoreSwagger.Models.ViewModels;

namespace DemoApiEfCoreSwagger.Models.Services.Application
{
    public interface IPersoneService
    {
        Task<ListViewModel<PersonaViewModel>> GetPersoneAsync();
        Task<PersonaDetailViewModel> CreatePersonaAsync(PersonaCreateInputModel inputModel);
    }
}