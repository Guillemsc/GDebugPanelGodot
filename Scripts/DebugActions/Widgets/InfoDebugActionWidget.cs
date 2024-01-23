using GDebugPanelGodot.Nodes;
using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class InfoDebugActionWidget : DebugActionWidget
{
    [Export] public LabelAutowrapSelectionByControlWidthController? LabelAutowrapController;
    [Export] public Label? Label;

    public void Init(Control sizeControl, string info)
    {
        LabelAutowrapController!.SizeControl = sizeControl;
        Label!.Text = info;
    }
}