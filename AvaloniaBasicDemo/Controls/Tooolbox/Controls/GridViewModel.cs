using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class GridViewModel : ToolboxControlViewModel
{
    public GridViewModel()
    {
        Name = "Grid";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var grid = new Grid();
        grid.Width = 100d;
        grid.Height = 100d;
        grid.Background = Brushes.Black;
        return grid;
    }

    public override Control CreateControl()
    {
        var grid = new Grid();
        grid.Width = 100d;
        grid.Height = 100d;
        grid.Background = Brushes.LightGray;
        return grid;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Grid grid)
        {
            return;
        }

        grid.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
