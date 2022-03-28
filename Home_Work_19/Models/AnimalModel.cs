using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Animals;
using Models.Base;
using Models.Interfaces;

namespace Models
{
    public class AnimalModel : AnimalFactory, IModel
    {
        public override IAnimal CreateAnimal(AnimalType type)
        {
            switch (type)
            {
                case AnimalType.MAMMALS: return new Mammals();
                case AnimalType.BIRDS: return new Birds();
                case AnimalType.AMPHIBIOUS: return new Amphibious();
                default: return new NullAnimal();
            }
        }
    }
}
