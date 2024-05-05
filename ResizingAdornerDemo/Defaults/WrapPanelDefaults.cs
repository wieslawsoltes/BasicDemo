using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class WrapPanelDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is WrapPanel wrapPanel)
        {
            wrapPanel.Background = new SolidColorBrush(Colors.Gray);
            wrapPanel.Classes.Add("resizing");
        }
    }

    public void Fixed(object control)
    {
        if (control is WrapPanel wrapPanel)
        {
            wrapPanel.Background = new SolidColorBrush(Colors.Gray);
            wrapPanel.Classes.Add("resizing");
            wrapPanel.Width = 200;
            wrapPanel.Height = 200;
        }
    }
}