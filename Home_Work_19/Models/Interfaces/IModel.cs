using Models.Base;

namespace Models.Interfaces;

public interface IModel
{
    IAnimal CreateAnimal(AnimalType type);
}