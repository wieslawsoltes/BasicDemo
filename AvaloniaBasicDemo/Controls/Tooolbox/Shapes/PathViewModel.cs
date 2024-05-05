using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox.Shapes;

public class PathViewModel : ToolboxControlViewModel
{
    public PathViewModel()
    {
        Name = "Path";
        Group = "Shapes";
    }

    public override Control CreatePreview()
    {
        var path = new Path();
        path.Width = 100d;
        path.Height = 100d;
        path.Data = Geometry.Parse("M0 0 L100 0 L100 100 L0 100 Z");
        path.Fill = Brushes.Black;
        return path;
    }

    public override Control CreateControl()
    {
        var path = new Path();
        path.Width = 100d;
        path.Height = 100d;
        path.Data = Geometry.Parse("M0 0 L100 0 L100 100 L0 100 Z");
        path.Fill = Brushes.Gray;
        return path;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Path path)
        {
            return;
        }

        path.Fill = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
