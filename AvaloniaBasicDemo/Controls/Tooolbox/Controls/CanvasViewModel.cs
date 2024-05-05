using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class CanvasViewModel : ToolboxControlViewModel
{
    public CanvasViewModel()
    {
        Name = "Canvas";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var canvas = new Canvas();
        canvas.Width = 200d;
        canvas.Height = 200d;
        canvas.Background = Brushes.Black;
        return canvas;
    }

    public override Control CreateControl()
    {
        var canvas = new Canvas();
        canvas.Width = 200d;
        canvas.Height = 200d;
        canvas.Background = Brushes.LightGray;
        return canvas;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Canvas canvas)
        {
            return;
        }

        canvas.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
