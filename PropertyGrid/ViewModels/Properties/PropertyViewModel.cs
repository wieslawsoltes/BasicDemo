using System;
using System.Collections.Generic;
using AvaloniaBasic.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels.Properties;

public abstract partial class PropertyViewModel : ObservableObject, IProperty
{
    [ObservableProperty] private string? _name;
    [ObservableProperty] private object? _value;
    [ObservableProperty] private object? _defaultValue;
    [ObservableProperty] private bool _isExpanded = true;
    [ObservableProperty] private bool _isDirty;

    public abstract Type GetValueType();

    public abstract bool IsReadOnly();

    public abstract bool IsEditable();

    public virtual bool HasChildren => false;

    public virtual IEnumerable<IProperty>? GetChildren() => null;
}
