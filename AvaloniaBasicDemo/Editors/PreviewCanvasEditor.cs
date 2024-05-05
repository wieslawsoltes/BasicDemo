using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using AvaloniaBasic.Behaviors;
using AvaloniaBasic.Utilities;

namespace AvaloniaBasic.Editors;

public class PreviewCanvasEditor
{
    private Control? _dragArea;
    private Point _start;
    private Point _position;

    public Interactive? AssociatedObject { get; set; }

    public Canvas? PreviewCanvas { get; set; }

    public Canvas? DropAreaCanvas { get; set; }

    public void OnPointerPressed(PointerPressedEventArgs e)
    {
        if (AssociatedObject is null)
        {
            return;
        }

        var root = AssociatedObject.GetVisualRoot();
        var point = e.GetPosition(root as Visual);
        var dragArea = ControlEditor.FindDragArea(AssociatedObject, point);
        if (dragArea is null)
        {
            return;
        }

        var enableDrag = DragSettings.GetEnableDrag(AssociatedObject);
        if (!enableDrag)
        {
            return;
        }

        _dragArea = dragArea;

        if (_dragArea.Parent is Canvas canvas)
        {
            _start = e.GetPosition(canvas);

            var left = Canvas.GetLeft(_dragArea);
            var top = Canvas.GetTop(_dragArea);
            _position = new Point(left, top);
        }

        e.Pointer.Capture((IInputElement?)AssociatedObject);
        e.Handled = true;

        // Debug.WriteLine($"Control: {dragArea}, Parent: {dragArea.Parent}");
    }

    public void OnPointerReleased(PointerReleasedEventArgs e)
    {
        if (AssociatedObject is null)
        {
            return;
        }

        if (_dragArea is null)
        {
            return;
        }

        var enableDrag = DragSettings.GetEnableDrag(AssociatedObject);
        if (!enableDrag)
        {
            return;
        }

        _dragArea = null;
        e.Handled = true;
        e.Pointer.Capture(null);
    }

    public void OnPointerMoved(PointerEventArgs e)
    {
        if (AssociatedObject is null)
        {
            return;
        }

        if (_dragArea is null)
        {
            return;
        }

        var enableDrag = DragSettings.GetEnableDrag(AssociatedObject);
        if (!enableDrag)
        {
            return;
        }

        if (_dragArea.Parent is Canvas canvas)
        {
            var position = e.GetPosition(canvas);
            var delta = position - _start;

            position = new Point(_position.X + delta.X, _position.Y + delta.Y);
            position = SnapPoint(AssociatedObject, position);

            Canvas.SetLeft(_dragArea, position.X);
            Canvas.SetTop(_dragArea, position.Y);
        }

        e.Handled = true;
    }

    private static Point SnapPoint(AvaloniaObject? snapObject, Point point)
    {
        if (snapObject is null)
        {
            return point;
        }

        var snapToGrid = DragSettings.GetSnapToGrid(snapObject);
        var snapX = DragSettings.GetSnapX(snapObject);
        var snapY = DragSettings.GetSnapY(snapObject);
        var snappedPoint = SnapHelper.SnapPoint(point, snapX, snapY, snapToGrid);

        return snappedPoint;
    }
}
