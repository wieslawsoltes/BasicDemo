using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ContentControlViewModel : ToolboxControlViewModel
{
    public ContentControlViewModel()
    {
        Name = "ContentControl";
        Group = "Content Display";
    }

    public override Control CreatePreview()
    {
        var contentControl = new ContentControl();
        contentControl.Width = 100d;
        contentControl.Height = 100d;
        contentControl.Background = Brushes.Black;
        return contentControl;
    }

    public override Control CreateControl()
    {
        var contentControl = new ContentControl();
        contentControl.Width = 100d;
        contentControl.Height = 100d;
        contentControl.Background = Brushes.LightGray;
        return contentControl;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ContentControl contentControl)
        {
            return;
        }

        contentControl.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
