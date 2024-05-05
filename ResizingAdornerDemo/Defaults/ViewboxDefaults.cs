using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class ViewboxDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Viewbox viewbox)
        {
        }
    }

    public void Fixed(object control)
    {
        if (control is Viewbox viewbox)
        {
            viewbox.Width = 200;
            viewbox.Height = 200;
        }
    }
}