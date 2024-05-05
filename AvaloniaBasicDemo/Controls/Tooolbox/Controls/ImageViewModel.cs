using Avalonia.Controls;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class ImageViewModel : ToolboxControlViewModel
{
    public ImageViewModel()
    {
        Name = "Image";
        Group = "Images";
    }

    public override Control CreatePreview()
    {
        var image = new Image();
        image.Width = 100d;
        image.Height = 100d;
        // TODO: image.Background = Brushes.Black;
        return image;
    }

    public override Control CreateControl()
    {
        var image = new Image();
        image.Width = 100d;
        image.Height = 100d;
        // TODO: image.Background = Brushes.Blue;
        return image;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Image image)
        {
            return;
        }

        // TODO: image.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => false;
}
