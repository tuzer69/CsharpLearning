namespace HomeWork.Entities
{
    public interface IAddBalance<out T>
    {
        T AddBalance(long amount);
    }

}