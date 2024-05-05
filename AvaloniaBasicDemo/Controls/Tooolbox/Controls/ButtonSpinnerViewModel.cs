using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ButtonSpinnerViewModel : ToolboxControlViewModel
{
    public ButtonSpinnerViewModel()
    {
        Name = "ButtonSpinner";
        Group = "Buttons";
    }

    public override Control CreatePreview()
    {
        var buttonSpinner = new ButtonSpinner();
        buttonSpinner.Content = "Button Spinner";
        buttonSpinner.Foreground = Brushes.Black;
        return buttonSpinner;
    }

    public override Control CreateControl()
    {
        var buttonSpinner = new ButtonSpinner();
        buttonSpinner.Content = "Button Spinner";
        //buttonSpinner.Foreground = Brushes.Blue;
        // TODO: Support setting Content
        return buttonSpinner;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ButtonSpinner buttonSpinner)
        {
            return;
        }

        buttonSpinner.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
