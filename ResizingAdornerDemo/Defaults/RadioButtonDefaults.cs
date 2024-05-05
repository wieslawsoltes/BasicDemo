using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class RadioButtonDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is RadioButton radioButton)
        {
            radioButton.Content = "RadioButton";
        }
    }

    public void Fixed(object control)
    {
        if (control is RadioButton radioButton)
        {
            radioButton.Content = "RadioButton";
        }
    }
}