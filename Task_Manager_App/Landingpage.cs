using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_App
{
    internal class Landingpage: Controls
    {
        public static void MenuOption()
        {
            Console.WriteLine("*************\nWelcome to germaine task manager\n*************\n");
        }
        public static void MainMenu()
        {
            MainMenuOption();
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Taskmanger.GetTaskList();
                    BackToMenu();
                    break;
                case "2":
                    Taskmanger.StartNewTask();
                    SpaceOption();
                    MainMenu();
                    break;
                case "3":
                    Taskmanger.KillRunningTask();
                    BackToMenu();
                    break;
                case "4":
                    ClearOption();
                    CustomTaskManager.CustomTask();
                    BackToMenu();
                    break;
                case "5":
                    CustomTaskManager.ThreadIsAliveOrBackground();
                    BackToMenu();
                    break;
                default: InvalidInput();
                    BackToMenu();
                    break ;
            }
        }
    }
}
