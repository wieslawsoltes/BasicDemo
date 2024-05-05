using System.Collections.Generic;

namespace AvaloniaBasic.Model;

public interface IToolboxItemProvider
{
    IEnumerable<IToolboxItem> GetToolboxItems();
}
