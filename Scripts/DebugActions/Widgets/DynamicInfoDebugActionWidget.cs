using System;
using GDebugPanelGodot.Nodes;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class DynamicInfoDebugActionWidget : DebugActionWidget
{
    [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
    [Export] public Label? Label;
    
    Func<string>? _getInfoAction;
    
    public void Init(Control sizeControl, Func<string> getInfoAction)
    {
        LabelAutowrapController!.SizeControl = sizeControl;
        _getInfoAction = getInfoAction;
        
        UpdateText();
    }

    public override void _Process(double delta)
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (_getInfoAction == null)
        {
            return;
        }
        
        string info = _getInfoAction.Invoke();
        Label!.Text = info;
    }
}