namespace AvaloniaBasic.Model;

public interface IPropertyEditorContext
{
    object? Current { get; set; }

    bool IsUpdating { get; set; }
}
