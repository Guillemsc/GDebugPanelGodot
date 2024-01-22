using GDebugPanelGodot.Datas;
using Godot;

namespace GDebugPanelGodot.UseCases;

public static class TryReturnFocusToPreviouslyFocusedControlUseCase
{
    public static void Execute(FocusData focusData)
    {
        if (focusData.PreviouslyFocusedControl == null)
        {
            return;
        }

        bool isValid = GodotObject.IsInstanceValid(focusData.PreviouslyFocusedControl);

        if (!isValid)
        {
            return;
        }
        
        focusData.PreviouslyFocusedControl.GrabFocus();
    }
}