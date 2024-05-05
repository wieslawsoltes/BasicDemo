using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ComboBoxViewModel : ToolboxControlViewModel
{
    public ComboBoxViewModel()
    {
        Name = "ComboBox";
        Group = "Value selectors";
    }

    public override Control CreatePreview()
    {
        var comboBox = new ComboBox();
        comboBox.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        comboBox.SelectedIndex = 0;
        comboBox.Foreground = Brushes.Black;
        return comboBox;
    }

    public override Control CreateControl()
    {
        var comboBox = new ComboBox();
        comboBox.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        comboBox.SelectedIndex = 0;
        //comboBox.Foreground = Brushes.Blue;
        return comboBox;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not ComboBox comboBox)
        {
            return;
        }

        comboBox.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
