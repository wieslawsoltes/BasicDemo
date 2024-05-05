using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Metadata;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.XamlDom;

public class AvaloniaObjectFactory
{
    private class ReflectionCache
    {
        public PropertyInfo? ContentProperty { get; }

        public MethodInfo? AddMethod { get; }

        public ReflectionCache(Control control)
        {
            ContentProperty = control
                .GetType()
                .GetProperties()
                .FirstOrDefault(x => x.IsDefined(typeof(ContentAttribute), false));

            AddMethod = ContentProperty?.PropertyType.GetMethod("Add");
        }
    }

    private readonly Dictionary<Type, ReflectionCache> _reflectionCaches = new();

    private ReflectionCache GetReflectionCache(Control control)
    {
        if (!_reflectionCaches.TryGetValue(control.GetType(), out var reflectionCache))
        {
            reflectionCache = new ReflectionCache(control);
            _reflectionCaches[control.GetType()] = reflectionCache;
        }

        return reflectionCache;
    }

    public bool CreateControl(XamlNode xamlNode)
    {
        if (xamlNode.ControlType is null)
        {
            return false;
        }

        xamlNode.Control = ControlFactory.CreateControl(xamlNode.ControlType);

        if (xamlNode.Control is null)
        {
            return false;
        }

        var reflectionCache = GetReflectionCache(xamlNode.Control);

        xamlNode.UpdateControlValues();

        if (xamlNode.Child is { })
        {
            if (!CreateControl(xamlNode.Child))
            {
                return false;
            }

            if (xamlNode.Child.Control is { })
            {
                if (reflectionCache.ContentProperty is { })
                {
                    reflectionCache.ContentProperty.SetValue(xamlNode.Control, xamlNode.Child.Control);
                }

                xamlNode.Child.UpdateControlValues();
            }
        }

        if (xamlNode.Children is { })
        {
            foreach (var child in xamlNode.Children)
            {
                if (!CreateControl(child))
                {
                    return false;
                }

                if (child.Control is null)
                {
                    return false;
                }

                if (reflectionCache.ContentProperty is { } && reflectionCache.AddMethod is { })
                {
                    var content = reflectionCache.ContentProperty.GetValue(xamlNode.Control);
                    if (content is { })
                    {
                        reflectionCache.AddMethod.Invoke(content, new object[] {child.Control});
                    }
                }

                child.UpdateControlValues();
            }
        }

        return true;
    }
}
