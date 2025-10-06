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
            goto end;
        }

        if (age <= 18)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GREEN");
            goto end;
        }

        if (age <= 25)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("RED");
            goto end;
        }

        if (age <= 99)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("BLUE");
            goto end;
        }

        Console.WriteLine("INVALID");
        end:
        Console.ForegroundColor = ConsoleColor.White;
    }

    public bool Test()
    {
        throw new NotImplementedException();
    }
}