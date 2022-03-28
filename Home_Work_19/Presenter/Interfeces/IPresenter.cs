using System.Collections.ObjectModel;
using System.Windows.Input;
using Models.Base;
using Models.Interfaces;

namespace Presenter
{
    public interface IPresenter
    {
        ObservableCollection<IAnimal> Repository { get; set; }

        IAnimal CurentAnimal { get; set; }

        IView View { get; set; }

        public ICommand AddAmimalCommand { get; }

        public ICommand RemoveAmimalCommand { get; }

        public ICommand OpenDialogCommand { get; }

        public ICommand SaveDbCommand { get; }

        public ICommand LoadDbCommand { get; }
    }
}

