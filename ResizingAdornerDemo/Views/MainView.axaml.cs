using System;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using ResizingAdorner.Controls;
using ResizingAdorner.XamlDom;

namespace ResizingAdorner.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        AttachedToVisualTree += OnAttachedToVisualTree;
        
        //Demo();
    }

    private void Demo()
    {
        var gridDemo = new GridDemo();
        if (gridDemo.Dom.Root is { })
        {
            var sb = new StringBuilder();
            var writer = new XamlStringWriter();

            writer.Write(gridDemo.Dom.Root, sb, 0);

            var xaml = sb.ToString();

            Console.WriteLine(xaml);

            // TODO:
            Content = gridDemo.Dom.Root.Control;
        }
    }

    private void OnAttachedToVisualTree(object? sender, VisualTreeAttachmentEventArgs e)
    {
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
