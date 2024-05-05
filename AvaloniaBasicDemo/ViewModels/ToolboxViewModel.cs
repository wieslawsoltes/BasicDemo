using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using AvaloniaBasic.Model;
using AvaloniaBasic.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels;

public partial class ToolboxViewModel : ViewModelBase
{
    [ObservableProperty] private IEnumerable<IToolboxItem> _toolboxes;
    [ObservableProperty] private IToolboxItem? _selectedToolBoxItem;
    [ObservableProperty] private Canvas? _previewCanvas;
    [ObservableProperty] private Canvas? _dropAreaCanvas;

    public ToolboxViewModel(IToolboxItemProvider toolboxItemProvider)
    {
        _toolboxes = toolboxItemProvider.GetToolboxItems();

        ToolboxSource = CreateToolboxSource();
    }

    public HierarchicalTreeDataGridSource<IToolboxItem> ToolboxSource { get; }

    private HierarchicalTreeDataGridSource<IToolboxItem> CreateToolboxSource()
    {
        var toolboxSource = new HierarchicalTreeDataGridSource<IToolboxItem>(Toolboxes)
        {
            Columns =
            {
                new HierarchicalExpanderColumn<IToolboxItem>(
                    inner: new TemplateColumn<IToolboxItem>(
                        "Toolbox",
                        new FuncDataTemplate<IToolboxItem>((_, _) =>
                        {
                            return new Label
                            {
                                [!ContentControl.ContentProperty] = new Binding("Name")
                            };
                        }, true),
                        options: new TemplateColumnOptions<IToolboxItem>
                        {
                            CanUserResizeColumn = false,
                            CanUserSortColumn = true,
                            CompareAscending = SortHelper.SortAscending<string?, IToolboxItem>(x => x.Name),
                            CompareDescending = SortHelper.SortDescending<string?, IToolboxItem>(x => x.Name)
                        },
                        width: new GridLength(1, GridUnitType.Star)), 
                    childSelector: x => x.GetChildren(),
                    hasChildrenSelector: x => x.HasChildren,
                    isExpandedSelector: x => x.IsExpanded)
            }
        };

        toolboxSource.RowSelection!.SingleSelect = true;

        toolboxSource.RowSelection.SelectionChanged += (_, args) =>
        {
            SelectedToolBoxItem = args.SelectedItems.FirstOrDefault();
        };

        return toolboxSource;
    }
}
