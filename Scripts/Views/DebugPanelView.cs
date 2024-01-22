using Godot;

namespace GDebugPanelGodot.Views;

public partial class DebugPanelView : Control
{
    [Export] public Control? ContentVBox;
    [Export] public LineEdit? SearchLineEdit;
    [Export] public Button? ClearSearchButton;
    
    [Export] public PackedScene? DebugPanelSection;

    [Export] public PackedScene? InfoDebugActionWidget;
    [Export] public PackedScene? DynamicInfoDebugActionWidget;
    [Export] public PackedScene? ButtonDebugActionWidget;
    [Export] public PackedScene? ToggleDebugActionWidget;
    [Export] public PackedScene? IntDebugActionWidget;
    [Export] public PackedScene? FloatDebugActionWidget;
    [Export] public PackedScene? EnumDebugActionWidget;
}