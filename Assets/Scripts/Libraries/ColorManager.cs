using UnityEngine;

public static class ColorManager
{
    /// <summary>Ths is a constructor V2 for people want to edit at this way.</summary>
    /// <param name="R">a number between 0 and 255 of Red Tint</param>
    /// <param name="G">a number between 0 and 255 of Red Tint</param>
    /// <param name="B">a number between 0 and 255 of Red Tint</param>
    /// <param name="Alpha">a number between 0 and 255 of Red Tint</param>
    /// <returns>Returns a UnityEngine.Color</returns>
    public static Color MakeColor(int R, int G, int B, int Alpha = 255)
    {
        return new Color ((float)R / 255.0f, (float)G / 255.0f, (float)B / 255.0f, (float)Alpha / 255.0f);
    }
    /// <summary>You always wanted to create with headecimal?</summary>
    /// <param name="Hexadecimal">An hexadecimal</param>
    /// <returns>Returns a UnityEngine.Color</returns>
    public static Color MakeColor(string Hexadecimal)
    {
        Hexadecimal.ToLower();
        if (Hexadecimal.StartsWith("#")) Hexadecimal = Hexadecimal.Substring(1);

        int R = 0;
        int G = 0;
        int B = 0;
        int Alpha = 255;

        if (Hexadecimal.Length == 6) // Format: RRGGBB
        {
            R = int.Parse(Hexadecimal.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            G = int.Parse(Hexadecimal.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            B = int.Parse(Hexadecimal.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        }
        else if (Hexadecimal.Length == 8) // Format: RRGGBBAA
        {
            R = int.Parse(Hexadecimal.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            G = int.Parse(Hexadecimal.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            B = int.Parse(Hexadecimal.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            Alpha = int.Parse(Hexadecimal.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }

        return MakeColor(R, G, B, Alpha);
    }
}