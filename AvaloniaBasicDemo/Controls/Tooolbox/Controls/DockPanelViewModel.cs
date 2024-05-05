using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class DockPanelViewModel : ToolboxControlViewModel
{
    public DockPanelViewModel()
    {
        Name = "DockPanel";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var dockPanel = new DockPanel();
        dockPanel.Width = 100d;
        dockPanel.Height = 100d;
        dockPanel.Background = Brushes.Black;
        return dockPanel;
    }

    public override Control CreateControl()
    {
        var dockPanel = new DockPanel();
        dockPanel.Width = 100d;
        dockPanel.Height = 100d;
        dockPanel.Background = Brushes.LightGray;
        return dockPanel;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not DockPanel dockPanel)
        {
            return;
        }

        dockPanel.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
