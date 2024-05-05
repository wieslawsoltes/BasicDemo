using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class RepeatButtonViewModel : ToolboxControlViewModel
{
    public RepeatButtonViewModel()
    {
        Name = "RepeatButton";
        Group = "Buttons";
    }

    public override Control CreatePreview()
    {
        var repeatButton = new RepeatButton();
        repeatButton.Content = "RepeatButton";
        repeatButton.Foreground = Brushes.Black;
        return repeatButton;
    }

    public override Control CreateControl()
    {
        var repeatButton = new RepeatButton();
        repeatButton.Content = "RepeatButton";
        //repeatButton.Foreground = Brushes.Blue;
        // TODO: Support setting Content
        return repeatButton;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not RepeatButton repeatButton)
        {
            return;
        }

        repeatButton.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
