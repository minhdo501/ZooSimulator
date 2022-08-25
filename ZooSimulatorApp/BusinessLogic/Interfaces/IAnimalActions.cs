using System.Collections.Generic;

namespace ZooSimulatorApp.BusinessLogic.Models
{
    internal interface IAnimalActions
    {
        void Bite(string bittenAnimal);
        void Eat();
        void Sleep();
    }
}