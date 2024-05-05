using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox.Shapes;

public class EllipseViewModel : ToolboxControlViewModel
{
    public EllipseViewModel()
    {
        Name = "Ellipse";
        Group = "Shapes";
    }

    public override Control CreatePreview()
    {
        var ellipse = new Ellipse();
        ellipse.Width = 100d;
        ellipse.Height = 100d;
        ellipse.Fill = Brushes.Black;
        return ellipse;
    }

    public override Control CreateControl()
    {
        var ellipse = new Ellipse();
        ellipse.Width = 100d;
        ellipse.Height = 100d;
        ellipse.Fill = Brushes.Gray;
        return ellipse;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Ellipse ellipse)
        {
            return;
        }

        ellipse.Fill = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
