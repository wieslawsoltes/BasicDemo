using Avalonia;

namespace AvaloniaBasic.Behaviors;

public class DragSettings : AvaloniaObject
{
    public static readonly AttachedProperty<bool> IsDropAreaProperty = 
        AvaloniaProperty.RegisterAttached<AvaloniaObject, bool>("IsDropArea", typeof(DragSettings));

    public static readonly AttachedProperty<bool> IsDragAreaProperty = 
        AvaloniaProperty.RegisterAttached<AvaloniaObject, bool>("IsDragArea", typeof(DragSettings));

    public static readonly AttachedProperty<double> MinimumDragDeltaProperty = 
        AvaloniaProperty.RegisterAttached<AvaloniaObject, double>("MinimumDragDelta", typeof(DragSettings), defaultValue: 3d, inherits: true);

    public static readonly AttachedProperty<bool> SnapToGridProperty = 
        AvaloniaProperty.RegisterAttached<AvaloniaObject, bool>("SnapToGrid", typeof(DragSettings), defaultValue: false, inherits: true);

    public static readonly AttachedProperty<double> SnapXProperty = 
        AvaloniaProperty.RegisterAttached<AvaloniaObject, double>("SnapX", typeof(DragSettings), defaultValue: 10d, inherits: true);

    public static readonly AttachedProperty<double> SnapYProperty = 
        AvaloniaProperty.RegisterAttached<AvaloniaObject, double>("SnapY", typeof(DragSettings), defaultValue: 10d, inherits: true);

    public static readonly AttachedProperty<bool> EnableDragProperty = 
        AvaloniaProperty.RegisterAttached<AvaloniaObject, bool>("EnableDrag", typeof(DragSettings));

    public static bool GetIsDropArea(AvaloniaObject obj)
    {
        return obj.GetValue(IsDropAreaProperty);
    }

    public static void SetIsDropArea(AvaloniaObject obj, bool value)
    {
        obj.SetValue(IsDropAreaProperty, value);
    }

    public static bool GetIsDragArea(AvaloniaObject obj)
    {
        return obj.GetValue(IsDragAreaProperty);
    }

    public static void SetIsDragArea(AvaloniaObject obj, bool value)
    {
        obj.SetValue(IsDragAreaProperty, value);
    }

    public static double GetMinimumDragDelta(AvaloniaObject obj)
    {
        return obj.GetValue(MinimumDragDeltaProperty);
    }

    public static void SetMinimumDragDelta(AvaloniaObject obj, double value)
    {
        obj.SetValue(MinimumDragDeltaProperty, value);
    }

    public static bool GetSnapToGrid(AvaloniaObject obj)
    {
        return obj.GetValue(SnapToGridProperty);
    }

    public static void SetSnapToGrid(AvaloniaObject obj, bool value)
    {
        obj.SetValue(SnapToGridProperty, value);
    }

    public static double GetSnapX(AvaloniaObject obj)
    {
        return obj.GetValue(SnapXProperty);
    }

    public static void SetSnapX(AvaloniaObject obj, double value)
    {
        obj.SetValue(SnapXProperty, value);
    }
    
    public static double GetSnapY(AvaloniaObject obj)
    {
        return obj.GetValue(SnapYProperty);
    }

    public static void SetSnapY(AvaloniaObject obj, double value)
    {
        obj.SetValue(SnapYProperty, value);
    }

    public static void SetEnableDrag(AvaloniaObject obj, bool value)
    {
        obj.SetValue(EnableDragProperty, value);
    }

    public static bool GetEnableDrag(AvaloniaObject obj)
    {
        return obj.GetValue(EnableDragProperty);
    }
}
