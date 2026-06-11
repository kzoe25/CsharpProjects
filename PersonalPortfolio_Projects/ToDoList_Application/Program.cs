using System;
using System.Text;

namespace CuteTodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            TaskManager manager = new TaskManager();
            bool running = true;

            // Header matching your example image style
            Console.WriteLine("⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹");
            Console.WriteLine("⊹                                           ⊹");
            Console.WriteLine("⊹   ⊹° .✧* Welcome to Your Task Planner! ♡  ⊹");
            Console.WriteLine("⊹                                           ⊹");
            Console.WriteLine("⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹° .✧* ⊹");

            while (running)
            {
                Console.WriteLine("\n  ⊹─── MENU OPTIONS ───⊹  ");
                Console.WriteLine("  ✧  View My Tasks");
                Console.WriteLine("  ✧  Add a New Task");
                Console.WriteLine("  ✧  Complete / Remove a Task");
                Console.WriteLine("  ✧  Exit Planner");
                Console.Write("\nChoose an option (1-4): ");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        manager.ViewTasks();
                        break;

                    case "2":
                        Console.Write("\n⊹ What task would you like to add? ");
                        string newTask = Console.ReadLine() ?? string.Empty;
                        manager.AddTask(newTask);
                        break;

                    case "3":
                        manager.RemoveTask();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("\n⊹° .✧* Thanks for using your planner! Bye-bye! ♡ ⊹° .✧*");
                        break;

                    default:
                        Console.WriteLine("\n[!] Please type a number between 1 and 4.");
                        break;
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}