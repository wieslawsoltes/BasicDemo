using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ScrollViewerViewModel : ToolboxControlViewModel
{
    public ScrollViewerViewModel()
    {
        Name = "ScrollViewer";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var scrollViewer = new ScrollViewer();
        scrollViewer.Width = 100d;
        scrollViewer.Height = 100d;
        scrollViewer.Background = Brushes.Black;
        return scrollViewer;
    }

    public override Control CreateControl()
    {
        var scrollViewer = new ScrollViewer();
        scrollViewer.Width = 100d;
        scrollViewer.Height = 100d;
        scrollViewer.Background = Brushes.LightGray;
        return scrollViewer;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ScrollViewer scrollViewer)
        {
            return;
        }

        scrollViewer.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
