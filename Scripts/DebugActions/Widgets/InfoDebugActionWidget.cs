using Godot;

namespace GDebugPanelGodot.DebugActions.Widgets;

public partial class InfoDebugActionWidget : DebugActionWidget
{
    [Export] public Label? Label;

    public void Init(string info)
    {
        Label!.Text = info;
    }
}