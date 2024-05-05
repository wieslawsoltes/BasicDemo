using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class TextBoxViewModel : ToolboxControlViewModel
{
    public TextBoxViewModel()
    {
        Name = "TextBox";
        Group = "Text";
    }

    public override Control CreatePreview()
    {
        var textBox = new TextBox();
        textBox.Text = "Text";
        textBox.Foreground = Brushes.Black;
        return textBox;
    }

    public override Control CreateControl()
    {
        var textBox = new TextBox();
        textBox.Text = "Text";
        //textBox.Foreground = Brushes.Blue;
        return textBox;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not TextBox textBox)
        {
            return;
        }

        textBox.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
