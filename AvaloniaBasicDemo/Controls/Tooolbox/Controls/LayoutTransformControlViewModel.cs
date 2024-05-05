using Avalonia.Controls;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class LayoutTransformControlViewModel : ToolboxControlViewModel
{
    public LayoutTransformControlViewModel()
    {
        Name = "LayoutTransformControl";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var layoutTransformControl = new LayoutTransformControl();
        layoutTransformControl.Width = 100d;
        layoutTransformControl.Height = 100d;
        // TODO: Preview
        return layoutTransformControl;
    }

    public override Control CreateControl()
    {
        var layoutTransformControl = new LayoutTransformControl();
        layoutTransformControl.Width = 100d;
        layoutTransformControl.Height = 100d;
        // TODO: Content
        return layoutTransformControl;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not LayoutTransformControl layoutTransformControl)
        {
            return;
        }

        // TODO: Preview
    }

    public override bool IsDropArea() => true;
}
