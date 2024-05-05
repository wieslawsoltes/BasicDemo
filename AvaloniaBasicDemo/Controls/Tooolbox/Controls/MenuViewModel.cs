using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class MenuViewModel : ToolboxControlViewModel
{
    public MenuViewModel()
    {
        Name = "Menu";
        Group = "Menus";
    }

    public override Control CreatePreview()
    {
        var menu = new Menu();
        menu.Width = 200d;
        menu.Height = 30d;
        menu.Background = Brushes.Black;
        return menu;
    }

    public override Control CreateControl()
    {
        var menu = new Menu();
        menu.Width = 200d;
        menu.Height = 30d;
        menu.Background = Brushes.LightGray;
        return menu;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Menu menu)
        {
            return;
        }

        menu.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
