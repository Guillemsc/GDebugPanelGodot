using GDebugPanelGodot.DebugActions.Actions;
using GUtils.Extensions;

namespace GDebugPanelGodot.UseCases;

public static class ShouldDebugActionBeVisibleWithSerachFieldUseCase
{
    public static bool Execute(string searchText, IDebugAction debugAction)
    {
        if (searchText.IsNullOrEmpty())
        {
            return true;
        }
        
        string normalizedString = debugAction.Name.Replace(" ", "").ToLowerInvariant();

        return normalizedString.Contains(searchText);
    }
}