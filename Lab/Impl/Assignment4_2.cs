using System.Collections.Generic;
using System.Linq;

namespace Lab.Impl;

public class Assignment4_2 : IBaseLab
{
    public void Execute()
    {
        double difficulty = Utils.PromptDouble("|: Difficulty? :|: ") ?? 1;
        List<int> scores = [];
        for (int i = 0; i < 5; i++)
        {
            scores.Add(Utils.PromptInt($"|: Judge {i + 1}'s score :|: ") ?? 0);
        }

        scores.Sort();
        scores.Pop(4);
        scores.Pop(0);
        double score = scores.Sum() * difficulty;
        Utils.WriteLine($"Score: {score}");
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}