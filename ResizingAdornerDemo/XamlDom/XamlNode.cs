using System;
using System.Collections.Generic;
using Avalonia.Controls;

namespace ResizingAdorner.XamlDom;

public class XamlNode
{
    private XamlPropertyCollection? _propertyCollection;

    public Type? ControlType { get; set; }

    public Dictionary<string, object?>? Values { get; set; }

    public XamlNode? Child { get; set; }

    public List<XamlNode>? Children { get; set; }

    public Control? Control { get; set; }

    public XamlPropertyCollection PropertyCollection
    {
        get
        {
            if (ControlType is null)
            {
                throw new Exception();
            }

            if (_propertyCollection is null)
            {
                if (XamlPropertyRegistry.Properties.TryGetValue(ControlType, out var propertyCollection))
                {
                    _propertyCollection = propertyCollection;

                    return _propertyCollection;
                }

                throw new Exception();
            }

            return _propertyCollection;
        }
    }
    
    public void UpdateControlValues()
    {
        var properties = PropertyCollection;
        if (properties is null)
        {
            throw new Exception();
        }

        if (Values is { } && Control is { })
        {
            foreach (var kvp in Values)
            {
                var property = properties[kvp.Key];
                if (property is null)
                {
                    throw new Exception();
                }

                property.SetValue(Control, kvp.Value);
            }
        }
    }

    /*
    public void SetValue(XamlProperty property, object? value)
    {
        if (Values is null)
        {
            Values = new Dictionary<string, object?>();
        }

        Values[property] = value;

        if (_control is { })
        {
            property.SetValue(_control, value);
        }
    }

    public object? GetValue(XamlProperty property)
    {
        if (Values is { })
        {
            if (Values.TryGetValue(property, out var value))
            {
                return value;
            }
        }

        return AvaloniaProperty.UnsetValue;
    }
    */
}
