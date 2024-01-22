using System;
using System.Collections.Generic;
using GDebugPanelGodot.DebugActions.Actions;

namespace GDebugPanelGodot.DebugActions.Containers;

public sealed class DebugActionsSection : IDebugActionsSection, IDisposable
{
    readonly List<IDebugAction> _actions = new();
    
    Action<DebugActionsSection, IDebugAction>? _addAction;
    Action<IDebugAction>? _removeAction;
    
    public string Name { get; }
    public bool Collapsable { get; }
    public bool Collapsed { get; set; }
    public int Priority { get; }
    public IReadOnlyList<IDebugAction> Actions => _actions;
    
    public DebugActionsSection(
        string name, 
        bool collapsable,
        bool collapsed,
        int priority,
        Action<DebugActionsSection, IDebugAction> addAction, 
        Action<IDebugAction> removeAction
        )
    {
        Name = name;
        Collapsable = collapsable;
        Collapsed = collapsed;
        Priority = priority;
        _addAction = addAction;
        _removeAction = removeAction;
    }
    
    public void Add(IDebugAction action)
    {
        _actions.Add(action);
        _addAction!.Invoke(this, action);
    }

    public void Remove(IDebugAction action)
    {
        bool found = _actions.Remove(action);

        if (!found)
        {
            return;
        }
        
        _removeAction!.Invoke(action);
    }

    public void Dispose()
    {
        _addAction = null;
        _removeAction = null;
    }
}