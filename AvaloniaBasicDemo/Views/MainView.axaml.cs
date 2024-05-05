using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using AvaloniaBasic.ViewModels;
using ResizingAdorner.Controls;

namespace AvaloniaBasicDemo.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        AttachedToVisualTree += OnAttachedToVisualTree;
    }

    private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
        if (DataContext is MainViewModel mainViewModel)
        {
            mainViewModel.PreviewCanvas = PreviewCanvas;
            mainViewModel.Toolbox.PreviewCanvas = PreviewCanvas;
        } 

        if (this.GetVisualRoot() is TopLevel topLevel)
        {
            ResizingAdornerPresenter.s_controlSelection?.Initialize(topLevel);
        }
    }

    public void OnDelete()
    {
        ResizingAdornerPresenter.s_controlSelection?.Delete();
    }
}
