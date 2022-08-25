using System;

namespace ZooSimulatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userChoice;
            ZooSimulatorHandler zooHandler = new ZooSimulatorHandler();

            Console.WriteLine("********************WELCOME TO ZOO STIMULATOR********************");
            Console.WriteLine("=================================================================\n");
            Console.WriteLine("1. Create Cage    2. Select Cage      3. Remove Cage      4. Exit");  

            do
            {
                Console.Write("\nPlease enter number to proceed: ");
                int.TryParse(Console.ReadLine(), out userChoice);

                switch (userChoice)
                {
                    case 1:
                        zooHandler.CreateCage();
                        break;
                    case 2:
                        zooHandler.SelectCage();    
                        break;
                    case 3:
                        zooHandler.RemoveCage();
                        break;
                    case 4:
                        Console.WriteLine("************************STIMULATOR CLOSED************************\n");
                        return;
                    default:
                        Console.WriteLine("Please enter valid number to proceed...\n");
                        break;
                }
            } while (userChoice != 4);
        }
    }
}