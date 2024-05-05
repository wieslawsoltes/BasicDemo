using Avalonia;

namespace ResizingAdorner.Model;

public class GridCell
{
    public int Column { get; set; }
    public int Row { get; set; }
    public double ActualWidth { get; set; }
    public double ActualHeight { get; set; }
    public double ColumnOffset { get; set; }
    public double RowOffset { get; set; }
    public Rect Bounds { get; set; }
}
