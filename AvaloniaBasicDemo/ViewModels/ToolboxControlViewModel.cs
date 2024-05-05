using AvaloniaBasic.Model;

namespace AvaloniaBasic.ViewModels;

public abstract partial class ToolboxControlViewModel : ToolboxItemViewModel, IToolboxControl
{
    public abstract object CreatePreview();

    public abstract object CreateControl();

    public abstract void UpdatePreview(object control, bool isPointerOver);

    public abstract bool IsDropArea();
}
