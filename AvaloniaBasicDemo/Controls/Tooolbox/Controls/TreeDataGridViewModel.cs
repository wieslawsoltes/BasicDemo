using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class TreeDataGridViewModel : ToolboxControlViewModel
{
    public TreeDataGridViewModel()
    {
        Name = "TreeDataGrid";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var treeDataGrid = new TreeDataGrid();
        treeDataGrid.Width = 300d;
        treeDataGrid.Height = 100d;
        treeDataGrid.Background = Brushes.Black;
        return treeDataGrid;
    }

    public override Control CreateControl()
    {
        var treeDataGrid = new TreeDataGrid();
        treeDataGrid.Width = 300d;
        treeDataGrid.Height = 100d;
        treeDataGrid.Background = Brushes.LightGray;
        return treeDataGrid;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not TreeDataGrid treeDataGrid)
        {
            return;
        }

        treeDataGrid.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
