using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ToggleButtonViewModel : ToolboxControlViewModel
{
    public ToggleButtonViewModel()
    {
        Name = "ToggleButton";
        Group = "Buttons";
    }

    public override Control CreatePreview()
    {
        var toggleButton = new ToggleButton();
        toggleButton.Content = "ToggleButton";
        toggleButton.Foreground = Brushes.Black;
        return toggleButton;
    }

    public override Control CreateControl()
    {
        var toggleButton = new ToggleButton();
        toggleButton.Content = "ToggleButton";
        //toggleButton.Foreground = Brushes.Blue;
        // TODO: Support setting Content
        return toggleButton;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ToggleButton toggleButton)
        {
            return;
        }

        toggleButton.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
