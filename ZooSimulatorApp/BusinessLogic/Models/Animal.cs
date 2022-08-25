using System.Collections.Generic;

namespace ZooSimulatorApp.BusinessLogic.Models
{
    internal abstract class Animal : IAnimalActions
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual void Bite(string bittenAnimal) { }

        public virtual void Eat() { }

        public virtual void Sleep() { }

        public virtual void Scream() { }
    }
}