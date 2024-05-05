using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.LogicalTree;
using Avalonia.Threading;
using AvaloniaBasic.Model;
using AvaloniaBasic.Utilities;
using AvaloniaBasic.ViewModels.Properties;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData;
using DynamicData.Binding;

namespace AvaloniaBasic.ViewModels;

public partial class TreeViewModel : ObservableObject
{
    private readonly IPropertyEditorFactory _propertyEditorFactory;
    private readonly Dictionary<Type, TypePropertiesCache> _typePropertiesCache = new();
    private readonly Dictionary<AvaloniaObject, ObservableCollection<IProperty>> _propertiesCache = new();
    private readonly IPropertyEditorContext _editor = new PropertyEditorContextViewModel();
    [ObservableProperty] private ObservableCollection<LogicalViewModel> _logical;
    [ObservableProperty] private LogicalViewModel? _selectedLogical;
    private readonly SourceList<IProperty> _propertiesList;

    public TreeViewModel(IPropertyEditorFactory propertyEditorFactory)
    {
        _propertyEditorFactory = propertyEditorFactory;
        _logical = new ObservableCollection<LogicalViewModel>();

        _propertiesList = new SourceList<IProperty>();
        _propertiesList
            .Connect()
            .Bind(Properties)
            .Subscribe();

        LogicalSource = CreateLogicalTreeSource();
        PropertiesSource = CreatePropertiesSource();
    }

    public HierarchicalTreeDataGridSource<LogicalViewModel> LogicalSource { get; }

    public HierarchicalTreeDataGridSource<IProperty> PropertiesSource { get; }

    public ObservableCollectionExtended<IProperty> Properties { get; } = new();

    private HierarchicalTreeDataGridSource<LogicalViewModel> CreateLogicalTreeSource()
    {
        var logicalTreeSource = new HierarchicalTreeDataGridSource<LogicalViewModel>(Logical)
        {
            Columns =
            {
                new HierarchicalExpanderColumn<LogicalViewModel>(
                    inner: new TemplateColumn<LogicalViewModel>(
                        "Logical",
                        new FuncDataTemplate<LogicalViewModel>((_, _) =>
                        {
                            return new Label
                            {
                                [!ContentControl.ContentProperty] = new Binding("Name")
                            };
                        }, true),
                        options: new TemplateColumnOptions<LogicalViewModel>
                        {
                            CanUserResizeColumn = false,
                            CanUserSortColumn = false,
                        },
                        width: new GridLength(1, GridUnitType.Star)), 
                    childSelector: x => x.GetChildren(),
                    hasChildrenSelector: x => x.HasChildren,
                    isExpandedSelector: x => x.IsExpanded)
            }
        };

        logicalTreeSource.RowSelection!.SingleSelect = true;

        logicalTreeSource.RowSelection.SelectionChanged += (_, args) =>
        {
            SelectedLogical = args.SelectedItems.FirstOrDefault();

            UpdateProperties();
        };

        return logicalTreeSource;
    }

    private HierarchicalTreeDataGridSource<IProperty> CreatePropertiesSource()
    {
        var propertiesSource = new HierarchicalTreeDataGridSource<IProperty>(Properties)
        {
            Columns =
            {
                new HierarchicalExpanderColumn<IProperty>(
                    inner: new TextColumn<IProperty,string>(
                        "Property",
                        p => p.Name,
                        (p, value) => p.Name = value,
                        options: new TextColumnOptions<IProperty>
                        {
                            CanUserResizeColumn = true,
                            CanUserSortColumn = true,
                            CompareAscending = SortHelper.SortAscending<string?, IProperty>(x => x.Name),
                            CompareDescending = SortHelper.SortDescending<string?, IProperty>(x => x.Name)
                        },
                        width: new GridLength(1, GridUnitType.Star)), 
                    childSelector: x => x.GetChildren(),
                    hasChildrenSelector: x => x.HasChildren,
                    isExpandedSelector: x => x.IsExpanded),
                new TemplateColumn<IProperty>(
                    "Value",
                    new FuncDataTemplate<IProperty>((p, _) => CreatePropertyEditor(p)),
                    options: new TemplateColumnOptions<IProperty>
                    {
                        CanUserResizeColumn = true,
                        CanUserSortColumn = false
                    },
                    width: new GridLength(1, GridUnitType.Star))
            }
        };

        return propertiesSource;
    }

    private Control? CreatePropertyEditor(IProperty? p)
    {
        if (p is null)
        {
            return null;
        }

        if (p.IsEditable())
        {
            var editor = _propertyEditorFactory.CreateEditor(p);
            if (editor is Control control)
            {
                return control;
            }
        }

        return new TextBlock
        {
            [!TextBlock.TextProperty] = new Binding("Value"),
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
        };
    }

    private void UpdateProperties()
    {
        if (SelectedLogical?.Logical is not AvaloniaObject logical)
        {
            _editor.IsUpdating = true;
            _editor.Current = null;
            _editor.IsUpdating = false;
            return;
        }

        _editor.IsUpdating = true;
        _editor.Current = logical;

        if (_propertiesCache.TryGetValue(logical, out var cachedProperties))
        {
            _propertiesList.Edit(x =>
            {
                x.Clear();

                foreach (var property in cachedProperties)
                {
                    x.Add(property);
                }
            });

            _editor.IsUpdating = false;
            return;
        }

        var type = logical.GetType();
        if (!_typePropertiesCache.TryGetValue(type, out var typeProperties))
        {
            typeProperties = new TypePropertiesCache(type);
            _typePropertiesCache[type] = typeProperties;
        }

        var avaloniaProps = CreateAvaloniaProperties(logical, typeProperties);
        var avaloniaAttachedProps = CreateAttachedProperties(logical, typeProperties);
        var clrProps = CreateClrProperties(logical, typeProperties);

        var properties = new ObservableCollection<IProperty>
        {
            avaloniaProps, 
            avaloniaAttachedProps, 
            clrProps
        };

        _propertiesCache[logical] = properties;

        _propertiesList.Edit(x =>
        {
            x.Clear();

            foreach (var property in properties)
            {
                x.Add(property);
            }
        });

        _editor.IsUpdating = false;
    }

    private GroupPropertyViewModel CreateAvaloniaProperties(AvaloniaObject logical, TypePropertiesCache typePropertiesCache)
    {
        var avaloniaProps = new GroupPropertyViewModel
        {
            Name = "Properties",
            Children = new ObservableCollection<IProperty>()
        };

        foreach (var avaloniaProperty in typePropertiesCache.Properties)
        {
            var value = logical.GetValue(avaloniaProperty);
            var defaultValue = default(object);
            var metadata = avaloniaProperty.GetMetadata(avaloniaProperty.PropertyType);
            if (metadata is IStyledPropertyMetadata styledPropertyMetadata)
            {
                defaultValue = styledPropertyMetadata.DefaultValue;
            }
            else if (metadata is IDirectPropertyMetadata directPropertyMetadata)
            {
                defaultValue = directPropertyMetadata.UnsetValue;
            }

            var property = new AvaloniaPropertyViewModel(_editor, avaloniaProperty)
            {
                Name = avaloniaProperty.Name,
                Value = value,
                DefaultValue = defaultValue
            };

            // TODO: IsDirty

            avaloniaProps.Children.Add(property);
        }

        return avaloniaProps;
    }

    private GroupPropertyViewModel CreateAttachedProperties(AvaloniaObject logical, TypePropertiesCache typePropertiesCache)
    {
        var avaloniaAttachedProps = new GroupPropertyViewModel
        {
            Name = "Attached Properties",
            Children = new ObservableCollection<IProperty>()
        };

        foreach (var avaloniaAttachedProperty in typePropertiesCache.AttachedProperties)
        {
            var value = logical.GetValue(avaloniaAttachedProperty);
            var defaultValue = default(object);
            var metadata = avaloniaAttachedProperty.GetMetadata(avaloniaAttachedProperty.PropertyType);
            if (metadata is IStyledPropertyMetadata styledPropertyMetadata)
            {
                defaultValue = styledPropertyMetadata.DefaultValue;
            }
            else if (metadata is IDirectPropertyMetadata directPropertyMetadata)
            {
                defaultValue = directPropertyMetadata.UnsetValue;
            }

            var property = new AvaloniaPropertyViewModel(_editor, avaloniaAttachedProperty)
            {
                Name = $"{avaloniaAttachedProperty.OwnerType.Name}.{avaloniaAttachedProperty.Name}",
                Value = value,
                DefaultValue = defaultValue
            };

            // TODO: IsDirty

            avaloniaAttachedProps.Children.Add(property);
        }

        return avaloniaAttachedProps;
    }

    private GroupPropertyViewModel CreateClrProperties(AvaloniaObject logical, TypePropertiesCache typePropertiesCache)
    {
        var clrProps = new GroupPropertyViewModel
        {
            Name = "CLR Properties",
            Children = new ObservableCollection<IProperty>()
        };

        foreach (var clrProperty in typePropertiesCache.ClrProperties)
        {
            try
            {
                var value = clrProperty.GetValue(logical);

                // TODO: DefaultValue

                var property = new ClrPropertyViewModel(_editor, clrProperty)
                {
                    Name = clrProperty.Name,
                    Value = value
                };

                // TODO: IsDirty

                clrProps.Children.Add(property);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        return clrProps;
    }

    private void AddToLogicalTree(ILogical root, ObservableCollection<LogicalViewModel> tree)
    {
        var logicalViewModel = new LogicalViewModel()
        {
            Name = root.GetType().Name,
            Logical = root,
            IsExpanded = true
        };
        tree.Add(logicalViewModel);

        var logicalDescendants = root.GetLogicalChildren();
        foreach (var logical in logicalDescendants)
        {
            logicalViewModel.Children ??= new ObservableCollection<LogicalViewModel>();

            AddToLogicalTree(logical, logicalViewModel.Children);
        }
    }

    public void UpdateLogicalTree(ILogical root)
    {
        Dispatcher.UIThread.Post(
            () =>
            {
                Logical.Clear();

                AddToLogicalTree(root, Logical);
            }, 
            DispatcherPriority.Normal);
    }
}
