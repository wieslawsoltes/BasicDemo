using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using ResizingAdorner.Controls;
using ResizingAdorner.Model;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Selection;

public class ControlSelection : IControlSelection
{
    private readonly List<Control> _adorners = new ();
    private TopLevel? _topLevel;
    private ResizingAdornerPresenter? _hover;
    private ResizingAdornerPresenter? _selected;

    public void Initialize(TopLevel topLevel)
    {
        _topLevel = topLevel;
        _topLevel.AddHandler(InputElement.PointerPressedEvent, OnPointerPressed, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
        _topLevel.AddHandler(InputElement.PointerMovedEvent, OnPointerMoved, RoutingStrategies.Tunnel | RoutingStrategies.Bubble);
    }

    public void DeInitialize()
    {
        if (_topLevel is { })
        {
            _topLevel.RemoveHandler(InputElement.PointerPressedEvent, OnPointerPressed);
            _topLevel.RemoveHandler(InputElement.PointerMovedEvent, OnPointerMoved);
            _topLevel = null;
        }
    }

    public void Register(Control adorner)
    {
        _adorners.Add(adorner);
    }

    public void Unregister(Control adorner)
    {
        _adorners.Remove(adorner);
    }

    public void Delete()
    {
        if (_selected is not { } resizingAdornerPresenter)
        {
            return;
        }

        if (resizingAdornerPresenter.AdornedControl is { } control)
        {
            _selected = null;
            _hover = null;
            Deselect();

            if (control.Parent is Panel panel)
            {
                panel.Children.Remove(control);
            }
        }
    }
    
    private void Select(ResizingAdornerPresenter? hover, ResizingAdornerPresenter? selected)
    {
        foreach (var adorner in _adorners)
        {
            if (adorner is ResizingAdornerPresenter resizingAdornerPresenter)
            {
                var showThumbs = Equals(resizingAdornerPresenter, hover) || Equals(resizingAdornerPresenter, selected);
                resizingAdornerPresenter.ShowThumbs = showThumbs;
            }
        }
    }

    private void Deselect()
    {
        foreach (var adorner in _adorners)
        {
            if (adorner is ResizingAdornerPresenter resizingAdornerPresenter)
            {
                resizingAdornerPresenter.ShowThumbs = false;
            }
        }
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (_topLevel is null)
        {
            return;
        }

        var selected = HitTestHelper.HitTest<ResizingAdornerPresenter>(e, _topLevel);
        if (selected != null)
        {
            _selected = selected;
            _hover = null;
            Select(_hover, _selected);
        }
        else
        {
            _selected = null;
            _hover = null;
            Deselect();
        }
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        if (_topLevel is null)
        {
            return;
        }

        var hitTest = HitTestHelper.HitTest<ResizingAdornerPresenter>(e, _topLevel);
        if (hitTest is { } && (Equals(hitTest, _hover) || Equals(hitTest, _selected)))
        {
            return;
        }

        _hover = hitTest;

        if (_hover is { } || _selected is { })
        {
            Select(_hover, _selected);
        }
        else
        {
            Deselect();
        }
    }
}
