using Avalonia.Controls;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class DecoratorViewModel : ToolboxControlViewModel
{
    public DecoratorViewModel()
    {
        Name = "Decorator";
        Group = "Layout";
    }

    public override Control CreatePreview()
    {
        var decorator = new Decorator();
        decorator.Width = 100d;
        decorator.Height = 100d;
        // TODO: Preview
        return decorator;
    }

    public override Control CreateControl()
    {
        var decorator = new Decorator();
        decorator.Width = 100d;
        decorator.Height = 100d;
        // TODO: Content
        return decorator;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not Decorator decorator)
        {
            return;
        }

        // TODO: Preview
    }

    public override bool IsDropArea() => true;
}
