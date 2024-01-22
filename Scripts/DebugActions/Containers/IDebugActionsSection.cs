using GDebugPanelGodot.DebugActions.Actions;

namespace GDebugPanelGodot.DebugActions.Containers;

/// <summary>
/// Represents a section within a debug actions UI, where various debug
/// actions can be added or removed.
/// </summary>
public interface IDebugActionsSection
{
    /// <summary>
    /// Adds a debug action to the current section. 
    /// </summary>
    /// <param name="action">The debug action to be added to the section.</param>
    void Add(IDebugAction action);
    
    /// <summary>
    /// Removes a debug action from the current section.
    /// </summary>
    /// <param name="action">The debug action to be removed from the section.</param>
    void Remove(IDebugAction action);
}