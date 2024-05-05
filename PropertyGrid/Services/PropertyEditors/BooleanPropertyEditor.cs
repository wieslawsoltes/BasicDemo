using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using AvaloniaBasic.Model;

namespace AvaloniaBasic.Services.PropertyEditors;

public class BooleanPropertyEditor : IPropertyEditor
{
    public bool Match(IProperty property)
    {
        var type = property.GetValueType();

        return type == typeof(bool) || type == typeof(bool?);
    }

    public object Create(IProperty property)
    {
        var isReadOnly = property.IsReadOnly();

        return new CheckBox
        {
            [!ToggleButton.IsCheckedProperty] = new Binding("Value"),
            HorizontalAlignment = HorizontalAlignment.Stretch,
            HorizontalContentAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Center,
            IsEnabled = !isReadOnly
        };
    }
}
