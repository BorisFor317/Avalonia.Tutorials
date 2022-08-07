using System.Collections.Generic;
using Avalonia.Todo.Models;

namespace Avalonia.Todo.Services;

public class Database
{
    public IEnumerable<TodoItem> GetTodoItems() => new[]
    {
        new TodoItem { Description = "Walk the dog" },
        new TodoItem { Description = "Bye some milk" },
        new TodoItem { Description = "Learn avalonia", IsCompleted = true },
    };
}