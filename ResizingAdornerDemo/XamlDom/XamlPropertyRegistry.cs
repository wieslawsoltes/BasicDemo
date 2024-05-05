using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;

namespace ResizingAdorner.XamlDom;

public static class XamlPropertyRegistry
{
    public static Dictionary<Type, XamlPropertyCollection> Properties = new ()
    {
        [typeof(Grid)] = new XamlPropertyCollection
        {
            Properties = new()
            {
                ["Name"] = XamlProperty.CreateAvalonia<Grid>("Name"),
                ["Width"] = XamlProperty.CreateAvalonia<Grid>("Width"),
                ["Height"] = XamlProperty.CreateAvalonia<Grid>("Height"),
                ["Background"] = XamlProperty.CreateAvalonia<Grid>("Background"),
                ["ColumnDefinitions"] = XamlProperty.CreateClr<Grid>("ColumnDefinitions"),
                ["RowDefinitions"] = XamlProperty.CreateClr<Grid>("RowDefinitions"),
            }
        },
        [typeof(Ellipse)] = new XamlPropertyCollection
        {
            Properties = new()
            {
                ["Fill"] = XamlProperty.CreateAvalonia<Ellipse>("Fill"),
                ["Grid.Column"] = XamlProperty.CreateAvalonia<Grid>("Column"),
                ["Grid.Row"] = XamlProperty.CreateAvalonia<Grid>("Row"),
            }
        },
        [typeof(Rectangle)] = new XamlPropertyCollection
        {
            Properties = new()
            {
                ["Fill"] = XamlProperty.CreateAvalonia<Rectangle>("Fill"),
                ["Grid.Column"] = XamlProperty.CreateAvalonia<Grid>("Column"),
                ["Grid.Row"] = XamlProperty.CreateAvalonia<Grid>("Row"),
            }
        },
    };
}
