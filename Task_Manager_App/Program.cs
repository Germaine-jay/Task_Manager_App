using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Landingpage.MenuOption();
            Taskmanger.TaskList();
            Landingpage.MainMenu();
        }
    }
}
