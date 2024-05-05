using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class CheckBoxDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is CheckBox checkBox)
        {
            checkBox.Content = "CheckBox";
        }
    }

    public void Fixed(object control)
    {
        if (control is CheckBox checkBox)
        {
            checkBox.Content = "CheckBox";
        }
    }
}