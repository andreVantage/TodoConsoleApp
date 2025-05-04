using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Services;

namespace Todo.BLL
{
    public  class TodoBLL
    {
        private static readonly TodoService todoService = new TodoService();
        public  string AddNewTodo()
        {
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("Enter Title:");
                string? title = Console.ReadLine();
                Console.WriteLine("Enter Description:");
                string? description = Console.ReadLine();


                TodoService.AddTodoItem(new Entities.TodoItem
                {
                    Id = todoService.GetTodoItems().Count + 1,
                    Title = title ?? string.Empty,
                    Description = description ?? string.Empty,
                    IsCompleted = false
                });

                Console.WriteLine("Do you want to add more? (Yes | No)");
                string? addMore = Console.ReadLine()?.Trim().ToLower();
                isContinue = addMore == "yes";
            }
            Console.Clear();
            return "Todo item(s) added successfully.";
        }


        public  void ViewTodo()
        {
            Console.WriteLine("\nTodo List:");
            if (todoService.GetTodoItems().Count == 0)
            {
                Console.WriteLine("No Todo items found.");
            }
            else
            {
                foreach (var item in todoService.GetTodoItems())
                {
                    Console.WriteLine($"Id: {item.Id}");
                    Console.WriteLine($"Title: {item.Title}");
                    Console.WriteLine($"Description: {item.Description}");
                    Console.WriteLine($"IsCompleted: {item.IsCompleted}");
                }
            }
        }

        public  void DeleteTodo()
        {
            Console.WriteLine("\nEnter the ID of the Todo item to delete:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                todoService.RemoveTodoItem(id);
                Console.WriteLine("Todo item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please try again.");
            }
        }

        public  void UpdateTodo()
        {
            Console.WriteLine("\nEnter the ID of the Todo item to update:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Enter new Title:");
                string? title = Console.ReadLine();
                Console.WriteLine("Enter new Description:");
                string? description = Console.ReadLine();
                Console.WriteLine("Is the Todo item completed? (true/false):");
                bool isCompleted = bool.Parse(Console.ReadLine() ?? "false");
                todoService.UpdateTodoItem(id, new Entities.TodoItem
                {
                    Id = id,
                    Title = title ?? string.Empty,
                    Description = description ?? string.Empty,
                    IsCompleted = isCompleted
                });
                Console.WriteLine("Todo item updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please try again.");
            }
        }
    }
}

