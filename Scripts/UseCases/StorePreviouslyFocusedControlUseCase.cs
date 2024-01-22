using GDebugPanelGodot.Datas;

namespace GDebugPanelGodot.UseCases;

public static class StorePreviouslyFocusedControlUseCase
{
    public static void Execute(DebugPanelData debugPanelData, FocusData focusData)
    {
        if (debugPanelData.DebugPanelView == null)
        {
            return;
        }

        focusData.PreviouslyFocusedControl = debugPanelData.DebugPanelView.GetViewport().GuiGetFocusOwner();
    }
}