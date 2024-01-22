using System;
using System.Reflection;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;

namespace GDebugPanelGodot.UseCases;

public static class CreateDebugActionForMethodInfoUseCase
{
    public static void Execute(DebugActionsSection section, object optionsObject, MethodInfo methodInfo)
    {
        bool isValid = methodInfo.GetParameters().Length == 0
            && !methodInfo.IsSpecialName
            && methodInfo.DeclaringType != typeof(object);

        if (!isValid)
        {
            return;
        }
        
        section.AddButton(
            methodInfo.Name,
            () => methodInfo.Invoke(optionsObject, Array.Empty<object>())
        );
    }
}