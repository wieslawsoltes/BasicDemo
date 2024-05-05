using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.ViewModels.Toolbox;

public class TreeViewViewModel : ToolboxControlViewModel
{
    public TreeViewViewModel()
    {
        Name = "TreeView";
        Group = "Data Display";
    }

    public override Control CreatePreview()
    {
        var treeView = new TreeView();
        treeView.Width = 100d;
        treeView.Height = 100d;
        treeView.Background = Brushes.Black;
        return treeView;
    }

    public override Control CreateControl()
    {
        var treeView = new TreeView();
        treeView.Width = 100d;
        treeView.Height = 100d;
        treeView.Background = Brushes.LightGray;
        return treeView;
    }

    public override void UpdatePreview(object control, bool isPointerOver)
    {
        if (control is not TreeView treeView)
        {
            return;
        }

        treeView.Background = isPointerOver ? Brushes.Green : Brushes.Red;
    }

    public override bool IsDropArea() => true;
}
