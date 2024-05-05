using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class CheckBoxViewModel : ToolboxControlViewModel
{
    public CheckBoxViewModel()
    {
        Name = "CheckBox";
        Group = "Value selectors";
    }

    public override Control CreatePreview()
    {
        var checkBox = new CheckBox();
        checkBox.Content = "CheckBox";
        checkBox.Foreground = Brushes.Black;
        return checkBox;
    }

    public override Control CreateControl()
    {
        var checkBox = new CheckBox();
        checkBox.Content = "CheckBox";
        //checkBox.Foreground = Brushes.Blue;
        // TODO: Support setting Content
        return checkBox;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not CheckBox checkBox)
        {
            return;
        }

        checkBox.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
