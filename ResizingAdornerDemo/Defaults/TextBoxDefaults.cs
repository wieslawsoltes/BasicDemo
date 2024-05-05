using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class TextBoxDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is TextBox textBox)
        {
            textBox.Text = "TextBox";
        }
    }

    public void Fixed(object control)
    {
        if (control is TextBox textBox)
        {
            textBox.Text = "TextBox";
        }
    }
}