using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class TextBlockDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is TextBlock textBlock)
        {
            textBlock.Text = "TextBlock";  
        }
    }

    public void Fixed(object control)
    {
        if (control is TextBlock textBlock)
        {
            textBlock.Text = "TextBlock"; 
        }
    }
}