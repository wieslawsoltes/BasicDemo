using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace ResizingAdorner.XamlDom;

public class GridDemo
{
    public XamlDom Dom { get; }

    public XamlProperty? GetProperty<T>(string name)
    {
        if (XamlPropertyRegistry.Properties.TryGetValue(typeof(T), out var propertyCollection))
        {
            if (propertyCollection.Properties != null
                && propertyCollection.Properties.TryGetValue(name, out var property))
            {
                return property;
            }
        }

        return null;
    }
    
    public GridDemo()
    {
        var root = new XamlNode
        {
            ControlType = typeof(Grid),
            Values = new ()
            {
                ["Name"] = "Grid",
                ["Width"] = 500d,
                ["Height"] = 500d,
                ["Background"] = new SolidColorBrush(Colors.WhiteSmoke),
                ["ColumnDefinitions"] = ColumnDefinitions.Parse("100,*,100"),
                ["RowDefinitions"] = RowDefinitions.Parse("100,*,100"),
            },
            Children = new ()
            {
                new XamlNode
                {
                    ControlType = typeof(Ellipse),
                    Values = new ()
                    {
                        ["Fill"] = new SolidColorBrush(Colors.Red),
                        ["Grid.Column"] = 0,
                        ["Grid.Row"] = 0,
                    },   
                },
                new XamlNode
                {
                    ControlType = typeof(Rectangle),
                    Values = new ()
                    {
                        ["Fill"] = new SolidColorBrush(Colors.Green),
                        ["Grid.Column"] = 1,
                        ["Grid.Row"] = 1,
                    },   
                },
                new XamlNode
                {
                    ControlType = typeof(Rectangle),
                    Values = new ()
                    {
                        ["Fill"] = new SolidColorBrush(Colors.Blue),
                        ["Grid.Column"] = 2,
                        ["Grid.Row"] = 2,
                    },   
                },
            }
        };

        Dom = new XamlDom
        {
            Root = root
        };

        var factory = new AvaloniaObjectFactory();

        factory.CreateControl(Dom.Root);

        Dom.Root.Control?.Classes.Add("resizing");
    }
}
