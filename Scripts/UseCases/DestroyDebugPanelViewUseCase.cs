using GDebugPanelGodot.Datas;
using GDebugPanelGodot.Extensions;

namespace GDebugPanelGodot.UseCases;

public static class DestroyDebugPanelViewUseCase
{
    public static void Execute(DebugPanelData debugPanelData)
    {
        if (debugPanelData.DebugPanelView == null)
        {
            return;
        }
        
        debugPanelData.DebugPanelView.RemoveParent();
        debugPanelData.DebugPanelView.QueueFree();

        debugPanelData.DebugPanelView = null;
    }
}