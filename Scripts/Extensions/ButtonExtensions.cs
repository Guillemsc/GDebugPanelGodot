using System;
using Godot;

namespace GDebugPanelGodot.Extensions;

public static class ButtonExtensions
{
    public static void ConnectButtonPressed(this Button button, Action action)
    {
        button.Connect("pressed", Callable.From(action));
    }
}