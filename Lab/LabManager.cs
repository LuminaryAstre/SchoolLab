using System;
using System.Collections.Generic;

namespace Lab;

public static class LabManager
{
    public static readonly Dictionary<string, IBaseLab> RegisteredLabs = [];

    public static bool Exists(string key) => RegisteredLabs.ContainsKey(key);

    public static void ExecuteLab(string key)
    {
        if (RegisteredLabs.TryGetValue(key, out IBaseLab? value))
        {
            value.Execute();
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