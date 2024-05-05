using System;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Model;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Editors;

public class LabelEditor : IControlEditor
{
    public void Insert(Type type, Point point, object control, IControlDefaults? controlDefaults)
    {
        if (control is not Label label)
        {
            return;
        }

        if (ControlFactory.CreateControl(type) is not { } child)
        {
            return;
        }

        controlDefaults?.Auto(child);

        label.Content = child;
    }
}