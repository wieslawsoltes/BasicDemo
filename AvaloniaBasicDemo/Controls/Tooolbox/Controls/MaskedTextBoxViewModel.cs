using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class MaskedTextBoxViewModel : ToolboxControlViewModel
{
    public MaskedTextBoxViewModel()
    {
        Name = "MaskedTextBox";
        Group = "Text";
    }

    public override Control CreatePreview()
    {
        var maskedTextBox = new MaskedTextBox();
        maskedTextBox.Text = "Masked Text";
        maskedTextBox.Foreground = Brushes.Black;
        return maskedTextBox;
    }

    public override Control CreateControl()
    {
        var maskedTextBox = new MaskedTextBox();
        maskedTextBox.Text = "Masked Text";
        //maskedTextBox.Foreground = Brushes.Blue;
        return maskedTextBox;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not MaskedTextBox maskedTextBox)
        {
            return;
        }

        maskedTextBox.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
