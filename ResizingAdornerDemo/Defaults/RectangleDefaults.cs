using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class RectangleDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Rectangle rectangle)
        {
            rectangle.Fill = new SolidColorBrush(Colors.Gray);
        }
    }

    public void Fixed(object control)
    {
        if (control is Rectangle rectangle)
        {
            rectangle.Fill = new SolidColorBrush(Colors.Gray);
            rectangle.Width = 100;
            rectangle.Height = 100;
        }
    }
}