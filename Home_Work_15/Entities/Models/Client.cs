using System.Collections.Generic;

namespace HomeWork.Entities
{
    public class Client : IClient
    {
        #region Конструктор (Constructor)

        public Client(string name, string surname)
        {
            Name = name;
            Surname = surname;
            Accounts = new List<Account>();
        }

        #endregion

        #region Свойства (Properties)

        public string Name { get; set; }
        public string Surname { get; set; }
        private List<Account> Accounts { get; set; }


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
    }
}