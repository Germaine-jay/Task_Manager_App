using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_App
{
    internal class Controls
    {
        protected static void ClearOption()
        {
            Console.Clear();
        }
        protected static void InvalidInput()
        {
            Console.WriteLine("Invalid Input\n");
        }
        protected static void SpaceOption()
        {
            Console.WriteLine();
        }
        protected static void BackToMenu()
        {
            Console.WriteLine("Go back to main menu?....y/n");
            var option = Console.ReadLine().ToLower();
            switch (option)
            {
                case "y":
                    ClearOption();
                    Landingpage.MainMenu();
                    break;
                case "n": break;
                default:
                    Console.WriteLine("\ninvalid input\n");
                    BackToMenu();
                    return;
            }
        }
        protected static void MainMenuOption()
        {
            Console.WriteLine("Enter:\n1- View List of Running Processes \n2- Start A New Process \n3- Kill An Existing Process\n4- Start A New Custom Process");
            Console.WriteLine("5- Check if Thread is alive or Background\n");
        }
        protected static void AliveOrBackgroundOption()
        {
            Console.WriteLine("Enter:\n1- To check if Thread is Alive \n2- To check if Thread is Background");
        }
    }
}
