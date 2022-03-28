using HomeWork.Entities;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Interfeces;

namespace HomeWork.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.Host.Services.GetRequiredService<MainViewModel>();

        //public MainViewModel MainViewModel => new(new Repository<Client>());
    }
}