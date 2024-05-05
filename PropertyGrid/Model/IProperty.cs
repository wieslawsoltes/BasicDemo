using System;

namespace AvaloniaBasic.Model;

public interface IProperty : ITreeItem<IProperty>
{
    string? Name { get; set; }

    object? Value { get; set; }

    object? DefaultValue { get; set; }

    bool IsExpanded { get; set; }

    bool IsDirty { get; set; }

    Type GetValueType();

    bool IsReadOnly();

    bool IsEditable();
}
