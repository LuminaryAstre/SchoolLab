using System;

namespace Lab.Impl;

public class Assignment2_0 : IBaseLab
{
    public void Execute()
    {
        int age = Utils.PromptInt("|: How old art thou? :|: ") ?? 999;
        if (age <= 12)
        {
            Console.WriteLine("WHITE");
            return;
        }

        if (age <= 18)
        {
            Console.WriteLine("GREEN");
            return;
        }

        if (age <= 25)
        {
            Console.WriteLine("RED");
            return;
        }

        if (age <= 99)
        {
            Console.WriteLine("BLUE");
            return;
        }
        
        Console.WriteLine("INVALID");
    }
}