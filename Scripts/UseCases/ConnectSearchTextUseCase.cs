using GDebugPanelGodot.Datas;
using GDebugPanelGodot.Extensions;

namespace GDebugPanelGodot.UseCases;

public static class ConnectSearchTextUseCase
{
    public static void Execute(DebugPanelData debugPanelData, DebugActionsData debugActionsData)
    {
        if (debugPanelData.DebugPanelView == null)
        {
            return;
        }

        void Refresh(string text)
            => RefreshWidgetVisibilityBySearchTextUseCase.Execute(debugPanelData, debugActionsData);
        
        debugPanelData.DebugPanelView.SearchLineEdit!.ConnectLineEditTextChanged(Refresh);
    }
}