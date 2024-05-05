using System.Linq;
using System.Reflection;
using Avalonia;

namespace ResizingAdorner.XamlDom;

public class XamlProperty
{
    public string Name { get; set; }

    public AvaloniaProperty? AvaloniaProperty { get; set; }

    public PropertyInfo? ClrProperty { get; set; }

    public static XamlProperty CreateClr<T>(string name)
    {
        var propertyInfo = typeof(T).GetProperties().FirstOrDefault(x => x.Name == name);
        return new XamlProperty(name, propertyInfo);
    }

    public static XamlProperty CreateAvalonia<T>(string name)
    {
        var avaloniaProperty = AvaloniaPropertyRegistry.Instance.FindRegistered(typeof(T), name);
        return new XamlProperty(name, avaloniaProperty);
    }

    public XamlProperty(string name, AvaloniaProperty? avaloniaProperty)
    {
        Name = name;
        AvaloniaProperty = avaloniaProperty;
    }

    public XamlProperty(string name, PropertyInfo? clrProperty)
    {
        Name = name;
        ClrProperty = clrProperty;
    }
    
    public void SetValue(AvaloniaObject obj, object? value)
    {
        if (AvaloniaProperty is { })
        {
            obj.SetValue(AvaloniaProperty, value);
        }

        if (ClrProperty is { })
        {
            ClrProperty.SetValue(obj, value);
        }
    }
}
