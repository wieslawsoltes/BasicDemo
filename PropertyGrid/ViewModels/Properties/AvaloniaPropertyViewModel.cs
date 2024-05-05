using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Avalonia;
using Avalonia.Utilities;
using AvaloniaBasic.Model;

namespace AvaloniaBasic.ViewModels.Properties;

public partial class AvaloniaPropertyViewModel : PropertyViewModel
{
    private readonly IPropertyEditorContext _editor;
    private readonly AvaloniaProperty _property;
    
    public AvaloniaPropertyViewModel(IPropertyEditorContext editor, AvaloniaProperty property)
    {
        _editor = editor;
        _property = property;
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (_editor.IsUpdating)
        {
            return;
        }

        if (e.PropertyName == nameof(Value))
        {
            if (!_property.IsReadOnly && _editor.Current is { })
            {
                if (Value is { })
                {
                    if (Value.GetType() == _property.PropertyType)
                    {
                        try
                        {
                            if (_editor.Current is AvaloniaObject avaloniaObject)
                            {
                                avaloniaObject.SetValue(_property, Value);
                            }

                            // TODO: IsDirty, DefaultValue
                        }
                        catch (Exception exception)
                        {
                            Debug.WriteLine(exception);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (TypeUtilities.TryConvert(_property.PropertyType, Value, CultureInfo.InvariantCulture, out var result))
                            {
                                if (_editor.Current is AvaloniaObject avaloniaObject)
                                {
                                    avaloniaObject.SetValue(_property, result);
                                }

                                // TODO: IsDirty, DefaultValue
                            }
                        }
                        catch (Exception exception)
                        {
                            Debug.WriteLine(exception);
                        }
                    }
                }
            }
        }
    }

    public override Type GetValueType()
    {
        return _property.PropertyType;
    }

    public override bool IsReadOnly()
    {
        return _property.IsReadOnly;
    }

    public override bool IsEditable()
    {
        return true;
    }
}
