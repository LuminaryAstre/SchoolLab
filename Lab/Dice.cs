using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab;

public class Dice(int sides)
{
    public readonly int Sides = sides;

    public int Roll()
    {
        return Random.Shared.Next(1, Sides + 1);
    }

    public static Dice[] FromDiceString(string dice)
    {
        dice = dice.Trim();
        string[] values = dice.Split('d');
        List<Dice> ret = [];

        int count = int.Parse(values[0], NumberStyles.Integer ^ NumberStyles.AllowLeadingSign);
        int sides = int.Parse(values[1], NumberStyles.Integer ^ NumberStyles.AllowLeadingSign);

        for (int i = 0; i < count; i++)
        {
            ret.Add(new Dice(sides));
        }

        return [.. ret];
    }
}