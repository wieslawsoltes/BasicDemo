using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels.Settings;

public partial class DragSettingsViewModel : ObservableObject
{
    [ObservableProperty] private double _minimumDragDelta;
    [ObservableProperty] private bool _snapToGrid;
    [ObservableProperty] private double _snapX;
    [ObservableProperty] private double _snapY;
    [ObservableProperty] private bool _enableControlDrag;

    public DragSettingsViewModel()
    {
        _minimumDragDelta = 3d;
        _snapToGrid = true;
        _snapX = 10d;
        _snapY = 10d;
        _enableControlDrag = true;
    }
}
