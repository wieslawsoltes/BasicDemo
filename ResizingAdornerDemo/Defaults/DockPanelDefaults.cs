using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class DockPanelDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is DockPanel dockPanel)
        {
            dockPanel.Background = new SolidColorBrush(Colors.Gray);
            dockPanel.Classes.Add("resizing");
        }
    }

    public void Fixed(object control)
    {
        if (control is DockPanel dockPanel)
        {
            dockPanel.Background = new SolidColorBrush(Colors.Gray);
            dockPanel.Classes.Add("resizing");
            dockPanel.Width = 200;
            dockPanel.Height = 200;
        }
    }
}