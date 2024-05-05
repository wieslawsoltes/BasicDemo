using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class TextBlockViewModel : ToolboxControlViewModel
{
    public TextBlockViewModel()
    {
        Name = "TextBlock";
        Group = "Text";
    }

    public override Control CreatePreview()
    {
        var textBlock = new TextBlock();
        textBlock.Text = "Text";
        textBlock.Foreground = Brushes.Black;
        return textBlock;
    }

    public override Control CreateControl()
    {
        var textBlock = new TextBlock();
        textBlock.Text = "Text";
        //textBlock.Foreground = Brushes.Blue;
        return textBlock;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not TextBlock textBlock)
        {
            return;
        }

        textBlock.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
