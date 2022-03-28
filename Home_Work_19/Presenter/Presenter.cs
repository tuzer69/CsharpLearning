using System.Collections.ObjectModel;
using Models.Base;
using Models.Interfaces;
using Presenter.Base;

namespace Presenter
{
    public partial class Presenter : Bindable, IPresenter
    {
        private readonly IModel _model;

        private IAnimal _currentAnimal;

        public Presenter(IModel model)
        {
            _model = model;

            Repository = new ObservableCollection<IAnimal>();

            #region Commands

            AddAmimalCommand = new RelayCommand(OnAddAnimal, CanAddAnimal);

            RemoveAmimalCommand = new RelayCommand(OnRemoveAnimal, CanRemoveAnimal);

            OpenDialogCommand = new RelayCommand(OnOpenDialog, CanOpenDialog);

            SaveDbCommand = new RelayCommand(OnSaveDb, CanSaveDb);

            LoadDbCommand = new RelayCommand(OnLoadDb, CanLoadDb);

            #endregion

        }

        public IView View { get; set; }

        public ObservableCollection<IAnimal> Repository { get; set; }

        public IAnimal CurentAnimal
        {
            get => _currentAnimal;
            set
            {
                _currentAnimal = value;
                OnPropertyChanged();
            }
        }


    }
}
