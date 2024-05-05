using System;
using Avalonia;

namespace ResizingAdorner.Model;

public interface IControlEditor
{
    void Insert(Type type, Point point, object control, IControlDefaults? controlDefaults);
}