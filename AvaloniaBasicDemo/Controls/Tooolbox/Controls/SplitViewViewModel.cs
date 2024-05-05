using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class SplitViewViewModel : ToolboxControlViewModel
{
    public SplitViewViewModel()
    {
        Name = "SplitView";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var splitView = new SplitView();
        splitView.Width = 100d;
        splitView.Height = 100d;
        splitView.Background = Brushes.Black;
        return splitView;
    }

    public override Control CreateControl()
    {
        var splitView = new SplitView();
        splitView.Width = 100d;
        splitView.Height = 100d;
        splitView.Background = Brushes.LightGray;
        return splitView;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not SplitView splitView)
        {
            return;
        }

        splitView.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
