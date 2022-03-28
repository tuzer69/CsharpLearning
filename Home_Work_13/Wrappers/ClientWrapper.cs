using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using HomeWork13.Entities;

namespace HomeWork13.Wrappers
{
    public class ClientWrapper : WrapperBase<Client>, IClient
    {
        private ObservableCollection<AccountWrapper> _accounts;

        public ClientWrapper(Client model) : base(model)
        {
            _accounts = new ObservableCollection<AccountWrapper>();
        }
        
        public override string ToString() => Name + " " + Surname;

        public string Name
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Surname
        {
            get => Get<string>();
            set => Set(value);
        }

        public void AddSimpleAccount()
        {
            model.AddSimpleAccount();
            UpdataAccounts();
        }

        public void AddDepositAccount()
        {
            model.AddDepositAccount();
            UpdataAccounts();
        }

        public void RemoveAccount(IAccount account)
        {
            model.RemoveAccount(account);
            UpdataAccounts();
        }

        public List<Account> GetAccounts() => model.GetAccounts();

        public ObservableCollection<AccountWrapper> Accounts
        {
            get
            {
                UpdataAccounts();
                return _accounts;
            }
            set
            {
                _accounts = value;
                OnPropertyChanged();
            }
        }

        private void UpdataAccounts()
        {
            _accounts.Clear();
            foreach (var account in model.GetAccounts())
            {
                _accounts.Add(new AccountWrapper(account));
            }
        }
    }
}