using GDebugPanelGodot.Datas;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.Views;
using Godot;

namespace GDebugPanelGodot.UseCases;

public static class InstantiateDebugPanelSectionViewUseCase
{
    public static void Execute(DebugPanelData debugPanelData, DebugActionsData debugActionsData, DebugActionsSection section)
    {
        if (debugPanelData.DebugPanelView == null)
        {
            return;
        }

        bool alreadyExists = debugActionsData.SectionsViews.ContainsKey(section);

        if (alreadyExists)
        {
            return;
        }

        DebugPanelSectionView debugPanelSectionView = debugPanelData.DebugPanelView!.DebugPanelSection!.Instantiate<DebugPanelSectionView>();
        debugPanelSectionView.SetParent(debugPanelData.DebugPanelView.ContentVBox!);

        void Toggle() => ToggleSectionViewCollapsedUseCase.Execute(debugPanelSectionView);

        debugPanelSectionView.Section = section;
        debugPanelSectionView.SectionButton!.ConnectButtonPressed(Toggle);
        debugPanelSectionView.SectionButton!.SetActiveCanvasItem(section.Collapsable);
        
        debugActionsData.SectionsViews.Add(section, debugPanelSectionView);
        
        RefreshSectionViewNameUseCase.Execute(debugPanelSectionView);
        SetSectionViewCollapsedUseCase.Execute(debugPanelSectionView, section.Collapsed);
    }
}