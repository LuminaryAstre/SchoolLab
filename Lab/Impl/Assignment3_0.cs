using System;

namespace Lab.Impl;

public class Assignment3_0 : IBaseLab
{
    public void Execute()
    {
        double start = Utils.PromptDouble("|: Start value? :|: ") ?? 0;
        double step = Utils.PromptDouble("|: Step? :|: ") ?? 0;
        double stop = Utils.PromptDouble("|: Stop value? :|: ") ?? 0;
        Console.WriteLine($"Initializing with parameters start={start} step={step} stop={stop};");
        for (double i = 0; i <= stop; i += step)
        {
            Console.Write($"{i} ");
        }

        Console.Write('\n');
    }
}