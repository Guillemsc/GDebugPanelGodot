using GDebugPanelGodot.Datas;

namespace GDebugPanelGodot.UseCases;

public static class ClearDebugActionsWidgetsUseCase
{
    public static void Execute(DebugActionsData debugActionsData)
    {
        debugActionsData.SectionsViews.Clear();
        debugActionsData.Widgets.Clear();
    }
}