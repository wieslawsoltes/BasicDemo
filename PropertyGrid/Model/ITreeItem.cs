using System.Collections.Generic;

namespace AvaloniaBasic.Model;

public interface ITreeItem<out T>
{
    bool HasChildren { get; }

    IEnumerable<T>? GetChildren();
}
