using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class SeparatorViewModel : ToolboxControlViewModel
{
    public SeparatorViewModel()
    {
        Name = "Separator";
        Group = "Menus";
    }

    public override Control CreatePreview()
    {
        var separator = new Separator();
        separator.Width = 100d;
        separator.Height = 1d;
        separator.Background = Brushes.Black;
        return separator;
    }

    public override Control CreateControl()
    {
        var separator = new Separator();
        separator.Width = 100d;
        separator.Height = 1d;
        separator.Background = Brushes.Gray;
        return separator;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Separator separator)
        {
            return;
        }

        separator.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
