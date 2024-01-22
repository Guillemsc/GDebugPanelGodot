using System;
using System.Reflection;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;

namespace GDebugPanelGodot.UseCases;

public static class CreateDebugActionForPropertyInfoUseCase
{
    public static void Execute(DebugActionsSection section, object optionsObject, PropertyInfo propertyInfo)
    {
        MethodInfo? getter = propertyInfo.GetGetMethod();
        MethodInfo? setter = propertyInfo.GetSetMethod();

        bool hasPublicGetter = getter != null && getter.IsPublic;
        bool hasPublicSetter = setter != null && setter.IsPublic;
        bool hasPublicGetterAndSetter = hasPublicGetter && hasPublicSetter;

        if (hasPublicGetterAndSetter)
        {
            if (propertyInfo.PropertyType == typeof(bool))
            {
                section.AddToggle(
                    propertyInfo.Name,
                    val => propertyInfo.SetValue(optionsObject, val),
                    () => (bool)propertyInfo.GetValue(optionsObject)!
                );
            }
            else if(propertyInfo.PropertyType == typeof(string))
            {
                section.AddInfoDynamic(
                    () => (string)propertyInfo.GetValue(optionsObject)!
                );
            }
            else if(propertyInfo.PropertyType == typeof(int))
            {
                section.AddInt(
                    propertyInfo.Name,
                    val => propertyInfo.SetValue(optionsObject, val),
                    () => (int)propertyInfo.GetValue(optionsObject)!
                );
            }
            else if(propertyInfo.PropertyType == typeof(float))
            {
                section.AddFloat(
                    propertyInfo.Name,
                    val => propertyInfo.SetValue(optionsObject, val),
                    () => (float)propertyInfo.GetValue(optionsObject)!
                );
            }
            else if(propertyInfo.PropertyType.IsAssignableTo(typeof(Enum)))
            {
                section.AddEnum(
                    propertyInfo.Name,
                    propertyInfo.PropertyType,
                    val => propertyInfo.SetValue(optionsObject, val),
                    () => propertyInfo.GetValue(optionsObject)!
                );
            }
            
            return;
        }

        if (hasPublicGetter)
        {
            if(propertyInfo.PropertyType == typeof(string))
            {
                section.AddInfo(
                    (string)propertyInfo.GetValue(optionsObject)!
                );
            }
            return;
        }
    }
}