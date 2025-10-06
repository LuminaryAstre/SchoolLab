using System;
using System.Linq;

namespace Lab.Impl;

public class Assignment1_0 : IBaseLab
{
    public int AsterCount = 32;
    public int RowCount = 16;

    public void Execute()
    {
        for (int i = 0; i < RowCount; i++)
        {
            bool spaceAtStart = i % 2 != 0;
            string output = string.Concat(Enumerable.Repeat("* ", AsterCount));
            if (spaceAtStart) output = $" {output}";
            Utils.WriteLine(output);
        }
    }

    public bool Test()
    {
        throw new NotImplementedException();
    }
}