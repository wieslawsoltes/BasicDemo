using Avalonia.Controls;

namespace ResizingAdorner.Views;

public partial class ToolboxView : UserControl
{
    public ToolboxView()
    {
        InitializeComponent();

        Global.ToolboxManager?.Initialize(ControlTypes);
    }
}
