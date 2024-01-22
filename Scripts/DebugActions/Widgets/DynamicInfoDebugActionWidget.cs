using System;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class DynamicInfoDebugActionWidget : DebugActionWidget
{
    [Export] public Label? Label;
    
    Func<string>? _getInfoAction;
    
    public void Init(Func<string> getInfoAction)
    {
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