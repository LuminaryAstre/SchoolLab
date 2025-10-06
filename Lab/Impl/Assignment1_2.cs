using System;

namespace Lab.Impl;

public class Assignment1_2 : IBaseLab
{
    public void Execute()
    {
        double r = Utils.PromptDouble("|: Radius of circle :|: ") ?? 0;
        double o = Math.Round(2 * Math.PI * r, 2);
        double a = Math.Round(Math.PI * r * r, 2);
        Console.WriteLine($"Circumference: {o}\nArea: {a}");
    }

    public bool Test()
    {
        throw new NotImplementedException();
    }
}