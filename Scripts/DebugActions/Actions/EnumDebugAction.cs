using System;
using System.Collections.Generic;
using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.DebugActions.Actions;

public sealed class EnumDebugAction : IDebugAction
{
    public string Name { get; }
    public Type EnumType { get; }
    public Action<object> SetAction { get; }
    public Func<object> GetAction { get; }
    
    public EnumDebugAction(string name, Type enumType, Action<object> setAction, Func<object> getAction)
    {
        Name = name;
        EnumType = enumType;
        SetAction = setAction;
        GetAction = getAction;
    }
    
    public DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView)
    {
        EnumDebugActionWidget widget = debugPanelView.EnumDebugActionWidget!.Instantiate<EnumDebugActionWidget>();
        
        Array enumValues = Enum.GetValues(EnumType);
        List<object> actualEnumValues = new();
        foreach (object item in enumValues)
        {
            actualEnumValues.Add(item);
        }
        
        widget.Init(Name, actualEnumValues, SetAction, GetAction);
        return widget;
    }
}