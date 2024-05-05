using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ItemsRepeaterViewModel : ToolboxControlViewModel
{
    public ItemsRepeaterViewModel()
    {
        Name = "ItemsRepeater";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var itemsRepeater = new ItemsRepeater();
        itemsRepeater.Width = 100d;
        itemsRepeater.Height = 100d;
        itemsRepeater.Background = Brushes.Black;
        return itemsRepeater;
    }

    public override Control CreateControl()
    {
        var itemsRepeater = new ItemsRepeater();
        itemsRepeater.Width = 100d;
        itemsRepeater.Height = 100d;
        itemsRepeater.Background = Brushes.LightGray;
        return itemsRepeater;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ItemsRepeater itemsRepeater)
        {
            return;
        }

        itemsRepeater.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
