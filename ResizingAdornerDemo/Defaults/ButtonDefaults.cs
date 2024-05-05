using Avalonia.Controls;
using Avalonia.Layout;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class ButtonDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Button button)
        {
            button.Content = "Button";
            button.HorizontalAlignment = HorizontalAlignment.Stretch;
            button.VerticalAlignment = VerticalAlignment.Stretch;
        }
    }

    public void Fixed(object control)
    {
        if (control is Button button)
        {
            button.Content = "Button";
        }
    }
}