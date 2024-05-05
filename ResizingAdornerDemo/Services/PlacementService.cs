using System;
using Avalonia;
using Avalonia.Controls;
using ResizingAdorner.Controls;
using ResizingAdorner.Utilities;

namespace ResizingAdorner.Placement;

public class PlacementService
{
    private Control FinDropControl(Control control)
    {
        var adorner = HitTestHelper.FindControl<ResizingAdornerPresenter>(control);
        if (adorner is { AdornedControl: { } })
        {
            if (adorner.AdornedControl is ResizingAdornerPresenter)
            {
                return FinDropControl(adorner.AdornedControl);
            }
            control = adorner.AdornedControl;
        }

        return control;
    }

    public void DropControl(Control target, Point point, Type type)
    {
        target = FinDropControl(target);

        Global.ControlDefaults.TryGetValue(type, out var controlDefaults);

        if (Global.ControlEditors.TryGetValue(target.GetType(), out var controlEditor))
        {
            controlEditor.Insert(type, point, target, controlDefaults);
        }
    }
}
