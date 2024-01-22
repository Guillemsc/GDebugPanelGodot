using Godot;

namespace GDebugPanelGodot.Extensions;

public static class CanvasItemExtensions
{
    public static void SetActiveCanvasItem(this CanvasItem canvasItem, bool active)
    {
        canvasItem.ProcessMode = active ? Node.ProcessModeEnum.Inherit : Node.ProcessModeEnum.Disabled;
        canvasItem.Visible = active;
    }
    
    public static bool IsActiveCanvasItem(this CanvasItem canvasItem)
    {
        return canvasItem.ProcessMode == Node.ProcessModeEnum.Inherit && canvasItem.Visible;
    }
}