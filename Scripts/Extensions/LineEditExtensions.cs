using System;
using Godot;

namespace GDebugPanelGodot.Extensions;

public static class LineEditExtensions
{
    public static void ConnectLineEditTextChanged(this LineEdit lineEdit, Action<string> action)
    {
        lineEdit.Connect("text_changed", Callable.From(action));
    }
}