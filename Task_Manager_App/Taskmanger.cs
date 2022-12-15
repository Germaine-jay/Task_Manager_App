using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Manager_App
{
    internal class Taskmanger: Controls
    {
        public static ArrayList ListOfProcesses = new ArrayList();
        public static void TaskList()
        {
            foreach (Process process in Process.GetProcesses())
            {
                ListOfProcesses.Add(process.ProcessName);
            }
        }
        public static void GetTaskList()
        {
            var listOfProcesses = from proc in Process.GetProcesses()
                                  orderby proc.Id
                                  select proc;

            foreach (Process process in listOfProcesses)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    Console.WriteLine("Process:   {0} \n ID   : {1} \n Title: {2} \n", process.ProcessName, process.Id, process.MainWindowTitle);
                    ListOfProcesses.Add(process.ProcessName);
                }
            } 
        }
        public static void StartNewTask()
        {
            Console.WriteLine("Enter Application Name");
            var Name = Console.ReadLine().Replace(" ", "").ToLower();

            Process process = null;
            try
            {
                process = Process.Start($"{Name}");
            }
            catch (FormatException ex)
            {
                Console.Write("Not a valid format. Please try again.");
                SpaceOption();
                StartNewTask();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid input {Name}, please enter correct file name");
                SpaceOption();
                StartNewTask();
            }
        }
        public static void KillRunningTask()
        {
            bool Validate = true;
            while (Validate)
            {
                Console.WriteLine("Are You Sure you want to close an app....y/n");

                var Option = Console.ReadLine();
                switch (Option)
                {
                    case "y":
                        KillTask();
                        break;
                    case "n":
                        Validate = false;
                        break;
                    default:
                        InvalidInput();
                        KillRunningTask();
                        break;
                }
            }

        }
        public static void KillTask()
        {
            Console.WriteLine("Enter the app name you want to close");
            string Task = Console.ReadLine().ToLower();

            if (ListOfProcesses.Contains(Task))
            {
                foreach (var task in Process.GetProcessesByName(Task))
                {
                    task.Kill();
                }
            }         
            else if(string.IsNullOrEmpty(Task))
            {
                ClearOption();
                Console.WriteLine("Input cannot be empty\n Try Again...\n");
                KillTask();
            }
            else if(int.TryParse(Task, out _) && Task.Any(character => char.IsDigit(character)))
            {
                ClearOption();
                Console.WriteLine("Input cannot contain digit\n Try Again...\n");
                KillTask();
            }

        }
    }

    class CustomTaskManager:Controls
    {
        public static void CustomTask()
        {
            Process _proc = null;
            try
            {
                int i = 0;
                ProcessStartInfo process = new ProcessStartInfo(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "www.instagram.com");

                foreach (var verb in process.Verbs)
                {
                    Console.WriteLine($"{i++}. {verb}");
                }

                process.WindowStyle = ProcessWindowStyle.Normal;
                process.Verb = "open";
                process.UseShellExecute = true;

                _proc = Process.Start(process);

            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("-> Hit Enter to exit {0}...", _proc.ProcessName);
            Console.ReadLine();

            try
            {
                foreach (var process in Process.GetProcessesByName("chrome"))
                {
                    process.Kill();
                }

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void ThreadIsAliveOrBackground()
        {
            AliveOrBackgroundOption();
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    IsAlive();
                    break;
                case "2":
                    IsBackground();
                    break;
                default:
                    InvalidInput();
                    ThreadIsAliveOrBackground();
                    break;

            }
        }
        private static void IsAlive()
        {
            bool isAlive = Thread.CurrentThread.IsAlive;
            Console.WriteLine(isAlive ? "Process is Alive\n" : "Process not Alive\n");
        }
        private static void IsBackground()
        {
            bool isBackground = Thread.CurrentThread.IsBackground;
            Console.WriteLine(isBackground ? "background thread\n" : "Not a background thread\n");
        }
    }
}
