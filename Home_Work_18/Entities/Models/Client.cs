using System;
using System.Collections.Generic;
using System.Data;

namespace HomeWork.Entities
{
    public class Client : IClient, IEquatable<Client>
    {
        #region Конструкторы (Constructor)

        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Client()
        { }

        #endregion

        #region Свойства (Properties)

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Account> Accounts { get; set; }


        #endregion

        #region Методы (Methods)

        public List<Account> GetAccounts() => Accounts;
        public void AddSimpleAccount()
        {
            IAccount tmpAccount = new SimpleAccount();
            Accounts?.Add(tmpAccount as SimpleAccount);
        }
        public void AddDepositAccount()
        {
            IAccount tmpAccount = new DepositAccount();
            Accounts.Add(tmpAccount as DepositAccount);
        }
        public void RemoveAccount(IAccount account)
        {
            Accounts.Remove(account as Account);
        }
        public override string ToString()
        {
            return Name + " " + Surname;
        }


        #endregion

        #region Реализаця IEquatable

        public bool Equals(Client other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Surname == other.Surname;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Client) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname);
        }

        public static bool operator ==(Client left, Client right) => Equals(left, right);

        public static bool operator !=(Client left, Client right) => !Equals(left, right);

        #endregion
    }
}