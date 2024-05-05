using Avalonia;
using Avalonia.Controls;

namespace ResizingAdorner.Model;

public interface IControlResizer
{
    bool EnableSnap { get; set; }
    double SnapX { get; set; }
    double SnapY { get; set; }
    void Start(Control control);
    void Move(Control control, Point origin, Vector vector);
    void Left(Control control, Point origin, Vector vector);
    void Right(Control control, Point origin, Vector vector);
    void Top(Control control, Point origin, Vector vector);
    void Bottom(Control control, Point origin, Vector vector);
}