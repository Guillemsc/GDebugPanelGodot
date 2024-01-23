using GDebugPanelGodot.Core;
using Godot;

namespace GDebugPanelGodot.Nodes;

public partial class OpenGDebugPanelNode : Node
{
    [Export] public string ToggleAction = "ui_accept";
    
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed(ToggleAction))
        {
            Toggle();
        }
    }

    void Toggle()
    {
        if (GDebugPanel.IsVisible())
        {
            GDebugPanel.Hide();
        }
        else
        {
            GDebugPanel.Show(this);
        }
    }
}