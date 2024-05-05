using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class WrapPanelViewModel : ToolboxControlViewModel
{
    public WrapPanelViewModel()
    {
        Name = "WrapPanel";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var wrapPanel = new WrapPanel();
        wrapPanel.Width = 100d;
        wrapPanel.Height = 100d;
        wrapPanel.Background = Brushes.Black;
        return wrapPanel;
    }

    public override Control CreateControl()
    {
        var wrapPanel = new WrapPanel();
        wrapPanel.Width = 100d;
        wrapPanel.Height = 100d;
        wrapPanel.Background = Brushes.LightGray;
        return wrapPanel;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not WrapPanel wrapPanel)
        {
            return;
        }

        wrapPanel.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
