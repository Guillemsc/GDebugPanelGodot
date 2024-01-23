using System;

namespace GDebugPanelGodot.Extensions;

public static class StringExtensions
{
    public static string SubstringSafe(this string str, int startIndex, int length)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }
        
        int finalPosition = startIndex + length;
        int clampedFinalPosition = Math.Clamp(finalPosition, 0, str.Length);
        length -= finalPosition - clampedFinalPosition;
        return str.Substring(startIndex, length);
    }
}