using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HomeWork.Entities
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

}