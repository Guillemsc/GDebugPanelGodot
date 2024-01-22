using System;
using Godot;

namespace GDebugPanelGodot.Extensions;

public static class OptionButtonExtensions
{
    public static void ConnectOptionButtonItemSelected(this OptionButton optionButton, Action<int> action)
    {
        optionButton.Connect("item_selected", Callable.From(action));
    }
}