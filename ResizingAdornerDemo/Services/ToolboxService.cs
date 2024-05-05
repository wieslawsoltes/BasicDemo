using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ResizingAdorner.Model;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Placement;

public class ToolboxService : IToolboxService
{
    private ListBox? _listBox;
    private PlacementService? _placementManager;
    private bool _isPressed;
    private bool _isDragging;
    private Point _start;
    private ListBoxItem? _dragListBoxItem;

    public void Initialize(ListBox listBox)
    {
        _listBox = listBox;
        _listBox.AddHandler(InputElement.PointerPressedEvent, OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        _listBox.AddHandler(InputElement.PointerReleasedEvent, OnPointerReleased, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        _listBox.AddHandler(InputElement.PointerMovedEvent, OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);

        _listBox.ItemsSource = ControlFactory.GetControlTypes();

        _placementManager = new PlacementService();
    }

    public void DeInitialize()
    {
        if (_listBox is { })
        {
            _listBox.RemoveHandler(InputElement.PointerPressedEvent, OnPointerPressed);
            _listBox.RemoveHandler(InputElement.PointerReleasedEvent, OnPointerReleased);
            _listBox.RemoveHandler(InputElement.PointerMovedEvent, OnPointerMoved);

            _listBox = null;
            _placementManager = null;
        }
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_listBox is null)
        {
            return;
        }

        var listBoxItem = HitTestHelper.HitTest<ListBoxItem>(e, _listBox);
        if (listBoxItem is { })
        {
            // Console.WriteLine($"Pressed: {listBoxItem}");

            _start = e.GetPosition(_listBox);
            _isPressed = true;
            _isDragging = false;
            _dragListBoxItem = listBoxItem;
            // e.Pointer.Capture(listBoxItem);
        }
    }

    private void OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        if (_listBox is null || _placementManager is null)
        {
            return;
        }

        if (_isDragging && _dragListBoxItem is {DataContext: Type type})
        {
            var topLevel = _listBox.GetVisualRoot() as TopLevel;
            if (topLevel is null)
            {
                return;
            }
            var p = e.GetPosition(topLevel);
            var inputElement = topLevel.InputHitTest(p);
            if (inputElement is Control control)
            {
                var point = e.GetPosition(control);
                _placementManager.DropControl(control, point, type);
            }
        }

        // Console.WriteLine($"Released: {_dragListBoxItem}");

        _isPressed = false;
        _isDragging = false;
        _dragListBoxItem = null;
        // e.Pointer.Capture(null);
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_listBox is null)
        {
            return;
        }

        if (_isPressed)
        {
            if (!_isDragging)
            {
                var point = e.GetPosition(_listBox);
                var deltaX = Math.Abs((_start - point).X);
                var deltaY = Math.Abs((_start - point).Y);
                if (deltaX > 3d || deltaY > 3d)
                {
                    _isDragging = true;
                }
            }
            else
            {
                // TODO: Move preview

                var topLevel = _listBox.GetVisualRoot() as TopLevel;
                var p = e.GetPosition(topLevel);
                var inputElement = topLevel?.InputHitTest(p);
                if (inputElement is { })
                {
                    // TODO: Drop preview
                }

                // Console.WriteLine($"Move: {_dragListBoxItem}");
            }
        }
    }
}
