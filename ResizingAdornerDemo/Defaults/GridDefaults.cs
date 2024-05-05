using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class GridDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Grid grid)
        {
            grid.Background = new SolidColorBrush(Colors.Gray);
            grid.Classes.Add("resizing");
        }
    }

    public void Fixed(object control)
    {
        if (control is Grid grid)
        {
            grid.Background = new SolidColorBrush(Colors.Gray);
            grid.Classes.Add("resizing");
            grid.Width = 200;
            grid.Height = 200;
        }
    }
}