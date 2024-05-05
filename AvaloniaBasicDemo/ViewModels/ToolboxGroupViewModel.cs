using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaBasic.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels;

public partial class ToolboxGroupViewModel : ToolboxItemViewModel, IToolboxGroup
{
    [ObservableProperty] private ObservableCollection<IToolboxItem>? _items;

    public ToolboxGroupViewModel()
    {
        IsExpanded = true;
    }

    public override bool HasChildren => Items?.Count > 0;

    public override IEnumerable<IToolboxItem>? GetChildren() => Items;
}
