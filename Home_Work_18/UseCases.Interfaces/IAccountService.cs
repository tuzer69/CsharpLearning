using HomeWork.Entities;

namespace UseCases.Interfeces
{
    public interface IAccountService
    {
        public int AccountsCount(IClient client);
        public Account AddBalance(IAccount account, long amount);
        public void AddSimpleAccount(IClient client);
        public void AddDepositAccount(IClient client);
        public void RemoveAccount(IClient client, IAccount account);
        public void BalanceTransfer(IAccount from, IAccount to, long amount);
        public void ExternalTransfer(IAccount from, IAccount to, long amount);

    }
}