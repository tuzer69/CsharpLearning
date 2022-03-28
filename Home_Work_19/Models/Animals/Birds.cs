using Models.Base;
using Models.Interfaces;

namespace Models.Animals;

public class Birds : IAnimal
{
    private int _id;

    public Birds()
    {
        _id = ++IAnimal._Id;
        Name = $"Birds{Id}";
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name { get; set; }

    public AnimalType Type => AnimalType.BIRDS;

    public override string ToString()
    {
        return Name ??= $"Bird{Id}";
    }

}