using System;
using System.Collections.Generic;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Nodes;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class EnumDebugActionWidget : DebugActionWidget
{
    [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
    [Export] public Label? Label;
    [Export] public OptionButton? OptionButton;
    [Export] public int MaxCharsPerOption = 10;

    List<object>? _enumValues;
    Action<object>? _setAction;
    Func<object>? _getAction;
    
    public void Init(Control sizeControl, string name, List<object> enumValues, Action<object> setAction, Func<object> getAction)
    {
        LabelAutowrapController!.SizeControl = sizeControl;
        _enumValues = enumValues;
        _setAction = setAction;
        _getAction = getAction;
        
        Label!.Text = name;

        foreach (object item in enumValues)
        {
            string itemName = item.ToString()!.SubstringSafe(0, MaxCharsPerOption);
            OptionButton!.AddItem(itemName);
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