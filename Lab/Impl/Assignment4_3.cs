using System;

namespace Lab.Impl;

public class Assignment4_3 : IBaseLab
{
    public void Execute()
    {
        string binary = Utils.PromptString("|: Input binary :|: ");
        try
        {
            int res = Convert.ToInt32(binary, 2);
            Utils.WriteLine($"Converted to {res}");
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