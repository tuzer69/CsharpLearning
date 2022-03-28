using HomeWork13.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork13.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.Host.Services.GetRequiredService<MainViewModel>();
        //public MainViewModel MainViewModel => new(new Repository<Client>());
    }
}