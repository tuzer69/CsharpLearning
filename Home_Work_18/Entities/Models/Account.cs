using System;

namespace HomeWork.Entities
{
    public class Account : IAccount, IEquatable<Account>

    {
        #region Конструкторы (Constuctors)

        public Account()
        {
            CurrentNumAccount += 100;
            AccountNumber = CurrentNumAccount;
        }

        #endregion

        #region Поля (Fields)

        #endregion

        #region Свойства (Properties)

        public int Id { get; set; }
        public static uint CurrentNumAccount { get; private protected set; }
        public uint AccountNumber { get; set; }
        public virtual long Balance { get; set; }
        public bool IsDeposit { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        #endregion

        #region Методы (Methods)

        public virtual void BalanceTransfer(IAccount account, long amount){}
        public virtual Account AddBalance(long amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return this;
            }
            return this;
        }
        public virtual void ExternalTransfer(IAccount account, long amount){}

        #endregion

        #region IEquatable

        public bool Equals(Account other)
        {
            return Id == other.Id && AccountNumber == other.AccountNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Account) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, AccountNumber);
        }

        public static bool operator ==(Account left, Account right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Account left, Account right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}