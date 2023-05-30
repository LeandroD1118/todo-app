using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();
    static List<bool> completed = new List<bool>();

    static void Main()
    {
        string input = "";
        while (input != "exit")
        {
            Console.Clear();
            Console.WriteLine("Enter a command (list, add, complete, delete, filter, exit):");
            input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "list":
                    ListTasks();
                    break;
                case "add":
                    AddTask();
                    break;
                case "complete":
                    CompleteTask();
                    break;
                case "delete":
                    DeleteTask();
                    break;
                case "filter":
                    FilterTasks();
                    break;
                case "exit":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void ListTasks()
    {
        Console.WriteLine("Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (!completed[i])
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("Enter a new task:");
        string task = Console.ReadLine();
        tasks.Add(task);
        completed.Add(false);
        Console.WriteLine("Task added successfully.");
    }

    static void CompleteTask()
    {
        Console.WriteLine("Enter the index of the task to complete:");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        if (index >= 0 && index < tasks.Count)
        {
            if (!completed[index])
            {
                completed[index] = true;
                Console.WriteLine("Task completed.");
            }
            else
            {
                Console.WriteLine("Task is already completed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    static void DeleteTask()
    {
        Console.WriteLine("Enter the index of the task to delete:");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
            completed.RemoveAt(index);
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Invalid task index.");
        }
    }

    static void FilterTasks()
    {
        Console.WriteLine("Enter the status (completed/active/all):");
        string status = Console.ReadLine().ToLower();

        Console.WriteLine("Filtered Tasks:");
        switch (status)
        {
            case "completed":
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (completed[i])
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                }
                break;
            case "active":
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (!completed[i])
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                    }
                }
                break;
            case "all":
                ListTasks();
                break;
            default:
                Console.WriteLine("Invalid status. Please try again.");
                break;
        }
    }
}
