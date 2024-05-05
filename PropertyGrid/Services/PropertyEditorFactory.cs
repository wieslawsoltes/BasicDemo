using System.Collections.Generic;
using System.Linq;
using AvaloniaBasic.Model;

namespace AvaloniaBasic.Services;

public class PropertyEditorFactory : IPropertyEditorFactory
{
    private readonly List<IPropertyEditor> _editors;

    public PropertyEditorFactory()
    {
        _editors = new List<IPropertyEditor>();
    }

    public void Register(IPropertyEditor propertyEditor)
    {
        _editors.Add(propertyEditor);
    }

    public object? CreateEditor(IProperty property)
    {
        var propertyEditor = _editors.FirstOrDefault(x => x.Match(property));

        return propertyEditor?.Create(property);
    }
}
