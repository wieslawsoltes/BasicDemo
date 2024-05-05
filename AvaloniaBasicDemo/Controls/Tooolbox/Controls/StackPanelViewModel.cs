using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class StackPanelViewModel : ToolboxControlViewModel
{
    public StackPanelViewModel()
    {
        Name = "StackPanel";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var stackPanel = new StackPanel();
        stackPanel.Width = 100d;
        stackPanel.Height = 100d;
        stackPanel.Background = Brushes.Black;
        return stackPanel;
    }

    public override Control CreateControl()
    {
        var stackPanel = new StackPanel();
        stackPanel.Width = 100d;
        stackPanel.Height = 100d;
        stackPanel.Background = Brushes.LightGray;
        return stackPanel;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not StackPanel stackPanel)
        {
            return;
        }

        stackPanel.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
