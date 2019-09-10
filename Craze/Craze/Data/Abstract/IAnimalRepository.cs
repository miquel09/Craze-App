using System;
using System.Collections.Generic;
using System.Text;

using Craze.Domain;

namespace Craze.Data.Abstract
{
    public interface IAnimalRepository
    {
        IList<Animal> GetAnimals();
        Animal GetAnimalById(int id);
        void InsertAnimal(Animal anAnimal);
    }
}
