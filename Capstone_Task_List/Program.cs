using System;
using System.Collections.Generic;


namespace Capstone_Task_List
{
    class Program
    {

        static void Main(string[] args)
        {
            
            List<Tasking> tasks = new List<Tasking>();
            while (true)
            {
                Console.WriteLine("Welcome to the Task Manager!");
                Console.WriteLine("1) There are currently " + tasks.Count + " tasks. ");
                Console.WriteLine("2) Add task");
                Console.WriteLine("3) Remove task");
                Console.WriteLine("4) Mark task complete");
                Console.WriteLine("5) Quit");
                string input = Console.ReadLine();
                try
                {
                    int pick = int.Parse(input);
                    if (1 <= pick && pick <= 5)
                    {
                        if (pick == 1)
                        {
                            PrintList(tasks);
                        }
                        else if (pick == 2)
                        {
                            AddTask(tasks);
                        }
                        else if (pick == 3)
                        {
                            RemoveTask(tasks);
                        }
                        else if (pick == 4)
                        {
                            //Console.WriteLine("Please input a task that you have completed.");
                            //string task = Console.ReadLine();
                            TaskComplete(tasks);
                        }
                        else if (pick == 5)
                        {
                            Console.WriteLine("Thank you for using the Task Manager.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input number: " + pick + " was not in between 1 and 5");
                        Console.WriteLine("Please press any key to try again");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The input " + input + " was not in the format expected");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            
        }
        public static void PrintList(List<Tasking> tasks)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.Write($"{i + 1}: ");
                tasks[i].PrintTasks();
            }
           
        }
        public static List<Tasking> AddTask(List<Tasking> tasks)
        {
            Console.WriteLine("Ah you want to add a task! Please input the name of the team member performing said task.");
            string name = Console.ReadLine();

            Tasking newtask = new Tasking();
            newtask.Name = name;
            Console.WriteLine("Please input description.");
            newtask.Description = Console.ReadLine();
            //newtask.Completed
            tasks.Add(newtask);
            Console.WriteLine("When is this task due? (mm/dd/yyy 12:00:00 format appreciated)");
            DateTime duetime = DateTime.Parse(Console.ReadLine());
            return tasks;
        }

        public static void RemoveTask(List<Tasking> tasks)
        {
            Console.WriteLine("Whick task would you like to delete? Select a number from the list below: ");
            Console.WriteLine();
            PrintList(tasks); 
          
            string completeTask = Console.ReadLine();
            bool success = int.TryParse(completeTask, out int selection);
            selection -= 1;

            if (success)
            {
                if (selection >= 0 && selection <= tasks.Count)
                {
                    tasks.Remove(tasks[selection]);
                    Console.WriteLine("These are the tasks: ");
                    PrintList(tasks);
                }
                else
                {
                    Console.WriteLine("I'm sorry, a task with a number");
                }
            }
            else
            {
                Console.WriteLine("I'm looking for an integer");
            }
        }
        public static void TaskComplete(List<Tasking> tasks)
        {
            Console.WriteLine("Please input a task you've completed, select a number from the list: ");
            PrintList(tasks);
            string completeTask = Console.ReadLine();
            bool success = int.TryParse(completeTask, out int selection);
            
            selection -= 1;
            if (success)
            {
                if (selection >= 0 && selection <= tasks.Count)
                {
                    tasks[selection].Completed = true;
                    tasks[selection].PrintTasks();
                }
                else
                {
                    Console.WriteLine("Please use a task with a number.");
                }
            }
            else
            {
                Console.WriteLine("That was not what I was looking for!");
            }


        }


    }
}


