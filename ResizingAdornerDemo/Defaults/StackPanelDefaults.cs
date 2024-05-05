using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class StackPanelDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is StackPanel stackPanel)
        {
            stackPanel.Background = new SolidColorBrush(Colors.Gray);
            stackPanel.Classes.Add("resizing");
        }
    }

    public void Fixed(object control)
    {
        if (control is StackPanel stackPanel)
        {
            stackPanel.Background = new SolidColorBrush(Colors.Gray);
            stackPanel.Classes.Add("resizing");
            stackPanel.Width = 200;
            stackPanel.Height = 200;
        }
    }
}