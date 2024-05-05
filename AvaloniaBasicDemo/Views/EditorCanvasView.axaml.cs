using Avalonia;
using Avalonia.Controls;
using AvaloniaBasic.ViewModels;

namespace AvaloniaBasicDemo.Views;

public partial class EditorCanvasView : UserControl
{
    public EditorCanvasView()
    {
        InitializeComponent();

        AttachedToVisualTree += OnAttachedToVisualTree;
    }

    private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        if (DataContext is MainViewModel mainViewModel)
        {
            mainViewModel.DropAreaCanvas = DropAreaCanvas;
            mainViewModel.Toolbox.DropAreaCanvas = DropAreaCanvas;

            mainViewModel.Tree.UpdateLogicalTree(DropAreaCanvas);
        } 
    }
}
