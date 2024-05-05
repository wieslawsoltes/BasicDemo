using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class TabStripViewModel : ToolboxControlViewModel
{
    public TabStripViewModel()
    {
        Name = "TabStrip";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var tabStrip = new TabStrip();
        tabStrip.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        tabStrip.SelectedIndex = 0;
        tabStrip.Foreground = Brushes.Black;
        return tabStrip;
    }

    public override Control CreateControl()
    {
        var tabStrip = new TabStrip();
        tabStrip.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        tabStrip.SelectedIndex = 0;
        //tabStrip.Foreground = Brushes.Blue;
        return tabStrip;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not TabStrip tabStrip)
        {
            return;
        }

        tabStrip.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
