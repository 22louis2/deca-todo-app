using System;

namespace DecaTodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoApp todoApp = new TodoApp();

            Console.WriteLine("Type help to show options");

            Console.Write(">");

            string inputLine = Console.ReadLine();
            while (!inputLine.Equals("") && !inputLine.ToLower().Equals("exit"))
            {
                if (inputLine.StartsWith("Add "))
                {
                    string text = inputLine.Split(new[] { "Add " }, StringSplitOptions.None)[1];
                    todoApp.Add(text);
                }
                else if (inputLine.StartsWith("Do #"))
                {
                    try
                    {
                        int doNumber = int.Parse(inputLine.Split(new[] { "Do #" }, StringSplitOptions.None)[1]);
                        todoApp.Do(doNumber);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("A number must be specified to set a item to done.");
                    }
                }
                else if (inputLine.ToLower().Equals("print"))
                    todoApp.Print();
                else if (inputLine.ToLower().Equals("help"))
                    todoApp.Help();
                else
                    Console.WriteLine("Command not recognised, type help to see all options");

                Console.Write(">");
                inputLine = Console.ReadLine();
            }
        }
    }
}
