using System.Windows;
using HomeWork13.Entities;

namespace HomeWork13.Wrappers
{
    public class AccountWrapper : WrapperBase<Account>, IAccount
    {
        public AccountWrapper(Account model) : base(model)
        {
        }

        public uint AccountNumber
        {
            get => Get<uint>();
            set => Set(value);
        }

        public long Balance
        {
            get => Get<long>();
            set => Set(value);
        }

        public bool IsDeposit
        {
            get => Get<bool>();
            set => Set(value);
        }

        public Account AddBalance(long amount)
        {

            if (amount > 0)
            {
               Balance += amount;
                return model;
            }
            return model;
        }

        public void BalanceTransfer(IAccount account, long amount)
        {
            if (Balance >= amount && amount > 0)
            {
                this.Balance -= amount;
                account.Balance += amount;
            }
        }

        public void ExternalTransfer(IAccount account, long amount)
        {
            if (Balance >= amount && amount > 0)
            {
                this.Balance -= amount;
                account.Balance += amount;
            }
        }
    }
}