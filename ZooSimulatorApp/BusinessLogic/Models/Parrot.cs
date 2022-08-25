using System;
using System.Collections.Generic;
using System.Linq;
using ZooSimulatorApp.BusinessLogic.Events;
using ZooSimulatorApp.BusinessLogic.Interfaces;

namespace ZooSimulatorApp.BusinessLogic.Models
{
    internal class Parrot : HerbivoreAnimals, IIntelligenceAnimals
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public string Food { get; set; }
        public string Sound { get; set; }

        int animalBiteIndex;
        Dictionary<int, string> listAnimal = new Dictionary<int, string>();

        public void Mimic(string sound)
        {
            Console.WriteLine("\n" + listAnimal[animalBiteIndex] + " mimic sound..." + sound);
        }

        public override void Eat()
        {
            Console.WriteLine("\n" + listAnimal[animalBiteIndex] + " is eating...");
        }

        public void EatingTimeEventSubscriber(Cage cage, Dictionary<int, string> ListAnimal)
        {
            cage.CageHasFoodEvent += EatingTimeEventHandler;
            animalBiteIndex = ListAnimal.FirstOrDefault(x => x.Value.ToLower().Contains("parrot")).Key;
            listAnimal = ListAnimal;
        }

        private void EatingTimeEventHandler(object sender, Events.CageHasFoodEvent e)
        {
            CageHasFoodEvent cageHaveFoodEvent = e;
            Food = cageHaveFoodEvent.Food;
            LikeSeed = Food.ToLower().Trim() == "seed";

            if (LikeSeed) Eat();
        }

        public void BittenAnimalScreamEventSubscriber(Cage cage, Dictionary<int, string> ListAnimal)
        {
            cage.AnimalsMakeSoundEvent += BittenAnimalScreamEventHandler;
            animalBiteIndex = ListAnimal.FirstOrDefault(x => x.Value.ToLower().Contains("parrot")).Key;
            listAnimal = ListAnimal;
        }

        private void BittenAnimalScreamEventHandler(object sender, Events.AnimalsMakeSoundEvent e)
        {
            AnimalsMakeSoundEvent animalsMakeSoundEvent = e;
            Sound = animalsMakeSoundEvent.Sound;

            Mimic(Sound);
        }
    }
}