using System.Collections.Generic;

namespace DemoApiEfCoreSwagger.Models.ViewModels
{
    public class ListViewModel<T>
    {
        public List<T> Results { get; set; }
    }
}