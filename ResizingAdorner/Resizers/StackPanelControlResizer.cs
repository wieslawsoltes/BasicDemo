using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Model;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Resizers;

public class StackPanelControlResizer : IControlResizer
{
    private StackPanel? _stackPanel;
    private double _width;
    private double _height;

    public bool EnableSnap { get; set; }

    public double SnapX { get; set; }

    public double SnapY { get; set; }

    private double SnapXValue(double value)
    {
        return EnableSnap ? SnapHelper.SnapValue(value, SnapX) : value;
    }

    private double SnapYValue(double value)
    {
        return EnableSnap ? SnapHelper.SnapValue(value, SnapY) : value;
    }

    public void Start(Control control)
    {
        _stackPanel = control.Parent as StackPanel;
        _width = control.Bounds.Width;
        _height = control.Bounds.Height;
    }

    public void Move(Control control, Point origin, Vector vector)
    {
        // TODO:
    }

    public void Left(Control control, Point origin, Vector vector)
    {
        // TODO:

        var width = _width - vector.X;
        if (width >= 0)
        {
            // TODO: Check for MinWidth
            control.Width = SnapXValue(width);
        }
    }

    public void Right(Control control, Point origin, Vector vector)
    {
        // TODO:

        var width = _width + vector.X;
        if (width >= 0)
        {
            // TODO: Check for MinWidth
            control.Width = SnapXValue(width);
        }
    }

    public void Top(Control control, Point origin, Vector vector)
    {
        // TODO:

        var height = _height - vector.Y;
        if (height >= 0)
        {
            // TODO: Check for MinHeight
            control.Height = SnapYValue(height);
        }
    }

    public void Bottom(Control control, Point origin, Vector vector)
    {
        // TODO:

        var height = _height + vector.Y;
        if (height >= 0)
        {
            // TODO: Check for MinHeight
            control.Height = SnapYValue(height);
        }
    }
}