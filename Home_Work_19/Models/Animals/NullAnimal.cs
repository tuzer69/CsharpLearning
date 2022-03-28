using Models.Base;
using Models.Interfaces;

namespace Models.Animals;

public class NullAnimal : IAnimal
{
    private int _id = 0;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => "Not Emplemented";
        set => value = "Not Emplemented";
    }

    public AnimalType Type => AnimalType.NULL;
}