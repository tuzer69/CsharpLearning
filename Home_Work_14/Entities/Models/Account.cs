using System.Runtime.CompilerServices;
using System.Windows;

[assembly:InternalsVisibleTo("Bank.Tests")]

namespace HomeWork13.Entities
{
    public abstract class Account : IAccount

    {

        #region Конструкторы (Constuctors)

        protected Account()
        {
            CurrentNumAccount += 10;
            AccountNumber = CurrentNumAccount;
        }

        #endregion

        #region Поля (Fields)

        #endregion

        #region Свойства (Properties)

        public static ushort CurrentNumAccount { get; private protected set; }
        public uint AccountNumber { get; set; }
        public abstract long Balance { get; set; }
        public bool IsDeposit { get; private protected set; }

        #endregion

        #region Методы (Methods)

        public abstract void BalanceTransfer(IAccount account, long amount);
        public abstract Account AddBalance(long amount);
        public abstract void ExternalTransfer(IAccount account, long amount);


        #endregion

    }

     class SimpleAccount : Account
    {
        #region Свойства (Propeerties)

        public override long Balance { get; set; }

        #endregion

        #region Конструкторы (Constructors)

        public SimpleAccount()
        {
            IsDeposit = false;
        }

        #endregion

        #region Поля (Fields)

        #endregion

        #region Методы (Methods)

        public override void BalanceTransfer(IAccount account, long amount)
        {
            if (this.Balance >= amount && amount > 0)
            {
                this.Balance -= amount;
                account.Balance += amount;
            }
        }
        public override Account AddBalance(long amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return this;
            }
            return this;
        }
        public override void ExternalTransfer(IAccount account, long amount)
        {
            if (this.Balance >= amount && amount > 0)
            {
                this.Balance -= amount;
                account.Balance += amount;
            }
        }

        #endregion
    }

    internal class DepositAccount : SimpleAccount
    {
        public DepositAccount()
        {
            IsDeposit = true;
        }
        
    }

}