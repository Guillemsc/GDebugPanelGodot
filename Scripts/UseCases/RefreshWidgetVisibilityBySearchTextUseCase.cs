using System.Collections.Generic;
using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.UseCases;

public static class RefreshWidgetVisibilityBySearchTextUseCase
{
    public static void Execute(DebugPanelData debugPanelData, DebugActionsData debugActionsData)
    {
        if (debugPanelData.DebugPanelView == null)
        {
            return;
        }

        string searchText = debugPanelData.DebugPanelView.SearchLineEdit!.Text;
        
        searchText = searchText.Replace(" ", "").ToLowerInvariant();

        foreach (KeyValuePair<DebugActionsSection, DebugPanelSectionView> section in debugActionsData.SectionsViews)
        {
            foreach (IDebugAction debugAction in section.Key.Actions)
            {
                bool visible = ShouldDebugActionBeVisibleWithSerachFieldUseCase.Execute(searchText, debugAction);

                bool widgetFound = debugActionsData.Widgets.TryGetValue(debugAction, out DebugActionWidget? widget);

                if (!widgetFound)
                {
                    continue;
                }
                
                bool needsToShowSection = visible && section.Key.Collapsed;
                
                if (needsToShowSection)
                {
                    SetSectionViewCollapsedUseCase.Execute(section.Value, false);
                }

                widget!.SetActiveCanvasItem(visible);
            }
        }
    }
}