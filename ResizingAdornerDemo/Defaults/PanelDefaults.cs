using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class PanelDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Panel panel)
        {
            panel.Background = new SolidColorBrush(Colors.Gray);
            panel.Classes.Add("resizing");
        }
    }

    public void Fixed(object control)
    {
        if (control is Panel panel)
        {
            panel.Background = new SolidColorBrush(Colors.Gray);
            panel.Classes.Add("resizing");
            panel.Width = 200;
            panel.Height = 200;
        }
    }
}