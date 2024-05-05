using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using AvaloniaBasic.Model;

namespace AvaloniaBasic.Services.PropertyEditors;

public class StringPropertyEditor : IPropertyEditor
{
    public bool Match(IProperty property)
    {
        var type = property.GetValueType();

        return type == typeof(string)
               || type == typeof(decimal) || type == typeof(decimal?)
               || type == typeof(double) || type == typeof(double?)
               || type == typeof(float) || type == typeof(float?)
               || type == typeof(long) || type == typeof(long?)
               || type == typeof(int) || type == typeof(int?)
               || type == typeof(short) || type == typeof(short?)
               || type == typeof(byte) || type == typeof(byte?);
    }

    public object Create(IProperty property)
    {
        var isReadOnly = property.IsReadOnly();

        return new TextBox
        {
            [!TextBox.TextProperty] = new Binding("Value"),
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
            IsReadOnly = isReadOnly
        }; 
    }
}
