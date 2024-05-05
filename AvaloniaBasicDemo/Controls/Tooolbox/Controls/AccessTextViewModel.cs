using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class AccessTextViewModel : ToolboxControlViewModel
{
    public AccessTextViewModel()
    {
        Name = "AccessText";
        Group = "Text";
    }

    public override Control CreatePreview()
    {
        var accessText = new AccessText();
        accessText.Text = "Access Text";
        accessText.Foreground = Brushes.Black;
        return accessText;
    }

    public override Control CreateControl()
    {
        var accessText = new AccessText();
        accessText.Text = "Access Text";
        //accessText.Foreground = Brushes.Blue;
        return accessText;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not AccessText accessText)
        {
            return;
        }

        accessText.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
