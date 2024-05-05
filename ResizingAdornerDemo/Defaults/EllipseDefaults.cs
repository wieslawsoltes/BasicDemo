using Avalonia.Controls.Shapes;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class EllipseDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Ellipse ellipse)
        {
            ellipse.Fill = new SolidColorBrush(Colors.Gray);
        }
    }

    public void Fixed(object control)
    {
        if (control is Ellipse ellipse)
        {
            ellipse.Fill = new SolidColorBrush(Colors.Gray);
            ellipse.Width = 100;
            ellipse.Height = 100;
        }
    }
}