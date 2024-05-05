using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox.Shapes;

public class PolylineViewModel : ToolboxControlViewModel
{
    public PolylineViewModel()
    {
        Name = "Polyline";
        Group = "Shapes";
    }

    public override Control CreatePreview()
    {
        var polyline = new Polyline();
        polyline.Width = 100d;
        polyline.Height = 100d;
        polyline.Points = new List<Point> { new (0,0), new (100,0), new (100,100), new (0,100) };
        polyline.Stroke = Brushes.Black;
        return polyline;
    }

    public override Control CreateControl()
    {
        var polyline = new Polyline();
        polyline.Width = 100d;
        polyline.Height = 100d;
        polyline.Points = new List<Point> { new (0,0), new (100,0), new (100,100), new (0,100) };
        polyline.Stroke = Brushes.Gray;
        return polyline;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Polyline polyline)
        {
            return;
        }

        polyline.Stroke = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
