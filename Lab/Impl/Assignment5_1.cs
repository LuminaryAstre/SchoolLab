using System;

namespace Lab.Impl;

public class Assignment5_1 : IBaseLab
{
    public void Execute()
    {
        Console.WriteLine("This is just assignment 1.2");
        LabManager.ExecuteLab("1.2");
    }

    public bool Test()
    {
        throw new System.NotImplementedException();
    }
}