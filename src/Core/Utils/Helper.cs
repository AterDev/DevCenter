﻿using System.Drawing;
namespace Core.Utils;
public static class Helper
{
    public static string GetRandColor()
    {
        Random rnd = new();
        byte[] b = new byte[3];
        rnd.NextBytes(b);
        Color color = Color.FromArgb(b[0], b[1], b[2]);
        return ColorTranslator.ToHtml(color);
    }

}
