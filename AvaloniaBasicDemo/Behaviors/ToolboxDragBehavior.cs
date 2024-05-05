using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Xaml.Interactions.Events;
using AvaloniaBasic.Editors;

namespace AvaloniaBasic.Behaviors;

public class ToolboxDragBehavior : PointerEventsBehavior
{
    public static readonly StyledProperty<Canvas?> PreviewCanvasProperty = 
        AvaloniaProperty.Register<ToolboxDragBehavior, Canvas?>(nameof(PreviewCanvas));

    public static readonly StyledProperty<Canvas?> DropAreaCanvasProperty = 
        AvaloniaProperty.Register<ToolboxDragBehavior, Canvas?>(nameof(DropAreaCanvas));

    private readonly ToolboxCanvasEditor _editor;

    [ResolveByName]
    public Canvas? PreviewCanvas
    {
        get => GetValue(PreviewCanvasProperty);
        set => SetValue(PreviewCanvasProperty, value);
    }

    [ResolveByName]
    public Canvas? DropAreaCanvas
    {
        get => GetValue(DropAreaCanvasProperty);
        set => SetValue(DropAreaCanvasProperty, value);
    }

    public ToolboxDragBehavior()
    {
        _editor = new ToolboxCanvasEditor();
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        _editor.AssociatedObject = AssociatedObject;
        _editor.PreviewCanvas = PreviewCanvas;
        _editor.DropAreaCanvas = DropAreaCanvas;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
 
        _editor.AssociatedObject = null;
        _editor.PreviewCanvas = null;
        _editor.DropAreaCanvas = null;
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == PreviewCanvasProperty)
        {
            _editor.PreviewCanvas = change.GetNewValue<Canvas>();
        }

        if (change.Property == DropAreaCanvasProperty)
        {
            _editor.DropAreaCanvas = change.GetNewValue<Canvas>();
        }
    }

    protected override void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        _editor.OnPointerPressed(e);
    }

    protected override void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        _editor.OnPointerReleased(e);
    }

    protected override void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        _editor.OnPointerMoved(e);
    }
}
