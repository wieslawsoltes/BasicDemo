using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Controls;

public class GridAdorner : Control
{
    public static readonly StyledProperty<Grid?> GridProperty = 
        AvaloniaProperty.Register<GridAdorner, Grid?>(nameof(Grid));

    public Grid? Grid
    {
        get => GetValue(GridProperty);
        set => SetValue(GridProperty, value);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        if (Grid is { })
        {
            var bounds = Grid.Bounds;
            var pen = new Pen(new SolidColorBrush(Colors.Cyan));

            var columns = GridHelper.GetColumns(Grid);
            var rows = GridHelper.GetRows(Grid);

            foreach (var column in columns)
            {
                if (column.Column > 0)
                {
                    context.DrawLine(
                        pen, 
                        new Point(column.ColumnOffset, 0.0), 
                        new Point(column.ColumnOffset, bounds.Height));
                }
            }

            foreach (var row in rows)
            {
                if (row.Row > 0)
                {
                    context.DrawLine(
                        pen, 
                        new Point(0.0, row.RowOffset), 
                        new Point(bounds.Width, row.RowOffset));
                }
            }

            /*
            var cells = GridHelper.GetCells(Grid);
            
            foreach (var cell in cells)
            {
                context.DrawRectangle(null, pen, cell.Bounds);
            }
            //*/
        }
    }
}