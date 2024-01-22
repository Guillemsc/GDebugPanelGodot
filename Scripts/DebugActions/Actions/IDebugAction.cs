using GDebugPanelGodot.DebugActions.Widgets;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.DebugActions.Actions;

/// <summary>
/// Represents a debug action that can be associated with a
/// user interface widget in a debug panel.
/// </summary>
public interface IDebugAction
{
    string Name { get; }
    
    /// <summary>
    /// Instantiates a user interface widget for the debug action within the provided <see cref="DebugPanelView"/>.
    /// The instantiated control parent is automatically set after this, so it's not needed to manually set it on this method.
    /// </summary>
    /// <param name="debugPanelView">The view where the debug action's widget will be instantiated.</param>
    /// <returns>The instantiated user interface widget for the debug action.</returns>
    DebugActionWidget InstantiateWidget(DebugPanelView debugPanelView);
}