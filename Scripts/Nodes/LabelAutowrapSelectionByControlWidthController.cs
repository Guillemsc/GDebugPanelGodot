using Godot;
using Godot.Collections;

namespace GDebugPanelGodot.Nodes;

[Tool]
public partial class LabelAutowrapSelectionByControlWidthController : Label
{
    [Export] public Control? SizeControl;
    [Export] public float MaxSizeOffset;
    [Export] Array<Control>? ControlsSizeToSubstract;
    
    public override void _EnterTree()
    {
        if (Engine.IsEditorHint())
        {
            SetProcess(true);
        }
    }

    public override void _Process(double delta)
    {
        Refresh();
    }

    void Refresh()
    {
        if (SizeControl == null)
        {
            return;
        }

        Font font = LabelSettings.Font;
        int fontSize = LabelSettings.FontSize;
        
        if (font == null)
        {
            font = Theme.DefaultFont;
            fontSize = Theme.DefaultFontSize;
        }

        if (font == null)
        {
            return;
        }
        
        float maxSize = SizeControl.Size.X + MaxSizeOffset;

        if (ControlsSizeToSubstract != null)
        {
            foreach (Control toSubstract in ControlsSizeToSubstract!)
            {
                maxSize -= toSubstract.Size.X;
            }   
        }
        
        Vector2 stringSize = LabelSettings.Font.GetStringSize(
            Text,
            HorizontalAlignment,
            -1,
            fontSize,
            JustificationFlags
        );

        bool isBigger = maxSize < stringSize.X;

        if (isBigger)
        {
            CustomMinimumSize = new Vector2(maxSize, 0);
            AutowrapMode = TextServer.AutowrapMode.WordSmart;
        }
        else
        {
            CustomMinimumSize = new Vector2(50, 0);
            AutowrapMode = TextServer.AutowrapMode.Off;
        }
    }
}