using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class ContentControlDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is ContentControl contentControl)
        {
            contentControl.Background = new SolidColorBrush(Colors.Gray);
        }
    }

    public void Fixed(object control)
    {
        if (control is ContentControl contentControl)
        {
            contentControl.Background = new SolidColorBrush(Colors.Gray);
            contentControl.Width = 200;
            contentControl.Height = 200;
        }
    }
}