using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class DecoratorDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Decorator decorator)
        {
        }
    }

    public void Fixed(object control)
    {
        if (control is Decorator decorator)
        {
            decorator.Width = 200;
            decorator.Height = 200;
        }
    }
}