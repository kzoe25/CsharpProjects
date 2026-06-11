using System;
using System.Collections.Generic;

namespace CuteTodoListApp
{
    public class TaskManager
    {
        private List<string> todoList = new List<string>();

        public void ViewTasks()
        {
            // Clean text borders replacing the ribbon emojis
            Console.WriteLine("\n⊹─── YOUR TASK LIST ───⊹");
            if (todoList.Count == 0)
            {
                // Clean stars replacing the paw print and sparkle emojis
                Console.WriteLine("  ✧  No tasks yet! Your schedule is clear. ♡");
            }
            else
            {
                for (int i = 0; i < todoList.Count; i++)
                {
                    Console.WriteLine($"  ✧  {i + 1}. {todoList[i]}");
                }
            }
            Console.WriteLine("⊹──────────────────────⊹");
        }

        public void AddTask(string task)
        {
            if (!string.IsNullOrWhiteSpace(task))
            {
                todoList.Add(task);
                Console.WriteLine($"\n⊹ Added: \"{task}\" to your list! ✧");
            }
            else
            {
                Console.WriteLine("\n[!] Task cannot be completely empty!");
            }
        }

        public void RemoveTask()
        {
            Console.WriteLine("\n⊹─── REMOVE A TASK ───⊹");
            if (todoList.Count == 0)
            {
                Console.WriteLine("  ✧  There are no tasks left to clear!");
                return;
            }

            for (int i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine($"  [{i + 1}] {todoList[i]}");
            }

            Console.Write("\nEnter the task number to complete: ");
            string indexInput = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(indexInput, out int targetIndex) && targetIndex >= 1 && targetIndex <= todoList.Count)
            {
                string removedTask = todoList[targetIndex - 1];
                todoList.RemoveAt(targetIndex - 1);
                Console.WriteLine($"\n♡ Success! You completed: \"{removedTask}\" ✧");
            }
            else
            {
                Console.WriteLine("\n[!] Invalid selection! Please enter a number from the list.");
            }
        }
    }
}