using Avalonia.Controls;

namespace ResizingAdorner.Model;

public interface IControlSelection
{
    void Initialize(TopLevel topLevel);
    void DeInitialize();
    void Register(Control adorner);
    void Unregister(Control adorner);
    void Delete();
}
