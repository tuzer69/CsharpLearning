using Models.Interfaces;

namespace Models.Base
{
    public abstract class AnimalFactory
    {
        public abstract IAnimal CreateAnimal(AnimalType type);
    }
}
