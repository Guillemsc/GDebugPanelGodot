using GDebugPanelGodot.Datas;
using GDebugPanelGodot.Extensions;

namespace GDebugPanelGodot.UseCases;

public static class ConnectClearSearchTextUseCase
{
    public static void Execute(DebugPanelData debugPanelData, DebugActionsData debugActionsData)
    {
        if (debugPanelData.DebugPanelView == null)
        {
            return;
        }
        
        void Clear()
        {
            debugPanelData.DebugPanelView.SearchLineEdit!.Text = string.Empty;
            RefreshWidgetVisibilityBySearchTextUseCase.Execute(debugPanelData, debugActionsData);
        }
        
        debugPanelData.DebugPanelView.ClearSearchButton!.ConnectButtonPressed(Clear);
    }
}