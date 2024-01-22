using System;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.DebugActions.Actions;

public sealed class DynamicInfoDebugAction : IDebugAction
{
    public Func<string> GetInfoAction { get; }

    public string Name => GetInfoAction.Invoke();
    
    public DynamicInfoDebugAction(Func<string> getInfoAction)
    {
        GetInfoAction = getInfoAction;
    }

    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        DynamicInfoDebugActionWidget widget = debugPanelView.DynamicInfoDebugActionWidget!.Instantiate<DynamicInfoDebugActionWidget>();
        widget.Init(GetInfoAction);
        return widget;
    }
}