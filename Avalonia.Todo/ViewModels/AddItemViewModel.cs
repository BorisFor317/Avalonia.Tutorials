using System.Reactive;
using Avalonia.Todo.Models;
using ReactiveUI;

namespace Avalonia.Todo.ViewModels;

public class AddItemViewModel : ViewModelBase
{
    public AddItemViewModel()
    {
        var okEnabled = this.WhenAnyValue(
            x => x.Description,
            x => !string.IsNullOrWhiteSpace(x)
        );
        Ok = ReactiveCommand.Create(
            () => new TodoItem { Description = Description },
            okEnabled
        );
        Cancel = ReactiveCommand.Create(() => { });
    }

    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    public ReactiveCommand<Unit, TodoItem> Ok { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }

    private string _description = string.Empty;
}