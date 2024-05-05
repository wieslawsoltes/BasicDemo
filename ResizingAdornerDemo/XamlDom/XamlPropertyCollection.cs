using System.Collections.Generic;

namespace ResizingAdorner.XamlDom;

public class XamlPropertyCollection
{
    public Dictionary<string, XamlProperty>? Properties { get; set; }

    public XamlProperty? this[string name] => Properties?[name];
}
