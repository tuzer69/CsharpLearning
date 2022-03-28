using System.Collections.Generic;

namespace HomeWork.Entities
{
    public interface IClient
    {
        void AddSimpleAccount();
        void AddDepositAccount();
        void RemoveAccount(IAccount account);
        List<Account> GetAccounts();
    }

}