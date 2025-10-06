using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lab;

public class Dice(int sides)
{
    private readonly Random _rand = new Random();
    public int Sides = sides;

    public int Roll()
    {
        return _rand.Next(1, Sides + 1);
    }

    public static Dice[] FromDiceString(string dice)
    {
        dice = dice.Trim();
        string[] values = dice.Split("d");
        List<Dice> ret = [];
        int count = Int32.Parse(values[0], NumberStyles.Integer ^ NumberStyles.AllowLeadingSign);
        int sides = Int32.Parse(values[1], NumberStyles.Integer ^ NumberStyles.AllowLeadingSign);
        for (int i = 0; i < count; i++)
        {
            ret.Add(new Dice(sides));
        }

        return ret.ToArray();
    }
}