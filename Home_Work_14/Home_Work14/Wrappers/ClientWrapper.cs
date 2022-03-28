using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
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


        #region Свойства (Properties)

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


        #endregion

        #region Методы (Methods)

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

        private void UpdataAccounts()
        {
            _accounts.Clear();
            foreach (var account in model.GetAccounts())
            {
                _accounts.Add(new AccountWrapper(account));
            }
        }

        #endregion

        #region Override Methods

        public override string ToString() => Name + " " + Surname;

        public override bool Equals(object obj)
        {
            if (obj == null || model.GetType() != (obj as ClientWrapper)?.model.GetType())
                return false;

            Client client = (obj as ClientWrapper)?.model;

            return (model.Name == client.Name) && (client.Surname == model.Surname);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(model.Name, model.Surname);
        }

        #endregion
    }
}