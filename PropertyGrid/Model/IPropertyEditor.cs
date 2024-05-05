namespace AvaloniaBasic.Model;

public interface IPropertyEditor
{
    bool Match(IProperty property);

    object Create(IProperty property);
}
