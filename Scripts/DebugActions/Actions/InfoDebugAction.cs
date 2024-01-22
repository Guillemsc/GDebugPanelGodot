using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.DebugActions.Actions;

public sealed class InfoDebugAction : IDebugAction
{
    public string Name { get; }
    
    public InfoDebugAction(string info)
    {
        Name = info;
    }
    
    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        InfoDebugActionWidget widget = debugPanelView.InfoDebugActionWidget!.Instantiate<InfoDebugActionWidget>();
        widget.Init(Name);
        return widget;
    }
}