using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class BorderViewModel : ToolboxControlViewModel
{
    public BorderViewModel()
    {
        Name = "Border";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var border = new Border();
        border.Width = 100d;
        border.Height = 100d;
        border.Background = Brushes.Black;
        return border;
    }

    public override Control CreateControl()
    {
        var border = new Border();
        border.Width = 100d;
        border.Height = 100d;
        border.Background = Brushes.LightGray;
        // TODO: Support setting Child
        return border;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Border border)
        {
            return;
        }

        border.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
