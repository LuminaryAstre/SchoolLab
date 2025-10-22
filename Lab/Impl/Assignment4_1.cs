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
        Utils.Log(
            "NOTE!\nThis returns the bits of the byte, padded to the nearest 2^n bits.\nThis is because it would look ass otherwise.\nThank you for your understanding.");
        int input = Utils.PromptInt("|: Input number: :|: ") ?? 0;
        string output = "";

        // Shoutout to @akiraveliara on GitHub for helping me make this less of a horror to look at.
        // If you're curious, here's the original line:
        // uint bitsUsed = (uint)Math.Pow(2, Math.Ceiling(Math.Log2(Math.Log2(Math.Pow(2,Math.Ceiling(Math.Log2((uint)input+1)))))));
        // Behold, the power of the septuple closing parentheses!
        uint bitsUsed = BitOperations.RoundUpToPowerOf2(32 - (uint)BitOperations.LeadingZeroCount(uint.Max(128, (uint)input)));
        for (int i = 0; i < bitsUsed; i++)
        {
            output = (((uint)input >> i) & 1) + output;
        }

        output = Pad(output, bitsUsed);
        Utils.WriteLine($"|: {input} converted to binary is {output} ({bitsUsed} bits) :|");
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