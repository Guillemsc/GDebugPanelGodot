using System.Diagnostics;
using GDebugPanelGodot.Core;
using GDebugPanelGodot.DebugActions.Containers;
using GDebugPanelGodot.Examples.OptionsObjects;
using GDebugPanelGodot.Extensions;
using Godot;

namespace GDebugPanelGodot.Examples.Examples;

public partial class GDebugPanelExample : Control
{
    readonly Stopwatch _stopwatch = Stopwatch.StartNew();

    bool _toggle1;
    bool _toggle2;
    int _int1;
    float _float1;
    ExampleOptionsObject.ExampleEnum _enum1;
    
    public override void _Ready()
    {
        IDebugActionsSection section = GDebugPanel.AddNonCollapsableSection("Section 1");
        section.AddButton("Button", () => GD.Print("Button 1"));
        section.AddToggle("Toggle 1", val => _toggle1 = val, () => _toggle1);
        section.AddInfo("Lorem ipsum dolor sit amet");
        section.AddInfoDynamic(() =>_stopwatch.Elapsed.ToString());
            
        IDebugActionsSection section2 = GDebugPanel.AddSection("Section 2");
        section2.AddInfo("Very info that never ends and never will because");
        section2.AddInfoDynamic(() => "Very long info dynamic that never ends and never will because");
        section2.AddButton("Very long button name that never ends", () => GD.Print("Button 2"));
        section2.AddInt("Very long int name that never ends", val => _int1 = val, () => _int1);
        section2.AddFloat("Very long float name that never ends", val => _float1 = val, () => _float1);
        section2.AddEnum("Very long enum name that never ends", val => _enum1 = val, () => _enum1);
            
        GDebugPanel.AddSection("Section 3", new ExampleOptionsObject());
        
        IDebugActionsSection section4 = GDebugPanel.AddSection("Section 4");
        section4.AddInfo("Lorem ipsum dolor sit amet, consectetur adipiscing elit");
        
        GDebugPanel.Show(this);
    }
}