using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using Avalonia.Utilities;
using AvaloniaBasic.Model;

namespace AvaloniaBasic.ViewModels.Properties;

public partial class ClrPropertyViewModel : PropertyViewModel
{
    private readonly IPropertyEditorContext _editor;
    private readonly PropertyInfo _property;
    
    public ClrPropertyViewModel(IPropertyEditorContext editor, PropertyInfo property)
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
            if (!_property.CanWrite && _editor.Current is { })
            {
                if (Value is { })
                {
                    if (Value.GetType() == _property.PropertyType)
                    {
                        try
                        {
                            _property.SetValue(_editor.Current, Value);

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
                                _property.SetValue(_editor.Current, result);

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
        return !_property.CanWrite;
    }

    public override bool IsEditable()
    {
        return true;
    }
}
