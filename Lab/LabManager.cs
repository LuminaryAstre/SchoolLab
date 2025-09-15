using System;
using System.Collections.Generic;

namespace Lab;

public static class LabManager
{
    public static Dictionary<string, IBaseLab> RegisteredLabs = new();

    public static void ExecuteLab(string key)
    {
        if (RegisteredLabs.ContainsKey(key))
        {
            RegisteredLabs[key].Execute();
        }
        else
        {
            throw new ArgumentException($"Lab {key} does not exist!");
        }
    }

    public static void Register(string name, IBaseLab lab)
    {
        if (!RegisteredLabs.TryAdd(name, lab))
            throw new ArgumentException($"A lab with name {name} has already been registered!");
    }
}