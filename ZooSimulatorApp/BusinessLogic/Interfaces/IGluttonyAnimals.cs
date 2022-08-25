using ZooSimulatorApp.BusinessLogic.Models;

namespace ZooSimulatorApp.BusinessLogic.Interfaces
{
    internal interface IGluttonyAnimals : IAnimalActions
    {
        void ContendForFood();
    }
}