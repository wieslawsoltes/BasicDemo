using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class SliderViewModel : ToolboxControlViewModel
{
    public SliderViewModel()
    {
        Name = "Slider";
        Group = "Value selectors";
    }

    public override Control CreatePreview()
    {
        var slider = new Slider();
        slider.Width = 100d;
        slider.Minimum = 0;
        slider.Maximum = 100;
        slider.Value = 50;
        slider.Background = Brushes.Black;
        return slider;
    }

    public override Control CreateControl()
    {
        var slider = new Slider();
        slider.Width = 100d;
        slider.Minimum = 0;
        slider.Maximum = 100;
        slider.Value = 50;
        slider.Background = Brushes.LightGray;
        return slider;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Slider slider)
        {
            return;
        }

        slider.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
