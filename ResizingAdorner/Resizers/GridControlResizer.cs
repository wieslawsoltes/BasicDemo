using System;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Model;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Resizers;

public class GridControlResizer : IControlResizer
{
    private Grid? _grid;

    public bool EnableSnap { get; set; }

    public double SnapX { get; set; }

    public double SnapY { get; set; }

    public void Start(Control control)
    {
        _grid = control.Parent as Grid;
    }

    public void Move(Control control, Point origin, Vector vector)
    {
        if (_grid is null)
        {
            return;
        }

        var point = origin + vector;
        var cells = GridHelper.GetCells(_grid);

        foreach (var cell in cells)
        {
            if (!cell.Bounds.Contains(point))
            {
                continue;
            }

            Grid.SetColumn(control, cell.Column);
            Grid.SetRow(control, cell.Row);
            break;
        }
    }

    public void Left(Control control, Point origin, Vector vector)
    {
        if (_grid is null)
        {
            return;
        }

        var point = origin + vector;
        var cells = GridHelper.GetCells(_grid);

        foreach (var cell in cells)
        {
            if (!cell.Bounds.Contains(point))
            {
                continue;
            }

            var column = Grid.GetColumn(control);
            var columnSpan = Grid.GetColumnSpan(control);
            if (cell.Column > column && columnSpan == 1)
            {
                break;
            }

            Grid.SetColumn(control, cell.Column);

            if (column > cell.Column)
            {
                columnSpan = Math.Max(1, 1 + columnSpan);
                Grid.SetColumnSpan(control, columnSpan);
            }
            else if (column < cell.Column)
            {
                columnSpan = Math.Max(1, columnSpan - 1);
                Grid.SetColumnSpan(control, columnSpan);
            }

            break;
        }
    }

    public void Right(Control control, Point origin, Vector vector)
    {
        if (_grid is null)
        {
            return;
        }

        var point = origin + vector;
        var cells = GridHelper.GetCells(_grid);

        foreach (var cell in cells)
        {
            if (!cell.Bounds.Contains(point))
            {
                continue;
            }

            var column = Grid.GetColumn(control);
            var columnSpan = Math.Max(1, 1 + cell.Column - column);
            Grid.SetColumnSpan(control, columnSpan);
            break;
        }
    }

    public void Top(Control control, Point origin, Vector vector)
    {
        if (_grid is null)
        {
            return;
        }

        var point = origin + vector;
        var cells = GridHelper.GetCells(_grid);

        foreach (var cell in cells)
        {
            if (!cell.Bounds.Contains(point))
            {
                continue;
            }

            var row = Grid.GetRow(control);
            var rowSpan = Grid.GetRowSpan(control);
            if (cell.Row > row && rowSpan == 1)
            {
                break;
            }

            Grid.SetRow(control, cell.Row);

            if (row > cell.Row)
            {
                rowSpan = Math.Max(1, 1 + rowSpan);
                Grid.SetRowSpan(control, rowSpan);
            }
            else if (row < cell.Row)
            {
                rowSpan = Math.Max(1, rowSpan - 1);
                Grid.SetRowSpan(control, rowSpan);
            }

            break;
        }
    }

    public void Bottom(Control control, Point origin, Vector vector)
    {
        if (_grid is null)
        {
            return;
        }

        var point = origin + vector;
        var cells = GridHelper.GetCells(_grid);

        foreach (var cell in cells)
        {
            if (!cell.Bounds.Contains(point))
            {
                continue;
            }

            var row = Grid.GetRow(control);
            var rowSpan = Math.Max(1, 1 + cell.Row - row);
            Grid.SetRowSpan(control, rowSpan);
            break;
        }
    }
}