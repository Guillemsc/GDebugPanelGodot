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
        IOrderedEnumerable<KeyValuePair<DebugActionsSection, DebugPanelSectionView>> orderedSectionViews = 
            debugActionsData.SectionsViews.OrderByDescending(o => o.Key.Priority);

        int index = 0;
        foreach (KeyValuePair<DebugActionsSection, DebugPanelSectionView> item in orderedSectionViews)
        {
            item.Value.SetSiblingIndex(index);
            ++index;
        }
    }
}