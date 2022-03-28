using Models.Base;

namespace Models.Interfaces;

public interface IAnimal
{
    public static int _Id { get; protected set; }

    public  int Id { get; set; }

    string Name { get; set; }

    AnimalType Type { get; }
}