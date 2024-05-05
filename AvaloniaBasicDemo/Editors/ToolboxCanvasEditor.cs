using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using AvaloniaBasic.Behaviors;
using AvaloniaBasic.Model;
using AvaloniaBasic.Utilities;
using AvaloniaBasic.ViewModels;

namespace AvaloniaBasic.Editors;

public class ToolboxCanvasEditor
{
    private Point _start;
    private bool _started;
    private bool _isDragging;
    private Control? _previewControl;
    private Control? _dropArea;

    public Interactive? AssociatedObject { get; set; }

    public Canvas? PreviewCanvas { get; set; }

    public Canvas? DropAreaCanvas { get; set; }

    public void OnPointerPressed(PointerPressedEventArgs e)
    {
        if (AssociatedObject?.DataContext is not IToolboxControl)
        {
            return;
        }

        if (PreviewCanvas is null)
        {
            return;
        }

        _start = e.GetPosition(PreviewCanvas);
        _started = true;
    }
    
    public void OnPointerReleased(PointerReleasedEventArgs e)
    {
        if (PreviewCanvas is null || AssociatedObject is null)
        {
            return;
        }

        _started = false;

        if (!_isDragging)
        {
            return;
        }
        
        RemovePreview();

        if (_dropArea is { })
        {
            var point = e.GetPosition(_dropArea);

            AddControl(_dropArea, point);

            _dropArea = null;
        }

        _isDragging = false;
        e.Pointer.Capture(null);
    }

    public void OnPointerMoved(PointerEventArgs e)
    {
        if (PreviewCanvas is null || AssociatedObject is null)
        {
            return;
        }

        if (!_started)
        {
            return;
        }

        if (!_isDragging)
        {
            var point = e.GetPosition(PreviewCanvas);
            var minimumDragDelta = DragSettings.GetMinimumDragDelta(AssociatedObject);
            var delta = _start - point;

            if (Math.Abs(delta.X) > minimumDragDelta || Math.Abs(delta.Y) > minimumDragDelta)
            {
                _dropArea = ControlEditor.FindDropArea(AssociatedObject, point);
                if (_dropArea is { })
                {
                    point = e.GetPosition(_dropArea);
                    // Debug.WriteLine($"_dropArea={_dropArea}");
                }

                AddPreview(point);
                UpdatePreview();

                _isDragging = true;
                e.Pointer.Capture((IInputElement?)AssociatedObject);
            }
        }
        else
        {
            var point = e.GetPosition(PreviewCanvas);

            _dropArea = ControlEditor.FindDropArea(AssociatedObject, point);
            if (_dropArea is { })
            {
                point = e.GetPosition(_dropArea);
                // Debug.WriteLine($"_dropArea={_dropArea}");
            }

            MovePreview(point);
            UpdatePreview();
        }
    }

    private void AddPreview(Point point)
    {
        if (PreviewCanvas is null)
        {
            return;
        }

        if (AssociatedObject?.DataContext is IToolboxControl item)
        {
            point = SnapPoint(point, _dropArea is null);

            if (item.CreatePreview() is not Control control)
            {
                return;
            }

            _previewControl = control;

            Canvas.SetLeft(_previewControl, point.X);
            Canvas.SetTop(_previewControl, point.Y);

            PreviewCanvas.Children.Add(_previewControl);
        }
    }

    private void MovePreview(Point point)
    {
        if (AssociatedObject is null || _previewControl is null)
        {
            return;
        }

        point = SnapPoint(point, true);

        Canvas.SetLeft(_previewControl, point.X);
        Canvas.SetTop(_previewControl, point.Y);
    }

    private void UpdatePreview()
    {
        if (AssociatedObject is null || _previewControl is null)
        {
            return;
        }

        if (AssociatedObject?.DataContext is IToolboxControl item)
        {
            var isPointerOver = _dropArea is { };

            item.UpdatePreview(_previewControl, isPointerOver);
        }
    }

    private void RemovePreview()
    {
        if (AssociatedObject is null || PreviewCanvas is null || _previewControl is null)
        {
            return;
        }

        PreviewCanvas.Children.Remove(_previewControl);

        _previewControl = null;
    }

    private void AddControl(Control target, Point point)
    {
        if (AssociatedObject?.DataContext is not IToolboxControl item)
        {
            return;
        }

        if (item.CreateControl() is not Control control)
        {
            return;
        }

        if (item.IsDropArea())
        {
            DragSettings.SetIsDropArea(control, true);
            DragSettings.SetSnapToGrid(control, false);
        }

        point = SnapPoint(point, false);

        ControlEditor.AddControl(control, target, point);

        if (DropAreaCanvas?.DataContext is MainViewModel mainViewModel)
        {
            mainViewModel.Tree.UpdateLogicalTree(DropAreaCanvas);
        }
    }

    private Point SnapPoint(Point point, bool isPreview)
    {
        if (AssociatedObject is null)
        {
            return point;
        }

        AvaloniaObject snapObject = _dropArea ?? AssociatedObject;

        var snapToGrid = DragSettings.GetSnapToGrid(snapObject) && _dropArea is { };
        var snapX = DragSettings.GetSnapX(snapObject);
        var snapY = DragSettings.GetSnapY(snapObject);
        var snappedPoint = SnapHelper.SnapPoint(point, snapX, snapY, snapToGrid);

        if (_dropArea is { } && isPreview && PreviewCanvas is { })
        {
            var translatePoint = _dropArea.TranslatePoint(snappedPoint, PreviewCanvas);
            if (translatePoint is { })
            {
                snappedPoint = translatePoint.Value;
            }
        }

        return snappedPoint;
    }
}
