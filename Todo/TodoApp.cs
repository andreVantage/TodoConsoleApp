using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Todo.Services;
using System.Collections.Generic;
using System.ComponentModel;
using Todo.BLL;
namespace Todo
{
    public class TodoApp
    {
        private static readonly TodoBLL todoBLL = new TodoBLL();
        public enum Choices
        {
            Add = 1,
            View,
            Update,
            Delete,
            Exit
        }
        public static void Run()
        {


            try
            {
                while (true)
                {
                    Console.WriteLine("Welcome to Todo List Application");

                    Console.WriteLine("\n Menu:");
                    foreach (var choice in Enum.GetValues(typeof(Choices)))
                    {
                        Console.WriteLine($"{(int)choice}. {choice}");
                    }

                    Console.WriteLine("Choices");
                    if (int.TryParse(Console.ReadLine(), out int choiceInput) && Enum.IsDefined(typeof(Choices), choiceInput))
                    {
                        Choices selectedChoice = (Choices)choiceInput;

                        switch (selectedChoice)
                        {
                            case Choices.Add:
                                Console.Clear();
                                todoBLL.AddNewTodo();
                                break;
                            case Choices.View:
                                Console.Clear();
                                todoBLL.ViewTodo();
                                break;
                            case Choices.Update:
                                Console.Clear();
                                todoBLL.UpdateTodo();
                                break;
                            case Choices.Delete:
                                Console.Clear();
                                todoBLL.DeleteTodo();
                                break;
                            case Choices.Exit:
                                Console.WriteLine("Exiting the application.");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Thank you for using the Todo List Application.");

            }
        }



    }
}
