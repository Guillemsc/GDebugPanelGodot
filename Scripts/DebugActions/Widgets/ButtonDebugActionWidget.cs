using System;
using GDebugPanelGodot.Extensions;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class ButtonDebugActionWidget : DebugActionWidget
{
    [Export] public Label? Label;
    [Export] public Button? Button;
    
    public void Init(string name, Action action)
    {
        Label!.Text = name;
        Button!.ConnectButtonPressed(action);
    }

    public override bool Focus()
    {
        Button!.GrabFocus();
        return true;
    }
}