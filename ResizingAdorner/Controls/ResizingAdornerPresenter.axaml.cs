using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using ResizingAdorner.Model;
using ResizingAdorner.Selection;

namespace ResizingAdorner.Controls;

[TemplatePart("PART_ThumbCenter", typeof(Thumb))]
[TemplatePart("PART_ThumbLeft", typeof(Thumb))]
[TemplatePart("PART_ThumbRight", typeof(Thumb))]
[TemplatePart("PART_ThumbTop", typeof(Thumb))]
[TemplatePart("PART_ThumbBottom", typeof(Thumb))]
[TemplatePart("PART_ThumbTopLeft", typeof(Thumb))]
[TemplatePart("PART_ThumbTopRight", typeof(Thumb))]
[TemplatePart("PART_ThumbBottomLeft", typeof(Thumb))]
[TemplatePart("PART_ThumbBottomRight", typeof(Thumb))]
public class ResizingAdornerPresenter : TemplatedControl
{
    public static readonly IControlSelection? s_controlSelection = new ControlSelection();

    public static readonly StyledProperty<Control?> AdornedControlProperty = 
        AvaloniaProperty.Register<ResizingAdornerPresenter, Control?>(nameof(AdornedControl));

    public static readonly StyledProperty<double> AdornedWidthProperty = 
        AvaloniaProperty.Register<ResizingAdornerPresenter, double>(nameof(AdornedWidth));

    public static readonly StyledProperty<double> AdornedHeightProperty = 
        AvaloniaProperty.Register<ResizingAdornerPresenter, double>(nameof(AdornedHeight));

    public static readonly StyledProperty<bool> ShowThumbsProperty = 
        AvaloniaProperty.Register<ResizingAdornerPresenter, bool>(nameof(ShowThumbs));

    public static readonly StyledProperty<IControlResizer?> ControlResizerProperty = 
        AvaloniaProperty.Register<ResizingAdornerPresenter, IControlResizer?>(nameof(ControlResizer));

    public static readonly StyledProperty<IControlSelection?> ControlSelectionProperty = 
        AvaloniaProperty.Register<ResizingAdornerPresenter, IControlSelection?>(nameof(ControlSelection));

    private bool _updating;
    private bool _isPressed;
    private bool _isDragging;
    private Thumb? _thumbCenter;
    private Thumb? _thumbLeft;
    private Thumb? _thumbRight;
    private Thumb? _thumbTop;
    private Thumb? _thumbBottom;
    private Thumb? _thumbTopLeft;
    private Thumb? _thumbTopRight;
    private Thumb? _thumbBottomLeft;
    private Thumb? _thumbBottomRight;
    private Point _startPointParent;

    public Control? AdornedControl
    {
        get => GetValue(AdornedControlProperty);
        set => SetValue(AdornedControlProperty, value);
    }

    public double AdornedWidth
    {
        get => GetValue(AdornedWidthProperty);
        set => SetValue(AdornedWidthProperty, value);
    }

    public double AdornedHeight
    {
        get => GetValue(AdornedHeightProperty);
        set => SetValue(AdornedHeightProperty, value);
    }

    public bool ShowThumbs
    {
        get => GetValue(ShowThumbsProperty);
        set => SetValue(ShowThumbsProperty, value);
    }

    public IControlResizer? ControlResizer
    {
        get => GetValue(ControlResizerProperty);
        set => SetValue(ControlResizerProperty, value);
    }

    public IControlSelection? ControlSelection
    {
        get => GetValue(ControlSelectionProperty);
        set => SetValue(ControlSelectionProperty, value);
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        if (AdornedControl is { })
        {
            ControlSelection?.Register(this);
        }
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);
        
        if (AdornedControl is { })
        {
            ControlSelection?.Unregister(this);
        }
    }
    
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _thumbCenter = e.NameScope.Find<Thumb>("PART_ThumbCenter");
        _thumbLeft = e.NameScope.Find<Thumb>("PART_ThumbLeft");
        _thumbRight = e.NameScope.Find<Thumb>("PART_ThumbRight");
        _thumbTop = e.NameScope.Find<Thumb>("PART_ThumbTop");
        _thumbBottom = e.NameScope.Find<Thumb>("PART_ThumbBottom");
        _thumbTopLeft = e.NameScope.Find<Thumb>("PART_ThumbTopLeft");
        _thumbTopRight = e.NameScope.Find<Thumb>("PART_ThumbTopRight");
        _thumbBottomLeft = e.NameScope.Find<Thumb>("PART_ThumbBottomLeft");
        _thumbBottomRight = e.NameScope.Find<Thumb>("PART_ThumbBottomRight");

        if (_thumbCenter is { })
        {
            _thumbCenter.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbCenter.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbCenter.AddHandler(InputElement.PointerMovedEvent, ThumbCenter_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbLeft is { })
        {
            _thumbLeft.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbLeft.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbLeft.AddHandler(InputElement.PointerMovedEvent, ThumbLeft_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbRight is { })
        {
            _thumbRight.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbRight.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbRight.AddHandler(InputElement.PointerMovedEvent, ThumbRight_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbTop is { })
        {
            _thumbTop.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbTop.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbTop.AddHandler(InputElement.PointerMovedEvent, ThumbTop_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbBottom is { })
        {
            _thumbBottom.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbBottom.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbBottom.AddHandler(InputElement.PointerMovedEvent, ThumbBottom_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbTopLeft is { })
        {
            _thumbTopLeft.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbTopLeft.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbTopLeft.AddHandler(InputElement.PointerMovedEvent, ThumbTopLeft_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbTopRight is { })
        {
            _thumbTopRight.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbTopRight.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbTopRight.AddHandler(InputElement.PointerMovedEvent, ThumbTopRight_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbBottomLeft is { })
        {
            _thumbBottomLeft.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbBottomLeft.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbBottomLeft.AddHandler(InputElement.PointerMovedEvent, ThumbBottomLeft_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }

        if (_thumbBottomRight is { })
        {
            _thumbBottomRight.AddHandler(InputElement.PointerPressedEvent, Thumb_OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbBottomRight.AddHandler(InputElement.PointerReleasedEvent, Thumb_OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
            _thumbBottomRight.AddHandler(InputElement.PointerMovedEvent, ThumbBottomRight_OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        }
    }

    private void DragStarted()
    {
        if (AdornedControl is { } control)
        {
            ControlResizer?.Start(control);
        }
    }

    private void DragDeltaCenter(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Move(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaLeft(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Left(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaRight(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Right(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaTop(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Top(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaBottom(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Bottom(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaTopLeft(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Left(control, _startPointParent, vector);
            ControlResizer?.Top(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaTopRight(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Right(control, _startPointParent, vector);
            ControlResizer?.Top(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaBottomLeft(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Left(control, _startPointParent, vector);
            ControlResizer?.Bottom(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void DragDeltaBottomRight(Vector vector)
    {
        if (!_updating && AdornedControl is { } control)
        {
            _updating = true;
            ControlResizer?.Right(control, _startPointParent, vector);
            ControlResizer?.Bottom(control, _startPointParent, vector);
            _updating = false;
        }
    }

    private void Pressed(PointerPressedEventArgs e)
    {
        if (AdornedControl is {Parent: Control parent})
        {
            _startPointParent = e.GetPosition(parent);
            _isPressed = true;
            _isDragging = true;
            // e.Pointer.Capture(e.Source as IInputElement);
            DragStarted();
        }
    }

    private void Released(PointerReleasedEventArgs e)
    {
        if (_isDragging)
        {
            _isPressed = false;
            _isDragging = false;
            // e.Pointer.Capture(null);
        }
    }

    private void Moved(PointerEventArgs e, Action<Vector> action)
    {
        if (_isPressed)
        {
            if (!_isDragging)
            {
                _isDragging = true;
            }

            if (AdornedControl is {Parent: Control parent})
            {
                var point = e.GetPosition(parent);
                var vector = (Vector)(point - _startPointParent);
                action(vector);
            }
        }
    }

    private void Thumb_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        Pressed(e);
    }

    private void Thumb_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        Released(e);
    }

    private void ThumbCenter_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaCenter);
    }

    private void ThumbLeft_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaLeft);
    }

    private void ThumbRight_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaRight);
    }

    private void ThumbTop_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaTop);
    }

    private void ThumbBottom_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaBottom);
    }

    private void ThumbTopLeft_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaTopLeft);
    }

    private void ThumbTopRight_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaTopRight);
    }

    private void ThumbBottomLeft_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaBottomLeft);
    }

    private void ThumbBottomRight_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        Moved(e, DragDeltaBottomRight);
    }
}
