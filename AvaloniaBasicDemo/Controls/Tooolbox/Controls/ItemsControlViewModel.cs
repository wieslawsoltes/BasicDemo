using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ItemsControlViewModel : ToolboxControlViewModel
{
    public ItemsControlViewModel()
    {
        Name = "ItemsControl";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var itemsControl = new ItemsControl();
        itemsControl.Width = 100d;
        itemsControl.Height = 100d;
        itemsControl.Background = Brushes.Black;
        return itemsControl;
    }

    public override Control CreateControl()
    {
        var itemsControl = new ItemsControl();
        itemsControl.Width = 100d;
        itemsControl.Height = 100d;
        itemsControl.Background = Brushes.LightGray;
        return itemsControl;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ItemsControl itemsControl)
        {
            return;
        }

        itemsControl.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
