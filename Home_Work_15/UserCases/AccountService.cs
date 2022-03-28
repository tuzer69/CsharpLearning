
using System;
using HomeWork.Entities;
using UseCases.Interfeces;

namespace UseCases
{

    public class AccountService : IAccountService
    {

        public int AccountsCount(IClient client)
        {
            if (client == null) { throw new ArgumentException("Client not found!"); }

            return client.GetAccounts().Count;
        }

        public Account AddBalance(IAccount account, long amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The amount must be greater than zero!");
            }

            return account.AddBalance(amount);

        }

        public void AddSimpleAccount(IClient client)
        {
            if (client == null) { throw new ArgumentException("Client not found!"); }

            client.AddSimpleAccount();

        }

        public void AddDepositAccount(IClient client)
        {
            if (client == null) { throw new ArgumentException("Client not found!"); }

            client.AddDepositAccount();
        }

        public void RemoveAccount(IClient client, IAccount account)
        {
            client.RemoveAccount(account);
        }

        public void BalanceTransfer(IAccount from, IAccount to, long amount)
        {
            if (from == null) { throw new ArgumentException("Account not selected"); }

            from.BalanceTransfer(to, amount);
        }

        public void ExternalTransfer(IAccount from, IAccount to, long amount)
        {
            if (from == null) { throw new ArgumentException("Account not selected"); }

            from.ExternalTransfer(to, amount);
        }
    }
}