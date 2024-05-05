using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Model;

namespace ResizingAdorner.Utilities;

public static class GridHelper
{
    public static List<GridColumn> GetColumns(Grid grid)
    {
        var columnsCount = grid.ColumnDefinitions.Count;
        var columns = new List<GridColumn>();

        var columnOffset = 0d;

        for (var i = 0; i < columnsCount; i++)
        {
            var columnDefinition = grid.ColumnDefinitions[i];

            var column = new GridColumn
            {
                Column = i,
                ActualWidth = columnDefinition.ActualWidth,
                ColumnOffset = columnOffset,
            };

            columns.Add(column);

            columnOffset += columnDefinition.ActualWidth;
        }

        return columns;
    }
    
    public static List<GridRow> GetRows(Grid grid)
    {
        var rowsCount = grid.RowDefinitions.Count;
        var rows = new List<GridRow>();

        var rowOffset = 0d;

        for (var i = 0; i < rowsCount; i++)
        {
            var rowDefinition = grid.RowDefinitions[i];

            var row = new GridRow
            {
                Row = i,
                ActualHeight = rowDefinition.ActualHeight,
                RowOffset = rowOffset
            };

            rows.Add(row);

            rowOffset += rowDefinition.ActualHeight;
        }

        return rows;
    }

    public static List<GridCell> GetCells(Grid grid)
    {
        var columnsCount = grid.ColumnDefinitions.Count;
        var rowsCount = grid.RowDefinitions.Count;
        var cells = new List<GridCell>();

        var columnOffset = 0d;

        for (var column = 0; column < columnsCount; column++)
        {
            var columnDefinition = grid.ColumnDefinitions[column];
            var rowOffset = 0d;

            for (var row = 0; row < rowsCount; row++)
            {
                var rowDefinition = grid.RowDefinitions[row];

                var cell = new GridCell
                {
                    Column = column,
                    Row = row,
                    ActualWidth = columnDefinition.ActualWidth,
                    ActualHeight = rowDefinition.ActualHeight,
                    ColumnOffset = columnOffset,
                    RowOffset = rowOffset,
                    Bounds = new Rect(
                        columnOffset,
                        rowOffset,
                        columnDefinition.ActualWidth,
                        rowDefinition.ActualHeight)
                };

                cells.Add(cell);

                rowOffset += rowDefinition.ActualHeight;
            }

            columnOffset += columnDefinition.ActualWidth;
        }

        return cells;
    }
}
