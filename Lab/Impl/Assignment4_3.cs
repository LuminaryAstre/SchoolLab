using System;

namespace Lab.Impl;

public class Assignment4_3 : IBaseLab
{
    public void Execute()
    {
        string binary = Utils.PromptString("|: Input binary :|: ");
        try
        {
            uint output = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                bool bit = binary[binary.Length - i - 1] == '1';
                if (!bit && binary[binary.Length - i - 1] != '0')
                    throw new ArgumentException(
                        "Found non-binary character! We don't support trinary in this function.");
                output |= (uint)(bit ? 1 : 0) << i;
            }

            Console.WriteLine(output);
        }
        catch (Exception e)
        {
            Utils.WriteLine($"Failed to convert from binary:\n{e.Message}");
        }
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}