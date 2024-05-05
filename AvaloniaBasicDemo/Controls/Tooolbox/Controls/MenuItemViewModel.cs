using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class MenuItemViewModel : ToolboxControlViewModel
{
    public MenuItemViewModel()
    {
        Name = "MenuItem";
        Group = "Menus";
    }

    public override Control CreatePreview()
    {
        var menuItem = new MenuItem();
        menuItem.Header = "MenuItem";
        menuItem.Background = Brushes.Black;
        return menuItem;
    }

    public override Control CreateControl()
    {
        var menuItem = new MenuItem();
        menuItem.Header = "MenuItem";
        return menuItem;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not MenuItem menuItem)
        {
            return;
        }

        menuItem.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
