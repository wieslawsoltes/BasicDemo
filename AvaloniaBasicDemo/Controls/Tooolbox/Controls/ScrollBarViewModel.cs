using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ScrollBarViewModel : ToolboxControlViewModel
{
    public ScrollBarViewModel()
    {
        Name = "ScrollBar";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var scrollBar = new ScrollBar();
        scrollBar.Width = 30d;
        scrollBar.Height = 100d;
        scrollBar.Background = Brushes.Black;
        return scrollBar;
    }

    public override Control CreateControl()
    {
        var scrollBar = new ScrollBar();
        scrollBar.Width = 30d;
        scrollBar.Height = 100d;
        scrollBar.Background = Brushes.LightGray;
        return scrollBar;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ScrollBar scrollBar)
        {
            return;
        }

        scrollBar.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
