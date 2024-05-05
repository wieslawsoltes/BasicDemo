using System;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using AvaloniaBasic.Model;

namespace AvaloniaBasic.Services.PropertyEditors;

public class EnumPropertyEditor : IPropertyEditor
{
    public bool Match(IProperty property)
    {
        var type = property.GetValueType();

        return type.IsEnum;
    }

    public object Create(IProperty property)
    {
        var type = property.GetValueType();
        var values = Enum.GetValues(type);
        var isReadOnly = property.IsReadOnly();

        return new ComboBox
        {
            ItemsSource = values,
            [!!SelectingItemsControl.SelectedItemProperty] = new Binding("Value"),
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
            IsEnabled = !isReadOnly
        };
    }
}
