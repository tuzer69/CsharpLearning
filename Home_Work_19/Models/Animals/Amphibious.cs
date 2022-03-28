using Models.Base;
using Models.Interfaces;

namespace Models.Animals;

public class Amphibious : IAnimal
{
    private int _id;

    public Amphibious()
    {
        _id = ++IAnimal._Id;
        Name = $"Amphibious{Id}";
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name { get; set; }

    public AnimalType Type => AnimalType.AMPHIBIOUS;

    public override string ToString()
    {
        return Name ??= $"Amphibious{Id}";
    }

}