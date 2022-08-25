using System;
using System.Collections.Generic;
using System.Linq;
using ZooSimulatorApp.BusinessLogic.Constants;
using ZooSimulatorApp.BusinessLogic.Events;
using ZooSimulatorApp.BusinessLogic.Interfaces;

namespace ZooSimulatorApp.BusinessLogic.Models
{
    internal class Wolf : CarnivoreAnimals, IGluttonyAnimals
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public string Food { get; set; }

        int animalBiteIndex;
        Dictionary<int, string> listAnimal = new Dictionary<int, string>();

        public void ContendForFood()
        {
            Cage cage = new Cage();
            Monkey monkey = new Monkey();
            Parrot parrot = new Parrot();
            Random rand = new Random();
            string bittenAnimal = listAnimal.ElementAt(rand.Next(0, listAnimal.Count)).Value;
            string typeOfBittenAnimal = bittenAnimal.Split(' ').First();
            animalBiteIndex = listAnimal.FirstOrDefault(x => x.Value.ToLower().Contains("wolf")).Key;

            Bite(bittenAnimal);

            switch (typeOfBittenAnimal.ToLower().Trim())
            {
                case "monkey":
                    Console.WriteLine("\n" + bittenAnimal + " yield..." + AnimalSoundConstants.MONKEY_SOUND);
                    
                    parrot.BittenAnimalScreamEventSubscriber(cage, listAnimal);
                    cage.BittenAnimalScreamEventPublisher(AnimalSoundConstants.MONKEY_SOUND);
                    break;
                case "parrot":
                    Console.WriteLine("\n" + bittenAnimal + " yield..." + AnimalSoundConstants.PARROT_SOUND);

                    monkey.BittenAnimalScreamEventSubscriber(cage, listAnimal);
                    cage.BittenAnimalScreamEventPublisher(AnimalSoundConstants.PARROT_SOUND);
                    break;
                case "pig":
                    Console.WriteLine("\n" + bittenAnimal + " yield..." + AnimalSoundConstants.PIG_SOUND);

                    monkey.BittenAnimalScreamEventSubscriber(cage, listAnimal);
                    parrot.BittenAnimalScreamEventSubscriber(cage, listAnimal);
                    cage.BittenAnimalScreamEventPublisher(AnimalSoundConstants.PIG_SOUND);
                    break;
                case "wolf":
                    Console.WriteLine("\n" + bittenAnimal + " yield..." + AnimalSoundConstants.WOLF_SOUND);

                    monkey.BittenAnimalScreamEventSubscriber(cage, listAnimal);
                    parrot.BittenAnimalScreamEventSubscriber(cage, listAnimal);
                    cage.BittenAnimalScreamEventPublisher(AnimalSoundConstants.WOLF_SOUND);
                    break;
            }
        }

        public override void Bite(string bittenAnimal)
        {
            Console.WriteLine("\n" + listAnimal[animalBiteIndex] + " bit " + bittenAnimal + " ...");
        }

        public override void Eat()
        {
            Console.WriteLine("\n" + listAnimal[animalBiteIndex] + " is eating...");
        }

        public void EatingTimeEventSubscriber(Cage cage, Dictionary<int, string> ListAnimal)
        {
            cage.CageHasFoodEvent += EatingTimeEventHandler;
            listAnimal = ListAnimal;
        }

        private void EatingTimeEventHandler(object sender, Events.CageHasFoodEvent e)
        {
            CageHasFoodEvent cageHaveFoodEvent = e;
            Food = cageHaveFoodEvent.Food;
            LikeMeat = Food.ToLower().Trim() == "meat";

            if (LikeMeat)
            {
                ContendForFood();
                Eat();
            }
        }
    }
}