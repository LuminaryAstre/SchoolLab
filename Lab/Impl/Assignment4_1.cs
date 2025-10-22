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
        string output = "";

        uint bitsUsed = (uint)(Math.Pow(2, Math.Ceiling(Math.Log2(Math.Log2(Math.Pow(2,Math.Ceiling(Math.Log2((uint)input+1))))))));
        for (int i = 0; i < bitsUsed; i++)
        {
            output = (((uint)input >> i) & 1) + output;
        }

        Utils.WriteLine(Pad(output, bitsUsed));
    }

    public string Pad(string input, uint len)
    {
        string final = input;
        while (final.Length < len)
            final = "0" + final;
        return final;
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}