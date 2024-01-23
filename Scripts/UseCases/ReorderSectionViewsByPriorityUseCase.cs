using System.Collections.Generic;
using System.Linq;
using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.UseCases;

public static class ReorderSectionViewsByPriorityUseCase
{
    public static void Execute(DebugActionsData debugActionsData)
    {
        IOrderedEnumerable<DebugActionsSection> orderedSections = debugActionsData.Sections.OrderByDescending(
            o => o.Priority
        );
        
        int index = 0;
        foreach (DebugActionsSection debugActionsSection in orderedSections)
        {
            bool viewFound = debugActionsData.SectionsViews.TryGetValue(
                debugActionsSection,
                out DebugPanelSectionView? debugPanelSectionView
            );

            if (!viewFound)
            {
                continue;
            }
            
            debugPanelSectionView!.SetSiblingIndex(index);
            ++index;
        }
    }
}