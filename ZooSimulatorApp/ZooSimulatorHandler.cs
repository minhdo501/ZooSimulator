using System;
using System.Collections.Generic;
using System.Linq;
using ZooSimulatorApp.BusinessLogic.Models;

namespace ZooSimulatorApp
{
    internal class ZooSimulatorHandler
    {
        int count;

        Dictionary<string, string> ListCage = new Dictionary<string, string>();
        Dictionary<int, string> ListAnimal = new Dictionary<int, string>
        {
            {1, "Monkey Molley"},
            {2, "Parrot Dona"},
            {3, "Pig Michael"},
            {4, "Wolf Scar"}
        };

        #region Cage Methods
        public void CreateCage()
        {
            Cage cage = new Cage();

            Console.Write("Please enter Cage ID: ");
            cage.Id = Console.ReadLine();

            if (!ListCage.ContainsKey(cage.Id))
            {
                Console.Write("Please enter Cage Name: ");
                cage.Name = Console.ReadLine();

                ListCage.Add(cage.Id, cage.Name);
                Console.WriteLine("\nList of available cages: ");
                ViewCages();
            }
            else Console.WriteLine("Cage with this ID already existed");
        }

        public void RemoveCage()
        {
            Console.Write("Please enter Cage ID to remove: ");
            string cageId = Console.ReadLine();

            foreach (var cageElement in ListCage)
            {
                if (cageElement.Key.Equals(cageId))
                {
                    ListCage.Remove(cageElement.Key);
                    break;
                }
                else Console.Write("Not found any cages with Cage ID '{0}'\n", cageId);
            }
            ViewCages();
        }

        public void SelectCage()
        {
            if (ListCage.Count > 0)
            {
                Console.Write("Please enter Cage ID to show animals: ");
                string cageId = Console.ReadLine();

                if (ListCage.ContainsKey(cageId))
                {
                    int userChoice;
                    Console.WriteLine("==================================================================\n");
                    Console.WriteLine("WELCOME TO CAGE {0}, HERE YOU CAN:", ListCage[cageId]);
                    Console.WriteLine("1. Add Animal     2. Remove Animal     3. Feed Animal      0. Exit");
                    ViewAnimals();

                    do
                    {
                        Console.Write("\nPlease enter number to proceed: ");
                        int.TryParse(Console.ReadLine(), out userChoice);

                        switch (userChoice)
                        {
                            case 1:
                                AddAnimal();
                                break;
                            case 2:
                                RemoveAnimal();
                                break;
                            case 3:
                                FeedAnimal();
                                break;
                            case 0:
                                Console.WriteLine("================================================================\n");
                                Console.WriteLine("1. Create Cage    2. Select Cage     3. Remove Cage      4. Exit");
                                return;
                            default:
                                Console.Write("Please enter valid number to proceed...");
                                break;
                        }
                    } while (userChoice != 0);
                }
                else Console.Write("Not found any cages with Cage ID '{0}'\n", cageId);

            }
            else Console.Write("No cages available...\n");
        }

        private void ViewCages()
        {
            Console.WriteLine("\nList of available cages: ");

            foreach (var cage in ListCage)
                Console.WriteLine(cage.Key + ". " + cage.Value);

            if (ListCage.Count == 0) Console.WriteLine("No cages available...");
        }
        #endregion

        #region Animal Methods
        private void AddAnimal()
        {
            Console.Write("Which type of animal would you like to add into cage: ");
            Console.WriteLine("(Monkey/Parrot/Pig/Wolf)");
            string typeOfAnimal = Console.ReadLine();

            switch (typeOfAnimal.ToLower().Trim())
            {
                case "monkey":
                    AddMonkey();
                    break;
                case "parrot":
                    AddParrot();
                    break;
                case "pig":
                    AddPig();
                    break;
                case "wolf":
                    AddWolf();
                    break;
                default:
                    Console.WriteLine("Please enter valid type of animal...");
                    break;
            }
        }

        private void AddMonkey()
        {
            if (ListAnimal.Count > 0) count = ListAnimal.Keys.Max() + 1;
            else count = 1;

            Monkey monkey = new Monkey();
            monkey.Id = count;
            Console.Write("Name of monkey: ");
            monkey.Name = Console.ReadLine();

            ListAnimal.Add(count, "Monkey " + monkey.Name);
            ViewAnimals();
        }

        private void AddParrot()
        {
            if (ListAnimal.Count > 0) count = ListAnimal.Keys.Max() + 1;
            else count = 1;

            Parrot parrot = new Parrot();
            parrot.Id = count;
            Console.Write("Name of parrot: ");
            parrot.Name = Console.ReadLine();

            ListAnimal.Add(count, "Parrot " + parrot.Name);
            ViewAnimals();
        }

        private void AddPig()
        {
            if (ListAnimal.Count > 0) count = ListAnimal.Keys.Max() + 1;
            else count = 1;

            Pig pig = new Pig();
            pig.Id = count;
            Console.Write("Name of parrot: ");
            pig.Name = Console.ReadLine();

            ListAnimal.Add(count, "Pig " + pig.Name);
            ViewAnimals();
        }

        private void AddWolf()
        {
            if (ListAnimal.Count > 0) count = ListAnimal.Keys.Max() + 1;
            else count = 1;

            Wolf wolf = new Wolf();
            wolf.Id = count;
            Console.Write("Name of parrot: ");
            wolf.Name = Console.ReadLine();

            ListAnimal.Add(count, "Wolf " + wolf.Name);
            ViewAnimals();
        }

        private void ViewAnimals()
        {
            Console.WriteLine("\nList of available animals: ");

            foreach (var animal in ListAnimal)
                Console.WriteLine(animal.Key + ". " + animal.Value);

            if (ListAnimal.Count == 0) Console.WriteLine("No animals available...");
        }

        private void RemoveAnimal()
        {
            int animalIndex;

            Console.Write("Please enter animal number to remove: ");
            int.TryParse(Console.ReadLine(), out animalIndex);

            foreach (var animal in ListAnimal)
            {
                if (animal.Key.Equals(animalIndex))
                {
                    ListAnimal.Remove(animalIndex);
                    break;
                }
                else Console.WriteLine("No animal found!");
            }
            ViewAnimals();
        }

        private void FeedAnimal()
        {
            Console.Write("Enter 'Seed' to feed animals with Seed, or 'Meat' to feed animals with Meat: ");
            string typeOfFood = Console.ReadLine();
            Cage cage = new Cage();
            Monkey monkey = new Monkey();
            Pig pig = new Pig();

            switch (typeOfFood.ToLower().Trim())
            {
                case "meat":
                    Wolf wolf = new Wolf();

                    wolf.EatingTimeEventSubscriber(cage, ListAnimal);
                    pig.EatingTimeEventSubscriber(cage, ListAnimal);
                    monkey.EatingTimeEventSubscriber(cage, ListAnimal);
                    cage.EatingTimeEventPublisher(typeOfFood);
                    break;
                case "seed":
                    Parrot parrot = new Parrot();

                    parrot.EatingTimeEventSubscriber(cage, ListAnimal);
                    pig.EatingTimeEventSubscriber(cage, ListAnimal);
                    monkey.EatingTimeEventSubscriber(cage, ListAnimal);
                    cage.EatingTimeEventPublisher(typeOfFood);
                    break;
                default:
                    Console.WriteLine("Please feed animals with proper food!");
                    break;
            }
        }
        #endregion
    }
}