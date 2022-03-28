namespace HomeWork.Entities;

public class SimpleAccount : Account
{
    #region Свойства (Propeerties)

    public long Balance { get; set; }

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
    // public override Account AddBalance(long amount)
    // {
    //     if (amount > 0)
    //     {
    //         Balance += amount;
    //         return this;
    //     }
    //     return this;
    // }
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