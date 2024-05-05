using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class UniformGridViewModel : ToolboxControlViewModel
{
    public UniformGridViewModel()
    {
        Name = "UniformGrid";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var uniformGrid = new UniformGrid();
        uniformGrid.Width = 100d;
        uniformGrid.Height = 100d;
        uniformGrid.Background = Brushes.Black;
        return uniformGrid;
    }

    public override Control CreateControl()
    {
        var uniformGrid = new UniformGrid();
        uniformGrid.Width = 100d;
        uniformGrid.Height = 100d;
        uniformGrid.Background = Brushes.LightGray;
        return uniformGrid;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not UniformGrid uniformGrid)
        {
            return;
        }

        uniformGrid.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
