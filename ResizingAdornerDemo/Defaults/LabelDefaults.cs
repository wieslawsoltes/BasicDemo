using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class LabelDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Label label)
        {
            label.Content = "Label";
        }
    }

    public void Fixed(object control)
    {
        if (control is Label label)
        {
            label.Content = "Label";
        }
    }
}