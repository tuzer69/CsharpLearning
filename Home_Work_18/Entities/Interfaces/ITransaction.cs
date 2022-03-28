namespace HomeWork.Entities
{
    public interface ITransaction<in T>
    {
        void ExternalTransfer(IAccount account, long amount);
    }

}