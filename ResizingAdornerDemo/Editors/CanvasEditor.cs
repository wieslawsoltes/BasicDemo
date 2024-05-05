using System;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Model;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Editors;

public class CanvasEditor : IControlEditor
{
    public void Insert(Type type, Point point, object control, IControlDefaults? controlDefaults)
    {
        if (control is not Canvas canvas)
        {
            return;
        }
        
        if (ControlFactory.CreateControl(type) is not { } child)
        {
            return;
        }

        controlDefaults?.Fixed(child);

        Canvas.SetLeft(child, point.X);
        Canvas.SetTop(child, point.Y);

        canvas.Children.Add(child);
    }
}