using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using ResizingAdorner.Defaults;
using ResizingAdorner.Editors;
using ResizingAdorner.Model;
using ResizingAdorner.Placement;
using ResizingAdorner.Selection;

namespace ResizingAdorner;

public static class Global
{
    public static readonly IToolboxService? ToolboxManager = new ToolboxService();

    public static readonly Dictionary<Type, IControlEditor> ControlEditors = new()
    {
        [typeof(Border)] = new BorderEditor(),
        [typeof(Button)] = new ButtonEditor(),
        [typeof(Canvas)] = new CanvasEditor(),
        [typeof(ContentControl)] = new ContentControlEditor(),
        [typeof(Decorator)] = new DecoratorEditor(),
        [typeof(DockPanel)] = new DockPanelEditor(),
        [typeof(Grid)] = new GridEditor(),
        [typeof(Label)] = new LabelEditor(),
        [typeof(Panel)] = new PanelEditor(),
        [typeof(ScrollViewer)] = new ScrollViewerEditor(),
        [typeof(StackPanel)] = new StackPanelEditor(),
        [typeof(Viewbox)] = new ViewboxEditor(),
        [typeof(WrapPanel)] = new WrapPanelEditor(),
    };

    public static readonly Dictionary<Type, IControlDefaults> ControlDefaults = new ()
    {
        [typeof(TextBox)] = new TextBoxDefaults(),
        [typeof(Grid)] = new GridDefaults(),
        [typeof(Button)] = new ButtonDefaults(),
        [typeof(AccessText)] = new AccessTextDefaults(),
        [typeof(Slider)] = new SliderDefaults(),
        [typeof(Panel)] = new PanelDefaults(),
        [typeof(Decorator)] = new DecoratorDefaults(),
        [typeof(Label)] = new LabelDefaults(),
        [typeof(ContentControl)] = new ContentControlDefaults(),
        [typeof(StackPanel)] = new StackPanelDefaults(),
        [typeof(Border)] = new BorderDefaults(),
        [typeof(ProgressBar)] = new ProgressBarDefaults(),
        [typeof(Viewbox)] = new ViewboxDefaults(),
        [typeof(Rectangle)] = new RectangleDefaults(),
        [typeof(WrapPanel)] = new WrapPanelDefaults(),
        [typeof(CheckBox)] = new CheckBoxDefaults(),
        [typeof(ScrollViewer)] = new ScrollViewerDefaults(),
        [typeof(DockPanel)] = new DockPanelDefaults(),
        [typeof(Canvas)] = new CanvasDefaults(),
        [typeof(Ellipse)] = new EllipseDefaults(),
        [typeof(TextBlock)] = new TextBlockDefaults(),
        [typeof(RadioButton)] = new RadioButtonDefaults(),
    };
}
