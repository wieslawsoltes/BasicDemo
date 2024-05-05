using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaBasic.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels.Properties;

public partial class GroupPropertyViewModel : PropertyViewModel
{
    [ObservableProperty] private ObservableCollection<IProperty>? _children;

    public override bool HasChildren => Children?.Count > 0;

    public override IEnumerable<IProperty>? GetChildren() => Children;

    public override Type GetValueType()
    {
        return typeof(string);
    }

    public override bool IsReadOnly()
    {
        return true;
    }

    public override bool IsEditable()
    {
        return false;
    }
}
