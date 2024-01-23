using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.UseCases;

public static class RemoveDebugActionsSectionUseCase
{
    public static void Execute(DebugActionsData debugActionsData, IDebugActionsSection section)
    {
        if (section is not DebugActionsSection debugActionsSection)
        {
            return;
        }
        
        bool found = debugActionsData.Sections.Remove(debugActionsSection);

        if (!found)
        {
            return;
        }
        
        foreach (IDebugAction debugAction in debugActionsSection.Actions)
        {
            RemoveDebugActionWidgetUseCase.Execute(debugActionsData, debugAction);
        }
        
        debugActionsSection.Dispose();

        bool viewFound = debugActionsData.SectionsViews.TryGetValue(
            debugActionsSection, 
            out DebugPanelSectionView? sectionView
            );

        if (!viewFound)
        {
            return;
        }

        debugActionsData.SectionsViews.Remove(debugActionsSection);
        
        sectionView!.RemoveParent();
        sectionView!.QueueFree();
    }
}