using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using AvaloniaBasic.Services;
using AvaloniaBasic.Services.PropertyEditors;
using AvaloniaBasic.ViewModels.Settings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaBasic.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private ToolboxViewModel _toolbox;
    [ObservableProperty] private TreeViewModel _tree;
    [ObservableProperty] private DragSettingsViewModel _dragSettings;
    [ObservableProperty] private GridSettingsViewModel _gridSettings;
    [ObservableProperty] private Canvas? _previewCanvas;
    [ObservableProperty] private Canvas? _dropAreaCanvas;
    [ObservableProperty] private string _xaml;
    [ObservableProperty] private bool _enableResizing;
    private IStorageFile? _openFile;

    public MainViewModel()
    {
        var toolboxItemProvider = new DefaultToolboxItemProvider();

        _toolbox = new ToolboxViewModel(toolboxItemProvider);

        var propertyEditorFactory = new PropertyEditorFactory();
        propertyEditorFactory.Register(new BooleanPropertyEditor());
        propertyEditorFactory.Register(new StringPropertyEditor());
        propertyEditorFactory.Register(new EnumPropertyEditor());
        propertyEditorFactory.Register(new DefaultPropertyEditor());

        _tree = new TreeViewModel(propertyEditorFactory);

        _dragSettings = new DragSettingsViewModel();
        _gridSettings = new GridSettingsViewModel();

        _xaml = "";

        PropertyChanged += async (_, args) =>
        {
            if (args.PropertyName == nameof(Xaml))
            {
                await Run(Xaml);
            }
        };

        OpenFileCommand = new AsyncRelayCommand(async () => await OpenFile());

        SaveFileCommand = new AsyncRelayCommand(async () => await SaveFile());
    }

    public ICommand OpenFileCommand { get; }

    public ICommand SaveFileCommand { get; }

    private async Task Run(string xaml)
    {
        var control = AvaloniaRuntimeXamlLoader.Parse<Control?>(xaml);
        if (control is { })
        {
            // TODO:
        }

        await Task.CompletedTask;
    }

    private static List<FilePickerFileType> GetFileTypes()
    {
        return new List<FilePickerFileType>
        {
            StorageService.Axaml,
            StorageService.Xaml,
            StorageService.All
        };
    }

    private async Task OpenFile()
    {
        var storageProvider = StorageService.GetStorageProvider();
        if (storageProvider is null)
        {
            return;
        }

        var result = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open xaml",
            FileTypeFilter = GetFileTypes(),
            AllowMultiple = false
        });

        var file = result.FirstOrDefault();
        if (file is not null)
        {
            try
            {
                _openFile = file;

                await using var stream = await _openFile.OpenReadAsync();
                using var reader = new StreamReader(stream);
                var xaml = await reader.ReadToEndAsync();

                Xaml = xaml;

                await Run(xaml);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }
    }

    private async Task SaveFile()
    {
        if (_openFile is null)
        {
            var storageProvider = StorageService.GetStorageProvider();
            if (storageProvider is null)
            {
                return;
            }

            var file = await storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
            {
                Title = "Save xaml",
                FileTypeChoices = GetFileTypes(),
                SuggestedFileName = Path.GetFileNameWithoutExtension("Control"),
                DefaultExtension = "axaml",
                ShowOverwritePrompt = true
            });

            if (file is not null)
            {
                try
                {
                    _openFile = file;
                    await using var stream = await _openFile.OpenWriteAsync();
                    await using var writer = new StreamWriter(stream);
                    await writer.WriteAsync(Xaml);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
        }
        else
        {
            await using var stream = await _openFile.OpenWriteAsync();
            await using var writer = new StreamWriter(stream);
            await writer.WriteAsync(Xaml);
        }
    }
}
