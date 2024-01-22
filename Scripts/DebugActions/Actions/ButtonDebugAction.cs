using System;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.DebugActions.Actions;

public sealed class ButtonDebugAction : IDebugAction
{
    public string Name { get; }
    public Action Action { get; }

    public ButtonDebugAction(string name, Action action)
    {
        Name = name;
        Action = action;
    }

    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        ButtonDebugActionWidget widget = debugPanelView.ButtonDebugActionWidget!.Instantiate<ButtonDebugActionWidget>();
        widget.Init(Name, Action);
        return widget;
    }
}