using System;

namespace Lab.Impl;

public class Assignment1_1 : IBaseLab
{
    public void Execute()
    {
        double celsius = Utils.PromptDouble("|: Celsius :|: ") ?? 0;
        double fahreinheit = 1.8 * celsius + 32;
        Console.WriteLine($"{celsius} converted to Fahrenheit equals {fahreinheit}");
    }

    public bool Test()
    {
        throw new NotImplementedException();
    }
}