using System.Collections.ObjectModel;
using System.Windows.Input;
using Components;
using UseCases.Interfeces;
using HomeWork.Commands;
using HomeWork.Entities;
using HomeWork.Wrappers;
using MediatR;

namespace HomeWork.ViewModel
{

    public partial class MainViewModel : Bindable
    {
        private readonly IReposytory<Client> _repository;
        private readonly IMediator _sender;

        #region Конструкторы (Constructors)

        public MainViewModel(IReposytory<Client> repository, IMediator sender)
        {
            _repository = repository;
            _sender = sender;


            #region Инициализация свойств (Initialization of properties)

            ExtraPanelType = PanelType.None;

            #endregion

            #region Добавление клиентов в UI (Add Clients)

            _clients = new ObservableCollection<ClientWrapper>();
            foreach (var client in _repository.GetClients())
            {
                _clients.Add(new ClientWrapper(client));
            }

            #endregion

            #region Инициализация комманд (Initialize commands)

            ExitAppCommand = new RelayCommand(OnExitAppCommand, CanExitAppCommand);
            AddAccount = new RelayCommand(OnAddAccoun, CanAddAccount);
            CreateAccount = new RelayCommand(OnCreateAccount, CanCreateAccount);
            RemoveAccount = new RelayCommand(OnRemoveAccount, CanRemoveAccount);
            InternalTransferPrep = new RelayCommand(OnInternalTransferPrep, CanInternalTransferPrep);
            BalanceTransfer = new RelayCommand(OnBalanceTransfer, CanBalanceTransfer);
            AddBalancePrep = new RelayCommand(OnAddBalancePrep, CanAddBalancePrep);
            ExrernalTransferPrep = new RelayCommand(OnExrernalTransferPrep, CanExrernalTransferPrep);
            CreateDepositAccount = new RelayCommand(OnCreateDepositAccount, CanCreateDepositAccount);
            InternalAddBalance = new RelayCommand(OnInternalAddBalance, CanInternalAddBalance);
            ExternalTransfer = new RelayCommand(OnExternalTransfer, CanExternalTransfer);

            #endregion
        }

        #endregion

        #region Поля (Fields)

        private ObservableCollection<ClientWrapper> _clients;
        private ClientWrapper _selectedClient;
        private AccountWrapper _selectedAccount;
        private PanelType _extraPanelType;
        private ICommand _activeCommand;
        private long _amountTransfer;
        private AccountWrapper _outAccount;
        private ClientWrapper _outClient;


        #endregion

        #region Свойства (Properties)

        #region Команды (Commands)

        public ICommand ActiveCommand
        {
            get => _activeCommand;
            set
            {
                _activeCommand = value;
                OnPropertyChanged();
            }
        }
        public ICommand ExternalTransfer { get; }
        public ICommand InternalAddBalance { get; }
        public ICommand CreateDepositAccount { get; }
        public ICommand ExrernalTransferPrep { get; }
        public ICommand AddBalancePrep { get; }
        public ICommand BalanceTransfer { get; }
        public ICommand InternalTransferPrep { get; }
        public ICommand CreateAccount { get; }
        public ICommand AddAccount { get; }
        public ICommand ExitAppCommand { get; }
        public ICommand RemoveAccount { get; }

        #endregion

        public ObservableCollection<AccountWrapper> Accounts
        {
            get => SelectedClient.Accounts;
            set
            {
                SelectedClient.Accounts = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ClientWrapper> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged();
            }
        }
        public ClientWrapper SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Accounts));
            }
        }
        public AccountWrapper SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
            }
        }
        public long AamountTransfer
        {
            get => _amountTransfer;
            set
            {
                _amountTransfer = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Свойства View (View Properties)

        public PanelType ExtraPanelType
        {
            get => _extraPanelType;
            set
            {
                _extraPanelType = value;
                OnPropertyChanged();
            }
        }
        private ClientWrapper OutClient
        {
            get => _outClient;
            set
            {
                _outClient = value;
                OnPropertyChanged();
            }
        }
        private AccountWrapper OutAccount
        {
            get => _outAccount;
            set
            {
                _outAccount = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Методы (Methods)


        #endregion

    }
}