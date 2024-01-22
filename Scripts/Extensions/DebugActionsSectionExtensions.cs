using System;
using GDebugPanelGodot.DebugActions.Actions;
using GDebugPanelGodot.DebugActions.Containers;

namespace GDebugPanelGodot.Extensions;

public static class DebugActionsSectionExtensions
{
    /// <summary>
    /// Adds an information debug action in the form of a label with the provided information
    /// text.
    /// </summary>
    /// <param name="section">The debug actions section to add the information action to.</param>
    /// <param name="info">The information text to be displayed.</param>
    /// <returns>The added information debug action.</returns>
    public static IDebugAction AddInfo(this IDebugActionsSection section, string info)
    {
        IDebugAction debugAction = new InfoDebugAction(info);
        section.Add(debugAction);
        return debugAction;
    }
    
    /// <summary>
    /// Adds an information debug action in the form of a label that gets updated every frame
    /// with the provided information text.
    /// </summary>
    /// <param name="section">The debug actions section to add the dynamic information action to.</param>
    /// <param name="getInfoAction">The function to retrieve dynamic information text.</param>
    /// <returns>The added dynamic information debug action.</returns>
    public static IDebugAction AddInfoDynamic(this IDebugActionsSection section, Func<string> getInfoAction)
    {
        IDebugAction debugAction = new DynamicInfoDebugAction(getInfoAction);
        section.Add(debugAction);
        return debugAction;
    }
    
    /// <summary>
    /// Adds a button debug action with the provided name and action to be executed when
    /// the button is clicked.
    /// </summary>
    /// <param name="section">The debug actions section to add the button action to.</param>
    /// <param name="name">The name of the button.</param>
    /// <param name="action">The action to be executed when the button is clicked.</param>
    /// <returns>The added button debug action.</returns>
    public static IDebugAction AddButton(this IDebugActionsSection section, string name, Action action)
    {
        IDebugAction debugAction = new ButtonDebugAction(name, action);
        section.Add(debugAction);
        return debugAction;
    }
    
    /// <summary>
    /// Adds a toggle debug action with the provided name and actions for setting and getting
    /// the toggle state.
    /// </summary>
    /// <param name="section">The debug actions section to add the toggle action to.</param>
    /// <param name="name">The name of the toggle.</param>
    /// <param name="setAction">The action to set the toggle state.</param>
    /// <param name="getAction">The function to get the current toggle state.</param>
    /// <returns>The added toggle debug action.</returns>
    public static IDebugAction AddToggle(this IDebugActionsSection section, string name, Action<bool> setAction, Func<bool> getAction)
    {
        IDebugAction debugAction = new ToggleDebugAction(name, setAction, getAction);
        section.Add(debugAction);
        return debugAction;
    }
    
    /// <summary>
    /// Adds an integer debug action with the provided name, step, and actions
    /// for setting and getting the integer value.
    /// </summary>
    /// <param name="section">The debug actions section to add the integer action to.</param>
    /// <param name="name">The name of the integer.</param>
    /// <param name="step">The step value used for increasing or decreasing the integer value.</param>
    /// <param name="setAction">The action to set the integer value.</param>
    /// <param name="getAction">The function to get the current integer value.</param>
    /// <returns>The added integer debug action.</returns>
    public static IDebugAction AddInt(this IDebugActionsSection section, string name, int step, Action<int> setAction, Func<int> getAction)
    {
        IDebugAction debugAction = new IntDebugAction(name, step, setAction, getAction);
        section.Add(debugAction);
        return debugAction;
    }
    
    /// <summary>
    /// Adds an integer debug action with the provided name, step, and actions
    /// for setting and getting the integer value. Uses a default step value of 1.
    /// </summary>
    /// <param name="section">The debug actions section to add the integer action to.</param>
    /// <param name="name">The name of the integer.</param>
    /// <param name="setAction">The action to set the integer value.</param>
    /// <param name="getAction">The function to get the current integer value.</param>
    /// <returns>The added integer debug action.</returns>
    public static IDebugAction AddInt(this IDebugActionsSection section, string name, Action<int> setAction, Func<int> getAction)
    {
        return section.AddInt(name, 1, setAction, getAction);
    }
    
    /// <summary>
    /// Adds a float debug action with the provided name, step, and actions for setting
    /// and getting the float value.
    /// </summary>
    /// <param name="section">The debug actions section to add the float action to.</param>
    /// <param name="name">The name of the float.</param>
    /// <param name="step">The step value for increasing or decreasing the float value.</param>
    /// <param name="setAction">The action to set the float value.</param>
    /// <param name="getAction">The function to get the current float value.</param>
    /// <returns>The added float debug action.</returns>
    public static IDebugAction AddFloat(this IDebugActionsSection section, string name, float step, Action<float> setAction, Func<float> getAction)
    {
        IDebugAction debugAction = new FloatDebugAction(name, step, setAction, getAction);
        section.Add(debugAction);
        return debugAction;
    }
    
    /// <summary>
    /// Adds a float debug action with the provided name, step, and actions for setting
    /// and getting the float value. Uses a default step value of 0.1f.
    /// </summary>
    /// <param name="section">The debug actions section to add the float action to.</param>
    /// <param name="name">The name of the float.</param>
    /// <param name="setAction">The action to set the float value.</param>
    /// <param name="getAction">The function to get the current float value.</param>
    /// <returns>The added float debug action.</returns>
    public static IDebugAction AddFloat(this IDebugActionsSection section, string name, Action<float> setAction, Func<float> getAction)
    {
        return section.AddFloat(name, 0.1f, setAction, getAction);
    }

    /// <summary>
    /// Adds an enum debug action with the provided name, and actions for setting
    /// and getting the enum value.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="section">The debug actions section to add the enum action to.</param>
    /// <param name="name">The name of the enum action.</param>
    /// <param name="setAction">The action to set the enum value.</param>
    /// <param name="getAction">The function to get the current enum value.</param>
    /// <returns>The added enum debug action.</returns>
    public static IDebugAction AddEnum<T>(this IDebugActionsSection section, string name, Action<T> setAction, Func<T> getAction)
        where T : Enum
    {
        void Set(object value) => setAction.Invoke((T)value);
        object Get() => getAction.Invoke();

        Type enumType = typeof(T);
        
        IDebugAction debugAction = new EnumDebugAction(name, enumType, Set, Get);
        section.Add(debugAction);
        return debugAction;
    }
    
    /// <summary>
    /// Adds an enum debug action with the provided name, and actions for setting
    /// and getting the enum value.
    /// </summary>
    /// <param name="section">The debug actions section to add the enum action to.</param>
    /// <param name="name">The name of the enum action.</param>
    /// <param name="enumType">The type of the enum to use.</param>
    /// <param name="setAction">The action to set the enum value.</param>
    /// <param name="getAction">The function to get the current enum value.</param>
    /// <returns>The added enum debug action.</returns>
    public static IDebugAction AddEnum(this IDebugActionsSection section, string name, Type enumType, Action<object> setAction, Func<object> getAction)
    {
        IDebugAction debugAction = new EnumDebugAction(name, enumType, setAction, getAction);
        section.Add(debugAction);
        return debugAction;
    }
}