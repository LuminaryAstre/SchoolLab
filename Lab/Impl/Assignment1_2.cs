using System;

namespace Lab.Impl;

public class Assignment1_2 : IBaseLab
{
    public void Execute()
    {
        double r = Utils.PromptDouble("|: Radius of circle :|: ") ?? 0;
        double o = 2 * Math.PI * r;
        double a = Math.PI * r * r;
        Console.WriteLine($"Circumference: {o}\nArea: {a}");
    }
}