using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.UseCases;

public static class ToggleSectionViewCollapsedUseCase
{
    public static void Execute(DebugPanelSectionView sectionView)
    {
        SetSectionViewCollapsedUseCase.Execute(sectionView, !sectionView.Section!.Collapsed);
    }
}