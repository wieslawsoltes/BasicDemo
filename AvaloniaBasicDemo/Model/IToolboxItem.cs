namespace AvaloniaBasic.Model;

public interface IToolboxItem : ITreeItem<IToolboxItem>
{
    string? Name { get; set; }

    string? Group { get; set; }

    string? Icon { get; set; }

    bool IsExpanded { get; set; }
}
