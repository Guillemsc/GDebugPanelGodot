using System.Diagnostics;
using GDebugPanelGodot.Core;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Extensions;
using GDebugPanelGodot.OptionsObjects;
using Godot;

namespace GDebugPanelGodot.Nodes;

public partial class OpenGDebugPanelNode : Node
{
    [Export] public string Action = "ui_accept";

    IDebugActionsSection? section;
    IDebugActionsSection? section2;
    IDebugActionsSection? section3;
    
    Stopwatch Stopwatch = Stopwatch.StartNew();
    
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed(Action))
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
            
            if (section == null)
            {
                section = GDebugPanel.AddNonCollapsableSection("1");
                section.AddButton("God", () => GD.Print("A"));
                section.AddToggle("Toggle 1", val => { }, () => false);
                section.AddInfo("Lorem ipsum deca ago dero");
                section.AddInfoDynamic(() => Stopwatch.Elapsed.ToString());
            
                section2 = GDebugPanel.AddSection("2");
                section2.AddButton("God 2", () => GD.Print("B"));
                section2.AddToggle("Toggle 2", val => { }, () => true);
            
                section3 = GDebugPanel.AddSection("3", new ExampleOptionsObject());
            }
        }
    }
}