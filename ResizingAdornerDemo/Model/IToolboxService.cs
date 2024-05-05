using Avalonia.Controls;

namespace ResizingAdorner.Model;

public interface IToolboxService
{
    void Initialize(ListBox listBox);
    void DeInitialize();
}
