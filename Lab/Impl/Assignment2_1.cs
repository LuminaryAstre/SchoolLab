using System;

namespace Lab.Impl;

public class Assignment2_1 : IBaseLab
{
    public void Execute()
    {
        int input = Utils.PromptInt("|: Number? :|: ") ?? 0;
        int remainder3 = input % 3;
        int remainder7 = input % 7;
        if (remainder3 == 0 && remainder7 == 0)
        {
            Console.WriteLine($"{input} can be cleanly divided by 3 and 7!");
            return;
        }
        
        Console.WriteLine($"{input} can NOT be cleanly divided!\nRemainder on 3: {remainder3}\nRemainder on 7: {remainder7}");
    }
}