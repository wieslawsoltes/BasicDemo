using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class GridSplitterViewModel : ToolboxControlViewModel
{
    public GridSplitterViewModel()
    {
        Name = "GridSplitter";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var gridSplitter = new GridSplitter();
        gridSplitter.Background = Brushes.Black;
        return gridSplitter;
    }

    public override Control CreateControl()
    {
        var gridSplitter = new GridSplitter();
        gridSplitter.Background = Brushes.LightGray;
        return gridSplitter;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not GridSplitter gridSplitter)
        {
            return;
        }

        gridSplitter.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
