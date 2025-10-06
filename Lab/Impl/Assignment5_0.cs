using System;

namespace Lab.Impl;

public class Assignment5_0 : IBaseLab
{
    public void Execute()
    {
        Utils.WriteLine("You didn't really give me anything to do here.");
        Utils.WriteLine("I've literally been using something described in");
        Utils.WriteLine("the assignment for every single other assignment.");
        Utils.WriteLine("Hey cool, you typed: " + Utils.PromptString("I guess I'll just give you this prompt... "));
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}