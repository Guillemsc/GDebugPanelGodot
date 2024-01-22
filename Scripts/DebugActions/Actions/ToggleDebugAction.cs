using System;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.DebugActions.Actions;

public sealed class ToggleDebugAction : IDebugAction
{
    public string Name { get; }
    public Action<bool> SetAction { get; }
    public Func<bool> GetAction { get; }
    
    public ToggleDebugAction(string name, Action<bool> setAction, Func<bool> getAction)
    {
        Name = name;
        SetAction = setAction;
        GetAction = getAction;
    }
    
    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        ToggleDebugActionWidget widget = debugPanelView.ToggleDebugActionWidget!.Instantiate<ToggleDebugActionWidget>();
        widget.Init(Name, SetAction, GetAction);
        return widget;
    }
}