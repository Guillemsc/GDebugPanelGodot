using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.UseCases;

public static class CreateDebugActionWidgetUseCase
{
    public static void Execute(
        DebugPanelData debugPanelData, 
        DebugActionsData debugActionsData, 
        DebugActionsSection section,
        IDebugAction debugAction,
        bool tryFindFocus = false
        )
    {
        bool hasInstance = debugPanelData.DebugPanelView != null;

        if (!hasInstance)
        {
            return;
        }

        bool sectionViewExists = debugActionsData.SectionsViews.TryGetValue(section, out DebugPanelSectionView? sectionView);

        if (!sectionViewExists)
        {
            return;
        }
        
        bool alreadyExists = debugActionsData.Widgets.ContainsKey(debugAction);

        if (alreadyExists)
        {
            return;
        }

        DebugActionWidget widget = debugAction.InstantiateWidget(debugPanelData.DebugPanelView!);
        widget.SetParent(sectionView!.ContentParent!);
        
        debugActionsData.Widgets.Add(debugAction, widget);

        if (tryFindFocus)
        {
            TryGrabFocusOnFirstDebugActionWidgetUseCase.Execute(debugActionsData);   
        }
    }
}