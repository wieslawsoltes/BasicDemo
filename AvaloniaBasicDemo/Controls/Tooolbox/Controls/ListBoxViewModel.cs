using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ListBoxViewModel : ToolboxControlViewModel
{
    public ListBoxViewModel()
    {
        Name = "ListBox";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var listBox = new ListBox();
        listBox.Width = 100d;
        listBox.Height = 100d;
        listBox.Background = Brushes.Black;
        return listBox;
    }

    public override Control CreateControl()
    {
        var listBox = new ListBox();
        listBox.Width = 100d;
        listBox.Height = 100d;
        listBox.Background = Brushes.LightGray;
        return listBox;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ListBox listBox)
        {
            return;
        }

        listBox.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
