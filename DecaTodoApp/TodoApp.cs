using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DecaTodoApp
{
    public class TodoApp
    {
        private string fileLocation = "todo-todoItems.txt";
        private readonly List<TodoItem> todoItems = new List<TodoItem>();
        private readonly string helpOutput = @"Options
            Add [item]      Add a item to the todo application
            Do #[number]    Complete a given item
            Print           Print all todo items
            Help            Show all possible options
            Exit            Exit the command line application";

        public TodoApp()
        {
            LoadItems();
        }

        private void LoadItems()
        {
            if (File.Exists(fileLocation))
            {
                string[] lines = File.ReadAllLines(fileLocation);
                foreach (string line in lines)
                {
                    int number = int.Parse(line[1..].Split(' ')[0]);
                    string text = line[1..].Split(' ')[1];
                    TodoItem newItem = new TodoItem(number, text);
                    todoItems.Add(newItem);
                }
            }
        }

        private void SaveItems()
        {
            List<string> allTodoItems = new List<string>();
            foreach (TodoItem item in todoItems)
            {
                allTodoItems.Add(item.ToString());
            }

            File.WriteAllLines(fileLocation, allTodoItems);
        }

        public void Add(string text)
        {
            int newNumber = 1;
            if (todoItems.Count > 0)
                newNumber = todoItems.ElementAt(todoItems.Count - 1).Number + 1;

            TodoItem newTodoItem = new TodoItem(newNumber, text);
            todoItems.Add(newTodoItem);
            Console.WriteLine(newTodoItem);
            SaveItems();
        }

        public void Do(int number)
        {
            bool found = false;
            foreach (TodoItem todoItem in todoItems)
            {
                if (todoItem.Number == number)
                {
                    Console.WriteLine("Completed " + todoItem);
                    found = true;
                    todoItems.Remove(todoItem);
                    SaveItems();
                    break;
                }
            }

            if (!found)
                Console.WriteLine("Could not find a item with the specified number");
        }

        public void Print()
        {
            if (todoItems.Count == 0)
                Console.WriteLine("There is no todoItems in list");
            else
            {
                foreach(TodoItem todoItem in todoItems)
                    Console.WriteLine(todoItem);
            }
        }

        public void Help()
        {
            Console.WriteLine(helpOutput);
        }

        public void UseTestEnvironment()
        {
            fileLocation = "todo-todoItems-test.txt";
            todoItems.Clear();
        }
    }
}
