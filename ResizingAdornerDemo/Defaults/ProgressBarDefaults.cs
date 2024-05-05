using Avalonia.Controls;
using Avalonia.Layout;
using ResizingAdorner.Model;

namespace ResizingAdorner.Defaults;

public class ProgressBarDefaults : IControlDefaults
{
    public void Auto(object control)
    {
        if (control is ProgressBar progressBar)
        {
            progressBar.Value = 50;
            progressBar.HorizontalAlignment = HorizontalAlignment.Stretch;
            progressBar.VerticalAlignment = VerticalAlignment.Stretch;
        }
    }

    public void Fixed(object control)
    {
        if (control is ProgressBar progressBar)
        {
            progressBar.Value = 50;
            progressBar.Height = 20;
            progressBar.Width = 150;
        }
    }
}