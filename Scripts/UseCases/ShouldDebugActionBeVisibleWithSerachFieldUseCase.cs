using GDebugPanelGodot.DebugActions.Actions;

namespace GDebugPanelGodot.UseCases;

public static class ShouldDebugActionBeVisibleWithSerachFieldUseCase
{
    public static bool Execute(string searchText, IDebugAction debugAction)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            return true;
        }
        
        string normalizedString = debugAction.Name.Replace(" ", "").ToLowerInvariant();

        return normalizedString.Contains(searchText);
    }
}