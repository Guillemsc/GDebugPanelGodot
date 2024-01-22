using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Views;

namespace GDebugPanelGodot.UseCases;

public static class SetSectionViewCollapsedUseCase
{
    public static void Execute(DebugPanelSectionView sectionView, bool collapsed)
    {
        sectionView.Section!.Collapsed = collapsed;

        RefreshSectionViewNameUseCase.Execute(sectionView);

        sectionView.CollapsableControl!.SetActiveCanvasItem(!sectionView.Section.Collapsed);
    }
}