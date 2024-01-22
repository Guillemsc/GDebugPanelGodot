using System;
using GDebugPanelGodot.Extensions;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class FloatDebugActionWidget : DebugActionWidget
{
    [Export] public Label? Label;
    [Export] public SpinBox? SpinBox;
    
    Action<float>? _setAction;
    Func<float>? _getAction;
    
    public void Init(string name, float step, Action<float> setAction, Func<float> getAction)
    {
        _setAction = setAction;
        _getAction = getAction;
        
        Label!.Text = name;
        SpinBox!.CustomArrowStep = step;
        SpinBox.Step = step;
        SpinBox.MinValue = int.MinValue;
        SpinBox.MaxValue = int.MaxValue;
        SpinBox.Value = getAction.Invoke();
        SpinBox.Rounded = false;
        SpinBox.ConnectSpinBoxValueChanged(Changed);
    }
    
    public override bool Focus()
    {
        SpinBox!.GrabFocus();
        return true;
    }

    void Changed(float value)
    {
        _setAction!.Invoke(value);
        SpinBox!.SetValueNoSignal(_getAction!.Invoke());
    }
}