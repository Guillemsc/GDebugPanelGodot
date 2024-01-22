using GDebugPanelGodot.Constants;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.UseCases;

public static class RefreshSectionViewNameUseCase
{
    public static void Execute(DebugPanelSectionView sectionView)
    {
        string name;
        
        if (!sectionView.Section!.Collapsable)
        {
            name = sectionView.Section!.Name; 
        }
        else
        {
            string arrowChar = sectionView.Section!.Collapsed
                ? CharactersConstants.MenuFoldedChar
                : CharactersConstants.MenuUnfoldedChar;

            name = $"{arrowChar} {sectionView.Section!.Name}";   
        }
        
        sectionView.SectionLabel!.Text = name;   
    }
}