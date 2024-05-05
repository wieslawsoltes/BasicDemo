using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaBasic.Model;
using AvaloniaBasic.ViewModels;
using AvaloniaBasic.ViewModels.Toolbox;
using AvaloniaBasic.ViewModels.Toolbox.Shapes;

namespace AvaloniaBasic.Services;

public class DefaultToolboxItemProvider : IToolboxItemProvider
{
    public IEnumerable<IToolboxItem> GetToolboxItems()
    {
        return new ObservableCollection<IToolboxItem>
        {
            new ToolboxGroupViewModel
            {
                Name = "Layout",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new BorderViewModel(),
                    new CanvasViewModel(),
                    new DecoratorViewModel(),
                    new DockPanelViewModel(),
                    new ExpanderViewModel(),
                    new GridViewModel(),
                    new GridSplitterViewModel(),
                    new LayoutTransformControlViewModel(),
                    new PanelViewModel(),
                    new RelativePanelViewModel(),
                    new ScrollBarViewModel(),
                    new ScrollViewerViewModel(),
                    new SplitViewViewModel(),
                    new StackPanelViewModel(),
                    new UniformGridViewModel(),
                    new WrapPanelViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Buttons",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new ButtonViewModel(),
                    new ButtonSpinnerViewModel(),
                    new RepeatButtonViewModel(),
                    new RadioButtonViewModel(),
                    // SplitButton
                    new ToggleButtonViewModel(),
                    // ToggleSplitButton
                    new ToggleSwitchViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Data Display",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new CarouselViewModel(),
                    new DataGridViewModel(),
                    new ItemsControlViewModel(),
                    new ItemsRepeaterViewModel(),
                    new ListBoxViewModel(),
                    new TabControlViewModel(),
                    new TabStripViewModel(),
                    new TreeDataGridViewModel(),
                    new TreeViewViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Text",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new AccessTextViewModel(),
                    new AutoCompleteBoxViewModel(),
                    new MaskedTextBoxViewModel(),
                    new NumericUpDownViewModel(),
                    new TextBlockViewModel(),
                    new TextBoxViewModel(),
                    
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Value selectors",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new CheckBoxViewModel(),
                    new ComboBoxViewModel(),
                    new SliderViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Content Display",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new ContentControlViewModel(),
                    new LabelViewModel(),
                    new TransitioningContentControlViewModel(),
                    new ViewboxViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Images",
                Items = new ObservableCollection<IToolboxItem>
                {
                    // DrawingImage
                    new ImageViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Date and Time",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new CalendarViewModel(),
                    new CalendarDatePickerViewModel(),
                    new DatePickerViewModel(),
                    new TimePickerViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Menus",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new ContextMenuViewModel(),
                    // Flyout
                    new MenuViewModel(),
                    // MenuFlyout
                    new MenuItemViewModel(),
                    new SeparatorViewModel(),
                    // NativeMenu
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Shapes",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new ArcViewModel(),
                    new EllipseViewModel(),
                    new LineViewModel(),
                    new PathViewModel(),
                    new PolygonViewModel(),
                    new PolylineViewModel(),
                    new RectangleViewModel(),
                }
            },
            new ToolboxGroupViewModel
            {
                Name = "Status Display",
                Items = new ObservableCollection<IToolboxItem>
                {
                    new ProgressBarViewModel(),
                }
            },
        };
    }
}
