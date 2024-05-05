using Avalonia.Controls;
using Avalonia.Input;

namespace ResizingAdorner.Utilities;

public static class HitTestHelper
{
    public static T? FindControl<T>(Control control) where T : Control
    {
        if (control is T result)
        {
            return result;
        }

        if (control.Parent is T resultParent)
        {
            return resultParent;
        }

        return control.Parent is not Control controlParent 
            ? null 
            : FindControl<T>(controlParent);
    }

    public static T? HitTest<T>(PointerEventArgs e, Control relativeTo) where T : Control
    {
        return relativeTo.InputHitTest(e.GetPosition(relativeTo)) is not Control control 
            ? default 
            : FindControl<T>(control) ?? default;
    }
}