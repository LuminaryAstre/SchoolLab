using System;

namespace Lab.Impl;

public class Assignment3_1 : IBaseLab
{
    private Random rand = new Random();
    public void Execute()
    {
        start:
        bool highNLow = Utils.YesNo("Do you want to play with High 'N' Low mode enabled?");
        int min = Utils.PromptInt("|: What should the minimum value be? :|: ") ?? 0;
        int max = Utils.PromptInt("|: What should the maximum value be? :|: ") ?? 100;

        // Gotta love how minimum is inclusive but maximum is exclusive.
        int val = rand.Next(min, max+1);
        int guesses = 0;
        while (true)
        {
            int guess = Utils.PromptInt("|: What is your guess? :|: ") ?? 0;
            guesses++;
            if (guess == val)
            {
                Console.WriteLine($"Congratulations! You guessed correctly in {guesses} guesses.");
                if (Utils.YesNo("Play again?"))
                    goto start;
                break;
            }

            if (highNLow)
            {
                if (val > guess) Console.WriteLine("Higher!");
                else Console.WriteLine("Lower!");
                continue;
            }

            Console.WriteLine("Wrong!");
        }
    }

    public bool Test()
    {
        throw new NotImplementedException();
    }
}