using Godot;

namespace GDebugPanelGodot.Extensions;

public static class NodeExtensions
{
    public static void RemoveParent(this Node node)
    {
        Node parent = node.GetParent();

        if (parent == null)
        {
            return;
        }
        
        parent.RemoveChild(node);
    }

    public static void SetParent(this Node node, Node parent)
    {
        node.RemoveParent();
        parent.AddChild(node);
    }
    
    public static void SetSiblingIndex(this Node node, int index)
    {
        Node parent = node.GetParent();

        if (parent == null)
        {
            return;
        }

        int childsCount = parent.GetChildren().Count;
        int finalIndex = GUtils.Extensions.MathExtensions.Clamp(index, 0, childsCount);
        
        parent.MoveChild(node, finalIndex);
    }
}