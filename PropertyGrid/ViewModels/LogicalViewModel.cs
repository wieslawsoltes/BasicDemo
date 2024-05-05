using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.LogicalTree;
using AvaloniaBasic.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels;

public partial class LogicalViewModel : ObservableObject, ITreeItem<LogicalViewModel>
{
    [ObservableProperty] private string? _name;
    [ObservableProperty] private bool _isExpanded;
    [ObservableProperty] private ILogical? _logical;
    [ObservableProperty] private ObservableCollection<LogicalViewModel>? _children;

    public bool HasChildren => Children?.Count > 0;

    public IEnumerable<LogicalViewModel>? GetChildren() => Children;
}
