using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;

namespace ResizingAdorner.Utilities;

public static class ControlFactory
{
    public static Control? CreateControl(Type type)
    {
        return Activator.CreateInstance(type) as Control;
    }

    public static bool HasBaseType(Type t, Type baseType)
    {
        var b = t.BaseType;
        while (b != null)
        {
            if (b == baseType)
            {
                return true;
            }

            b = b.BaseType;
        }

        return false;
    }

    public static List<Type> GetControlTypes()
    {
        var controlType = typeof(Control);
        var topLevelType = typeof(TopLevel);
        var controlsAssembly = controlType.Assembly;
        var controlTypes = new List<Type>();

        foreach (var t in controlsAssembly.GetTypes())
        {
            if (!t.IsAbstract
                && t.IsPublic
                && t.IsClass
                && !t.ContainsGenericParameters
                && t.GetConstructors().Any(static x => x.GetParameters().Length == 0))
            {
                if (HasBaseType(t, controlType) 
                    && !HasBaseType(t, topLevelType))
                {
                    controlTypes.Add(t);
                }
            }
        }

        controlTypes.Sort(static (a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));

        return controlTypes;
    }
}
