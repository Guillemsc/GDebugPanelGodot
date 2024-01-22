using System;
using System.Collections.Generic;
using GDebugPanelGodot.Extensions;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class EnumDebugActionWidget : DebugActionWidget
{
    [Export] public Label? Label;
    [Export] public OptionButton? OptionButton;

    List<object>? _enumValues;
    Action<object>? _setAction;
    Func<object>? _getAction;
    
    public void Init(string name, List<object> enumValues, Action<object> setAction, Func<object> getAction)
    {
        _enumValues = enumValues;
        _setAction = setAction;
        _getAction = getAction;
        
        Label!.Text = name;

        foreach (object item in enumValues)
        {
            OptionButton!.AddItem(item.ToString());
        }

        OptionButton!.ConnectOptionButtonItemSelected(Selected);
    }
    
    public override bool Focus()
    {
        OptionButton!.GrabFocus();
        return true;
    }

    void Selected(int index)
    {
        if (_enumValues!.Count == 0)
        {
            return;
        }
        
        index = Math.Clamp(index, 0, _enumValues!.Count - 1);
        object value = _enumValues[index];
        _setAction!.Invoke(value);
        
        value = _getAction!.Invoke();
        index = _enumValues.IndexOf(value);
        index = Math.Clamp(index, 0, _enumValues!.Count - 1);
        OptionButton!.Selected = index;
    }
}