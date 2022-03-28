using System;
using System.Windows;
using HomeWork.Entities;

namespace HomeWork.Wrappers
{
    public class AccountWrapper : WrapperBase<Account>, IAccount, ICloneable
    {
        public AccountWrapper(Account model) : base(model)
        {
        }

        
        #region Свойства (Properties)

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

        #endregion

        #region Методы (Methods)

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
                Balance -= amount;
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

        #endregion

        #region Override Methods

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.model);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            Account account = (obj as AccountWrapper)?.model;

            return model == account;
        }

        #endregion

    }
}