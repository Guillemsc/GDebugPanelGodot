using GDebugPanelGodot.Datas;

namespace GDebugPanelGodot.UseCases;

public static class HasDebugPanelViewInstanceUseCase
{
    public static bool Execute(DebugPanelData debugPanelData)
    {
        return debugPanelData.DebugPanelView != null;
    }
}