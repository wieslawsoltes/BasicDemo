using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox.Shapes;

public class RectangleViewModel : ToolboxControlViewModel
{
    public RectangleViewModel()
    {
        Name = "Rectangle";
        Group = "Shapes";
    }

    public override Control CreatePreview()
    {
        var rectangle = new Rectangle();
        rectangle.Width = 100d;
        rectangle.Height = 100d;
        rectangle.Fill = Brushes.Black;
        return rectangle;
    }

    public override Control CreateControl()
    {
        var rectangle = new Rectangle();
        rectangle.Width = 100d;
        rectangle.Height = 100d;
        rectangle.Fill = Brushes.Gray;
        return rectangle;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Rectangle rectangle)
        {
            return;
        }

        rectangle.Fill = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
