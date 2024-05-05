using Avalonia.Controls;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ViewboxViewModel : ToolboxControlViewModel
{
    public ViewboxViewModel()
    {
        Name = "Viewbox";
        Group = "Content Display";
    }

    public override Control CreatePreview()
    {
        var viewbox = new Viewbox();
        viewbox.Width = 100d;
        viewbox.Height = 100d;
        // TODO: Preview
        return viewbox;
    }

    public override Control CreateControl()
    {
        var viewbox = new Viewbox();
        viewbox.Width = 100d;
        viewbox.Height = 100d;
        // TODO: Content
        return viewbox;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Viewbox viewbox)
        {
            return;
        }

        // TODO: Preview
    }

    public override bool IsDropArea() => true;
}
