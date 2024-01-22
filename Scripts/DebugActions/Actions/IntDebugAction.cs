using System;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.DebugActions.Actions;

public sealed class IntDebugAction : IDebugAction
{
    public string Name { get; }
    public int Step { get; }
    public Action<int> SetAction { get; }
    public Func<int> GetAction { get; }
    
    public IntDebugAction(string name, int step, Action<int> setAction, Func<int> getAction)
    {
        Name = name;
        Step = step;
        SetAction = setAction;
        GetAction = getAction;
    }
    
    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        IntDebugActionWidget widget = debugPanelView.IntDebugActionWidget!.Instantiate<IntDebugActionWidget>();
        widget.Init(Name, Step, SetAction, GetAction);
        return widget;
    }
}