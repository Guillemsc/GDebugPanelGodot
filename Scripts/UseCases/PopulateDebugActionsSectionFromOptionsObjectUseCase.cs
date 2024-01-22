using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GDebugPanelGodot.DebugActions.Containers;

namespace GDebugPanelGodot.UseCases;

public static class PopulateDebugActionsSectionFromOptionsObjectUseCase
{
    public static void Execute(DebugActionsSection section, object optionsObject)
    {
        Type type = optionsObject.GetType();

       IEnumerable<MemberInfo> members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public)
            .OrderBy(member => member.MetadataToken);

       foreach (MemberInfo memberInfo in members)
       {
           if (memberInfo is PropertyInfo propertyInfo)
           {
               CreateDebugActionForPropertyInfoUseCase.Execute(section, optionsObject, propertyInfo);
           }
           else if (memberInfo is MethodInfo methodInfo)
           {
               CreateDebugActionForMethodInfoUseCase.Execute(section, optionsObject, methodInfo);
           }
       }
    }
}