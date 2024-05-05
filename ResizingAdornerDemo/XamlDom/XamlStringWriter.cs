using System;
using System.Text;

namespace ResizingAdorner.XamlDom;

public class XamlStringWriter
{
    public void Write(XamlNode xamlNode, StringBuilder sb, int indentLevel)
    {
        if (xamlNode.ControlType is null)
        {
            return;
        }

        var properties = xamlNode.PropertyCollection;
        if (properties is null)
        {
            throw new Exception();
        }

        var hasContent = false;

        if (indentLevel > 0)
        {
            sb.Append(new string(' ', indentLevel * 2));
        }
        
        sb.Append('<');
        sb.Append(xamlNode.ControlType.Name);

        if (xamlNode.Values is { })
        {
            foreach (var kvp in xamlNode.Values)
            {
                if (kvp.Value is null)
                {
                    continue;
                }

                var name = kvp.Key;
                var property = properties[name];
                if (property is null)
                {
                    throw new Exception();
                }

                if (property.AvaloniaProperty is {IsAttached: true})
                {
                    name = property.AvaloniaProperty.OwnerType.Name + "." + name;
                }
                
                sb.Append(' ');
                sb.Append(name);
                sb.Append('=');
                sb.Append('"');
                sb.Append(kvp.Value);
                sb.Append('"');
            }
        }

        if (xamlNode.Child is { })
        {
            sb.Append('>');
            sb.AppendLine();

            var childLevel = indentLevel + 1;

            Write(xamlNode.Child, sb, childLevel);

            hasContent = true;
        }

        if (xamlNode.Children is {Count: > 0})
        {
            sb.Append('>');
            sb.AppendLine();

            var childrenLevel = indentLevel + 1;

            foreach (var child in xamlNode.Children)
            {
                Write(child, sb, childrenLevel);
            }

            hasContent = true;
        }

        if (hasContent)
        {
            sb.Append(new string(' ', indentLevel * 2));
            sb.Append('<');
            sb.Append('/');
            sb.Append(xamlNode.ControlType.Name);
            sb.Append('>');
            sb.AppendLine();
        }
        else
        {
            sb.Append(' ');
            sb.Append('/');
            sb.Append('>');
            sb.AppendLine();
        }
    } 
}
