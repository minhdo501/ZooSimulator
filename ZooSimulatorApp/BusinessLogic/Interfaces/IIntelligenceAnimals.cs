using ZooSimulatorApp.BusinessLogic.Models;

namespace ZooSimulatorApp.BusinessLogic.Interfaces
{
    internal interface IIntelligenceAnimals : IAnimalActions
    {
        void Mimic(string sound);
    }
}