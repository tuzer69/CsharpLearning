using System.Collections.ObjectModel;

namespace HomeWork.Entities
{
    public interface IAccount : IAddBalance<Account>, ITransaction<Account>
    {
        long Balance { get; set; }
        void BalanceTransfer(IAccount account, long amount);
    }

}