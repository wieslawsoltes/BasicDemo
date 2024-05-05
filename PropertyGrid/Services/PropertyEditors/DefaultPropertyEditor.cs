using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using AvaloniaBasic.Model;

namespace AvaloniaBasic.Services.PropertyEditors;

public class DefaultPropertyEditor : IPropertyEditor
{
    public bool Match(IProperty property)
    {
        return true;
    }

    public object Create(IProperty property)
    {
        return new TextBlock
        {
            [!TextBlock.TextProperty] = new Binding("Value"),
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
        };
    }
}
