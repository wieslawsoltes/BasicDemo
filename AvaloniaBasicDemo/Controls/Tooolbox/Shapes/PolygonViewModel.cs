using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox.Shapes;

public class PolygonViewModel : ToolboxControlViewModel
{
    public PolygonViewModel()
    {
        Name = "Polygon";
        Group = "Shapes";
    }

    public override Control CreatePreview()
    {
        var polygon = new Polygon();
        polygon.Width = 100d;
        polygon.Height = 100d;
        polygon.Points = new List<Point> { new (0,0), new (100,0), new (100,100), new (0,100) };
        polygon.Fill = Brushes.Black;
        return polygon;
    }

    public override Control CreateControl()
    {
        var polygon = new Polygon();
        polygon.Width = 100d;
        polygon.Height = 100d;
        polygon.Points = new List<Point> { new (0,0), new (100,0), new (100,100), new (0,100) };
        polygon.Fill = Brushes.Gray;
        return polygon;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Polygon polygon)
        {
            return;
        }

        polygon.Fill = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
