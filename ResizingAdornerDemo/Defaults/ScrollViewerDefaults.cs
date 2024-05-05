using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class ScrollViewerDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is ScrollViewer scrollViewer)
        {
            scrollViewer.Background = new SolidColorBrush(Colors.Gray);
        }
    }

    public void Fixed(object control)
    {
        if (control is ScrollViewer scrollViewer)
        {
            scrollViewer.Background = new SolidColorBrush(Colors.Gray);
            scrollViewer.Width = 200;
            scrollViewer.Height = 200;
        }
    }
}