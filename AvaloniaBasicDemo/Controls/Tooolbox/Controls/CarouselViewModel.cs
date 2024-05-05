using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class CarouselViewModel : ToolboxControlViewModel
{
    public CarouselViewModel()
    {
        Name = "Carousel";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var carousel = new Carousel();
        carousel.Width = 100d;
        carousel.Height = 100d;
        carousel.Background = Brushes.Black;
        return carousel;
    }

    public override Control CreateControl()
    {
        var carousel = new Carousel();
        carousel.Width = 100d;
        carousel.Height = 100d;
        carousel.Background = Brushes.LightGray;
        return carousel;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Carousel carousel)
        {
            return;
        }

        carousel.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
