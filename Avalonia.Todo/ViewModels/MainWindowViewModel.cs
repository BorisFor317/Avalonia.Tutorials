using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Todo.Models;
using Avalonia.Todo.Services;
using ReactiveUI;

namespace Avalonia.Todo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public TodoListViewModel TodoListViewModel { get; }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        private ViewModelBase _content;

        public MainWindowViewModel(Database database)
        {
            Content = TodoListViewModel = new TodoListViewModel(database.GetTodoItems());
        }

        public void AddItem()
        {
            var addItemViewModel = new AddItemViewModel();
            addItemViewModel.Ok
                .Subscribe(todoItem =>
                {
                    TodoListViewModel.Items.Add(todoItem);
                    Content = TodoListViewModel;
                });
            addItemViewModel.Cancel
                .Subscribe(_ => Content = TodoListViewModel);
            
            Content = addItemViewModel;
        }
    }
}