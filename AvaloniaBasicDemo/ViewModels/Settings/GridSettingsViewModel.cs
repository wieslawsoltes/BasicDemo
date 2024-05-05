using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels.Settings;

public partial class GridSettingsViewModel : ObservableObject
{
    [ObservableProperty] private int _cellWidth;
    [ObservableProperty] private int _cellHeight;
    [ObservableProperty] private int _boldSeparatorHorizontalSpacing;
    [ObservableProperty] private int _boldSeparatorVerticalSpacing;
    [ObservableProperty] private bool _isGridEnabled;

    public GridSettingsViewModel()
    {
        _cellWidth = 10;
        _cellHeight = 10;
        _boldSeparatorHorizontalSpacing = 10;
        _boldSeparatorVerticalSpacing = 10;
        _isGridEnabled = true;
    }
}
