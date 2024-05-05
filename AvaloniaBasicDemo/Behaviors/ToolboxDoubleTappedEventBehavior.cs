using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Xaml.Interactions.Events;
using AvaloniaBasic.Editors;

namespace AvaloniaBasic.Behaviors;

public class ToolboxDoubleTappedEventBehavior : DoubleTappedEventBehavior
{
    public static readonly StyledProperty<Canvas?> TargetCanvasProperty = 
        AvaloniaProperty.Register<ToolboxDoubleTappedEventBehavior, Canvas?>(nameof(TargetCanvas));

    private readonly DoubleTappedEditor _editor;

    [ResolveByName]
    public Canvas? TargetCanvas
    {
        get => GetValue(TargetCanvasProperty);
        set => SetValue(TargetCanvasProperty, value);
    }

    public ToolboxDoubleTappedEventBehavior()
    {
        _editor = new DoubleTappedEditor();
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        _editor.AssociatedObject = AssociatedObject;
        _editor.TargetCanvas = TargetCanvas;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
 
        _editor.AssociatedObject = null;
        _editor.TargetCanvas = null;
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == TargetCanvasProperty)
        {
            _editor.TargetCanvas = change.GetNewValue<Canvas>();
        }
    }

    protected override void OnDoubleTapped(object? sender, RoutedEventArgs e)
    {
        _editor.OnDoubleTapped(e);
    }
}
