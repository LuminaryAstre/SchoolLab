using System;
using System.Linq;

namespace Lab.Impl;

public class Assignment1_0_improved : IBaseLab
{
    public int AsterCount = 32;
    public int RowCount = 16;

    public void Execute()
    {
        RowCount = Utils.PromptInt("|: Row count? (blank for default) :|: ") ?? RowCount;
            AsterCount = Utils.PromptInt("|: Asterisk count? (blank for default) :|: ") ?? AsterCount;
    for (int i = 0; i < RowCount; i++)
        {
            bool spaceAtStart = i % 2 != 0;
            string output = string.Concat(Enumerable.Repeat("* ", AsterCount));
            if (spaceAtStart) output = $" {output}";
            Console.WriteLine(output);
        }
    }
}