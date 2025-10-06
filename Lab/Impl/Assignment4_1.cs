using System;
using System.Buffers.Binary;
using System.Collections;
using System.Linq;
using System.Numerics;

namespace Lab.Impl;

public class Assignment4_1 : IBaseLab
{
    public void Execute()
    {
        int input = Utils.PromptInt("|: Input number: :|: ") ?? 0;
        string output = Convert.ToString(input, 2);
        
        Utils.WriteLine(output);
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}