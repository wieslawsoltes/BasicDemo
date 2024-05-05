using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class TabControlViewModel : ToolboxControlViewModel
{
    public TabControlViewModel()
    {
        Name = "TabControl";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var tabControl = new TabControl();
        tabControl.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        tabControl.SelectedIndex = 0;
        tabControl.Foreground = Brushes.Black;
        return tabControl;
    }

    public override Control CreateControl()
    {
        var tabControl = new TabControl();
        tabControl.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        tabControl.SelectedIndex = 0;
        //tabControl.Foreground = Brushes.Blue;
        return tabControl;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not TabControl tabControl)
        {
            return;
        }

        tabControl.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
