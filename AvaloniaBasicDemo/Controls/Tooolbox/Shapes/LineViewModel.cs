using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox.Shapes;

public class LineViewModel : ToolboxControlViewModel
{
    public LineViewModel()
    {
        Name = "Line";
        Group = "Shapes";
    }

    public override Control CreatePreview()
    {
        var line = new Line();
        line.StartPoint = new Point(0, 0);
        line.EndPoint = new Point(100, 0);
        line.Stroke = Brushes.Black;
        line.StrokeThickness = 2;
        return line;
    }

    public override Control CreateControl()
    {
        var line = new Line();
        line.StartPoint = new Point(0, 0);
        line.EndPoint = new Point(100, 0);
        line.Stroke = Brushes.Gray;
        line.StrokeThickness = 2;
        return line;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Line line)
        {
            return;
        }

        line.Stroke = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
