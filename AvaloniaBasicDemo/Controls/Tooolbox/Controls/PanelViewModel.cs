using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class PanelViewModel : ToolboxControlViewModel
{
    public PanelViewModel()
    {
        Name = "Panel";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var panel = new Panel();
        panel.Width = 100d;
        panel.Height = 100d;
        panel.Background = Brushes.Black;
        return panel;
    }

    public override Control CreateControl()
    {
        var panel = new Panel();
        panel.Width = 100d;
        panel.Height = 100d;
        panel.Background = Brushes.LightGray;
        return panel;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Panel panel)
        {
            return;
        }

        panel.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
