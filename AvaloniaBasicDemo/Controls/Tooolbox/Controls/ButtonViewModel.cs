using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ButtonViewModel : ToolboxControlViewModel
{
    public ButtonViewModel()
    {
        Name = "Button";
        Group = "Buttons";
    }

    public override Control CreatePreview()
    {
        var button = new Button();
        button.Content = "Button";
        button.Foreground = Brushes.Black;
        return button;
    }

    public override Control CreateControl()
    {
        var button = new Button();
        button.Content = "Button";
        //button.Foreground = Brushes.Blue;
        // TODO: Support setting Content
        return button;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Button button)
        {
            return;
        }

        button.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
