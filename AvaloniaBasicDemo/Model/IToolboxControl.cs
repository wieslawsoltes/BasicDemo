namespace AvaloniaBasic.Model;

public interface IToolboxControl
{
    object CreatePreview();

    object CreateControl();

    void UpdatePreview(object control, bool isPointerOver);

    bool IsDropArea();
}
