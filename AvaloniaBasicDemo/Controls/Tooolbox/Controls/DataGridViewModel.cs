using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class DataGridViewModel : ToolboxControlViewModel
{
    public DataGridViewModel()
    {
        Name = "DataGrid";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var dataGrid = new DataGrid();
        dataGrid.AutoGenerateColumns = false;
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Item 1", Width = DataGridLength.Auto });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Item 2", Width = DataGridLength.Auto });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Item 3", Width = DataGridLength.Auto });
        dataGrid.Width = 300d;
        dataGrid.Height = 100d;
        dataGrid.Background = Brushes.Black;
        return dataGrid;
    }

    public override Control CreateControl()
    {
        var dataGrid = new DataGrid();
        dataGrid.AutoGenerateColumns = false;
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Item 1", Width = DataGridLength.Auto });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Item 2", Width = DataGridLength.Auto });
        dataGrid.Columns.Add(new DataGridTextColumn { Header = "Item 3", Width = DataGridLength.Auto });
        dataGrid.Width = 300d;
        dataGrid.Height = 100d;
        dataGrid.Background = Brushes.LightGray;
        return dataGrid;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not DataGrid dataGrid)
        {
            return;
        }

        dataGrid.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
