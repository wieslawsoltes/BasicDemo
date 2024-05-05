using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class AutoCompleteBoxViewModel : ToolboxControlViewModel
{
    public AutoCompleteBoxViewModel()
    {
        Name = "AutoCompleteBox";
        Group = "Text";
    }

    public override Control CreatePreview()
    {
        var autoCompleteBox = new AutoCompleteBox();
        autoCompleteBox.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        autoCompleteBox.SelectedItem = "Item 1";
        autoCompleteBox.Foreground = Brushes.Black;
        return autoCompleteBox;
    }

    public override Control CreateControl()
    {
        var autoCompleteBox = new AutoCompleteBox();
        autoCompleteBox.ItemsSource = new[] { "Item 1", "Item 2", "Item 3" };
        autoCompleteBox.SelectedItem = "Item 1";
        //autoCompleteBox.Foreground = Brushes.Blue;
        return autoCompleteBox;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not AutoCompleteBox autoCompleteBox)
        {
            return;
        }

        autoCompleteBox.Foreground = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
