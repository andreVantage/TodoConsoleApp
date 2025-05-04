using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;
namespace Todo.Services
{
    public class TodoService
    {
        public static List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
        public static void AddTodoItem(TodoItem item)
        {
            TodoItems.Add(item);
        }
        public  void RemoveTodoItem(int id)
        {
            var item = TodoItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                TodoItems.Remove(item);
            }
        }
        public  void UpdateTodoItem(int id, TodoItem updatedItem)
        {
            var item = TodoItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Title = updatedItem.Title;
                item.Description = updatedItem.Description;
                item.IsCompleted = updatedItem.IsCompleted;
            }
        }
        public List<TodoItem> GetTodoItems()
        {
            return TodoItems;
        } 
    }
}
