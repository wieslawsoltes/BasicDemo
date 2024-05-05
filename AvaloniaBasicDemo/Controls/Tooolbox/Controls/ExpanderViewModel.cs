using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ExpanderViewModel : ToolboxControlViewModel
{
    public ExpanderViewModel()
    {
        Name = "Expander";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var expander = new Expander();
        expander.Width = 100d;
        expander.Height = 100d;
        expander.Background = Brushes.Black;
        return expander;
    }

    public override Control CreateControl()
    {
        var expander = new Expander();
        expander.Width = 100d;
        expander.Height = 100d;
        expander.Background = Brushes.LightGray;
        return expander;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Expander expander)
        {
            return;
        }

        expander.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
