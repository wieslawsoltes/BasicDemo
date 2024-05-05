using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class CanvasDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Canvas canvas)
        {
            canvas.Background = new SolidColorBrush(Colors.Gray);
            canvas.Classes.Add("resizing");  
        }
    }

    public void Fixed(object control)
    {
        if (control is Canvas canvas)
        {
            canvas.Background = new SolidColorBrush(Colors.Gray);
            canvas.Classes.Add("resizing");
            canvas.Width = 200;
            canvas.Height = 200;
        }
    }
}