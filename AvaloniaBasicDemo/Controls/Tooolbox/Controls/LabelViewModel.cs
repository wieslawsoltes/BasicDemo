using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class LabelViewModel : ToolboxControlViewModel
{
    public LabelViewModel()
    {
        Name = "Label";
        Group = "Content Display";
    }

    public override Control CreatePreview()
    {
        var label = new Label();
        label.Content = "Label";
        label.Foreground = Brushes.Black;
        return label;
    }

    public override Control CreateControl()
    {
        var label = new Label();
        label.Content = "Label";
        //label.Foreground = Brushes.Blue;
        // TODO: Support setting Content
        return label;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Label label)
        {
            return;
        }

        label.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
