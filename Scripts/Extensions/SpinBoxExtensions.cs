using System;
using Godot;

namespace GDebugPanelGodot.Extensions;

public static class SpinBoxExtensions
{
    public static void ConnectSpinBoxValueChanged(this SpinBox spinBox, Action<float> action)
    {
        spinBox.Connect("value_changed", Callable.From(action));
    }
}