using Avalonia.Controls;
using Avalonia.Layout;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class SliderDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is Slider slider)
        {
            slider.Value = 50;
            slider.HorizontalAlignment = HorizontalAlignment.Stretch;
            slider.VerticalAlignment = VerticalAlignment.Stretch;
        }
    }

    public void Fixed(object control)
    {
        if (control is Slider slider)
        {
            slider.Value = 50;
            slider.Width = 150;
        }
    }
}