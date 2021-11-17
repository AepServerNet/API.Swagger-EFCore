using System.Threading.Tasks;
using DemoApiEfCoreSwagger.Models.ViewModels;

namespace DemoApiEfCoreSwagger.Models.Services.Application
{
    public interface IPersoneService
    {
        Task<ListViewModel<PersonaViewModel>> GetPersoneAsync();
    }
}