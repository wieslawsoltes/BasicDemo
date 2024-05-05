using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class RelativePanelViewModel : ToolboxControlViewModel
{
    public RelativePanelViewModel()
    {
        Name = "RelativePanel";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var relativePanel = new RelativePanel();
        relativePanel.Width = 100d;
        relativePanel.Height = 100d;
        relativePanel.Background = Brushes.Black;
        return relativePanel;
    }

    public override Control CreateControl()
    {
        var relativePanel = new RelativePanel();
        relativePanel.Width = 100d;
        relativePanel.Height = 100d;
        relativePanel.Background = Brushes.LightGray;
        return relativePanel;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not RelativePanel relativePanel)
        {
            return;
        }

        relativePanel.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
