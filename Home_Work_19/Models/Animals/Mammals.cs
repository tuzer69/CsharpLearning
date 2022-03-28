using Models.Base;
using Models.Interfaces;

namespace Models.Animals;

public class Mammals : IAnimal
{
    private int _id;

    public Mammals()
    {
        _id = ++IAnimal._Id;
        Name = $"Mammals{Id}";
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name { get; set; }

    public AnimalType Type => AnimalType.MAMMALS;

    public override string ToString()
    {
        return Name ??= $"Mammals{Id}";
    }
}