using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaBasicDemo.Views;

public partial class ToolboxView : UserControl
{
    public ToolboxView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

