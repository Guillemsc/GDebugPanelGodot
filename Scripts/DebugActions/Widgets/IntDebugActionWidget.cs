using System;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Nodes;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class IntDebugActionWidget : DebugActionWidget
{
    [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
    [Export] public Label? Label;
    [Export] public SpinBox? SpinBox;
    
    Action<int>? _setAction;
    Func<int>? _getAction;
    
    public void Init(Control sizeControl, string name, int step, Action<int> setAction, Func<int> getAction)
    {
        LabelAutowrapController!.SizeControl = sizeControl;
        _setAction = setAction;
        _getAction = getAction;
        
        Label!.Text = name;
        SpinBox!.CustomArrowStep = step;
        SpinBox.MinValue = int.MinValue;
        SpinBox.MaxValue = int.MaxValue;
        SpinBox.Value = getAction.Invoke();
        SpinBox.ConnectSpinBoxValueChanged(Changed);
    }
    
    public override bool Focus()
    {
        SpinBox!.GrabFocus();
        return true;
    }

    void Changed(float value)
    {
        int truncatedValue = (int)value;
        _setAction!.Invoke(truncatedValue);
        truncatedValue = _getAction!.Invoke();
        SpinBox!.SetValueNoSignal(truncatedValue);
    }
}