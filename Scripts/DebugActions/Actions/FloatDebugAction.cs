using System;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.DebugActions.Actions;

public sealed class FloatDebugAction : IDebugAction
{
    public string Name { get; }
    public float Step { get; }
    public Action<float> SetAction { get; }
    public Func<float> GetAction { get; }
    
    public FloatDebugAction(string name, float step, Action<float> setAction, Func<float> getAction)
    {
        Name = name;
        Step = step;
        SetAction = setAction;
        GetAction = getAction;
    }
    
    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        FloatDebugActionWidget widget = debugPanelView.FloatDebugActionWidget!.Instantiate<FloatDebugActionWidget>();
        widget.Init(Name, Step, SetAction, GetAction);
        return widget;
    }
}