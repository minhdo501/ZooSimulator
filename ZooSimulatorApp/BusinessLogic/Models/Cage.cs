using System;
using ZooSimulatorApp.BusinessLogic.Events;

namespace ZooSimulatorApp.BusinessLogic.Models
{
    internal class Cage
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public event EventHandler<CageHasFoodEvent> CageHasFoodEvent;

        public event EventHandler<AnimalsMakeSoundEvent> AnimalsMakeSoundEvent;

        public void EatingTimeEventPublisher(string food)
        {
            CageHasFoodEvent?.Invoke(this, new CageHasFoodEvent(food));
        }

        public void BittenAnimalScreamEventPublisher(string sound)
        {
            AnimalsMakeSoundEvent?.Invoke(this, new AnimalsMakeSoundEvent(sound));
        }
    }
}