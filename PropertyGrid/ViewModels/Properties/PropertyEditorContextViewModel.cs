using AvaloniaBasic.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaBasic.ViewModels.Properties;

public partial class PropertyEditorContextViewModel : ObservableObject, IPropertyEditorContext
{
    [ObservableProperty] private object? _current;
    [ObservableProperty] private bool _isUpdating;
}
