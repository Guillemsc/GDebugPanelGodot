using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Containers;

namespace GDebugPanelGodot.UseCases;

public static class InstantiateDebugActionsWidgetsUseCase
{
    public static void Execute(DebugPanelData debugPanelData, DebugActionsData debugActionsData)
    {
        foreach (DebugActionsSection section in debugActionsData.Sections)
        {
            InstantiateDebugPanelSectionViewUseCase.Execute(debugPanelData, debugActionsData, section);
            
            foreach (IDebugAction debugAction in section.Actions)
            {
                CreateDebugActionWidgetUseCase.Execute(debugPanelData, debugActionsData, section, debugAction);
            }
        }
        
        ReorderSectionViewsByPriorityUseCase.Execute(debugActionsData);
    }
}