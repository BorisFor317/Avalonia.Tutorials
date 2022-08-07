using System.Collections.Generic;
using Avalonia.Todo.Models;
using DynamicData.Binding;

namespace Avalonia.Todo.ViewModels;

public class TodoListViewModel : ViewModelBase
{
    public IObservableCollection<TodoItem> Items { get; }

    public TodoListViewModel(IEnumerable<TodoItem> items)
    {
        Items = new ObservableCollectionExtended<TodoItem>(items);
    }
}