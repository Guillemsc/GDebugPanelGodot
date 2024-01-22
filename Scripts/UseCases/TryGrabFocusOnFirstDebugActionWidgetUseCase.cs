using System.Linq;
using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.DebugActions.Widgets;
using Godot;

namespace GDebugPanelGodot.UseCases;

public static class TryGrabFocusOnFirstDebugActionWidgetUseCase
{
    public static void Execute(DebugActionsData debugActionsData)
    {
        IOrderedEnumerable<DebugActionsSection> orderedSections = 
            debugActionsData.Sections.OrderByDescending(o => o.Priority);

        foreach (DebugActionsSection section in orderedSections)
        {
            foreach (IDebugAction debugAction in section.Actions)
            {
                bool found = debugActionsData.Widgets.TryGetValue(debugAction, out DebugActionWidget? debugActionWidget);

                if (!found)
                {
                    continue;
                }
                
                bool couldGrabFocus = debugActionWidget!.Focus();

                if (couldGrabFocus)
                {
                    return;
                }
            }
        }
    }
}