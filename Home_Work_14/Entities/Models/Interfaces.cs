using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HomeWork13.Entities
{
    public interface IAccount : IAddBalance<Account>, ITransaction<Account>
    {
        long Balance { get; set; }
        void BalanceTransfer(IAccount account, long amount);
    }

    public interface IAddBalance<out T>
    {
        T AddBalance(long amount);
    }

    public interface ITransaction<in T>
    {
        void ExternalTransfer(IAccount account, long amount);
    }

    public interface IClient
    {
        void AddSimpleAccount();
        void AddDepositAccount();
        void RemoveAccount(IAccount account);
        List<Account> GetAccounts();
    }

    public interface IRepository
    {
        public void AddClient(string name, string surname);
        public void RemoveClient(string name, string surname);
        public List<Client> ClientsList { get; set; }
    }
}