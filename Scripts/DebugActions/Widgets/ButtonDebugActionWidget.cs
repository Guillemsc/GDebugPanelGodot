using System;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Nodes;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class ButtonDebugActionWidget : DebugActionWidget
{
    [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
    [Export] public Label? Label;
    [Export] public Button? Button;
    
    public void Init(Control sizeControl, string name, Action action)
    {
        LabelAutowrapController!.SizeControl = sizeControl;
        Label!.Text = name;
        Button!.ConnectButtonPressed(action);
    }

    public override bool Focus()
    {
        Button!.GrabFocus();
        return true;
    }
}