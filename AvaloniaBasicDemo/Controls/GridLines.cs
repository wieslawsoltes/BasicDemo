using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaBasic.Controls;

public sealed class GridLines : Control
{
    public static readonly StyledProperty<int> CellWidthProperty = 
        AvaloniaProperty.Register<GridLines, int>(nameof(CellWidth), 10);

    public static readonly StyledProperty<int> CellHeightProperty = 
        AvaloniaProperty.Register<GridLines, int>(nameof(CellHeight), 10);

    public static readonly StyledProperty<int> BoldSeparatorHorizontalSpacingProperty = 
        AvaloniaProperty.Register<GridLines, int>(nameof(BoldSeparatorHorizontalSpacing), 10);

    public static readonly StyledProperty<int> BoldSeparatorVerticalSpacingProperty = 
        AvaloniaProperty.Register<GridLines, int>(nameof(BoldSeparatorVerticalSpacing), 10);

    public static readonly StyledProperty<bool> IsGridEnabledProperty = 
        AvaloniaProperty.Register<GridLines, bool>(nameof(IsGridEnabled), true);

    private readonly Pen _pen;
    private readonly Pen _penBold;

    public int CellWidth
    {
        get => GetValue(CellWidthProperty);
        set => SetValue(CellWidthProperty, value);
    }

    public int CellHeight
    {
        get => GetValue(CellHeightProperty);
        set => SetValue(CellHeightProperty, value);
    }

    public int BoldSeparatorHorizontalSpacing
    {
        get => GetValue(BoldSeparatorHorizontalSpacingProperty);
        set => SetValue(BoldSeparatorHorizontalSpacingProperty, value);
    }

    public int BoldSeparatorVerticalSpacing
    {
        get => GetValue(BoldSeparatorVerticalSpacingProperty);
        set => SetValue(BoldSeparatorVerticalSpacingProperty, value);
    }

    public bool IsGridEnabled
    {
        get => GetValue(IsGridEnabledProperty);
        set => SetValue(IsGridEnabledProperty, value);
    }

    public GridLines()
    {
        _pen = new Pen(new SolidColorBrush(Color.FromArgb((byte)(255.0 * 0.1), 14, 94, 253))); 
        _penBold = new Pen(new SolidColorBrush(Color.FromArgb((byte)(255.0 * 0.3), 14, 94, 253)));
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        
        if (change.Property == CellWidthProperty
            || change.Property == CellHeightProperty
            || change.Property == BoldSeparatorHorizontalSpacingProperty
            || change.Property == BoldSeparatorVerticalSpacingProperty
            || change.Property == IsGridEnabledProperty)
        {
            InvalidateVisual();
        }
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        if (!IsGridEnabled)
        {
            return;
        }

        var cellWidth = CellWidth;
        var cellHeight = CellHeight;
        var boldSeparatorHorizontalSpacing = BoldSeparatorHorizontalSpacing;
        var boldSeparatorVerticalSpacing = BoldSeparatorVerticalSpacing;
        var width = Bounds.Width;
        var height = Bounds.Height;

        for(var i = 1; i < height / cellHeight; i++)
        {
            var pen = i % boldSeparatorVerticalSpacing == 0 ? _penBold : _pen;
            context.DrawLine(
                pen, 
                new Point(0 + 0.5, i * cellHeight + 0.5), 
                new Point(width + 0.5, i * cellHeight + 0.5));
        }

        for (var i = 1; i < width / cellWidth; i++)
        {
            var pen = i % boldSeparatorHorizontalSpacing == 0 ? _penBold : _pen;
            context.DrawLine(
                pen, 
                new Point(i * cellWidth + 0.5, 0 + 0.5), 
                new Point(i * cellWidth + 0.5, height + 0.5));
        }
    }
}
