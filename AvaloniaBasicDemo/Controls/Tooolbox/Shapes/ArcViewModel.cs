using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox.Shapes;

public class ArcViewModel : ToolboxControlViewModel
{
    public ArcViewModel()
    {
        Name = "Arc";
        Group = "Shapes";
    }

    public override Control CreatePreview()
    {
        var arc = new Arc();
        arc.Width = 100d;
        arc.Height = 100d;
        arc.StartAngle = 180d;
        arc.SweepAngle = 180d;
        arc.Fill = Brushes.Black;
        return arc;
    }

    public override Control CreateControl()
    {
        var arc = new Arc();
        arc.Width = 100d;
        arc.Height = 100d;
        arc.StartAngle = 180d;
        arc.SweepAngle = 180d;
        arc.Fill = Brushes.Gray;
        return arc;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Arc arc)
        {
            return;
        }

        arc.Fill = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
