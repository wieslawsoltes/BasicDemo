namespace AvaloniaBasic.Model;

public interface IPropertyEditorFactory
{
    void Register(IPropertyEditor propertyEditor);

    object? CreateEditor(IProperty property);
}
