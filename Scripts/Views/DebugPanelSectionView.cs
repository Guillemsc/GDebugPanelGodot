using GDebugPanelGodot.DebugActions.Containers;
using Godot;

namespace GDebugPanelGodot.Views;

public partial class DebugPanelSectionView : Control
{
    [Export] public Button? SectionButton;
    [Export] public Label? SectionLabel;
    [Export] public Control? TitleContent;
    [Export] public Control? CollapsableControl;
    [Export] public Control? ContentParent;

    public DebugActionsSection? Section;
}