using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Lab.Impl;

namespace Lab;

class Program
{
    public static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        var labs = typeof(Program).Assembly.GetTypes()
            .Where(p => typeof(IBaseLab).IsAssignableFrom(p))
            .Where(p => !p.IsInterface)
            .ToList();

        foreach (var lab in labs)
        {
            try
            {
                IBaseLab? instance = (IBaseLab)Activator.CreateInstance(lab);
                if (instance == null) continue;
                Match m = Regex.Match(lab.Name, @"Assignment(\d+)_(.+)");
                string name = $"{m.Groups[1]}.{m.Groups[2]}".Replace("_", "-");
                LabManager.Register(name, instance);
                Utils.Log($"Registering lab {name} (./Impl/{lab.Name}.cs)");
            }
            catch (Exception e)
            {
                Utils.Log($"Failed to register {lab.Name}:\n{e.Message}\n{e.StackTrace}");
            }
        }
        
        start:
        Utils.Log("Input \"ls\" to list all available labs.\n\"clear\" to clear console.\n\"exit\" or \"segfault\" to terminate the program.\nInput the ID of a lab to execute it.");
        while (true)
        {
            Console.Write("|: ");
            string key = (Console.ReadLine() ?? "").Trim();
            if (key.Length == 0)
            {
                Console.Write("\r");
                continue;
            }
            if (key.ToLowerInvariant() == "exit") break;
            if (key.ToLowerInvariant() == "segfault")
            {
                unsafe
                {
                    // :)
                    _ = *(int*)(IntPtr)0xffffffff;
                }
            }
            if (key.ToLowerInvariant() == "ls")
            {
                foreach (string k in LabManager.RegisteredLabs.Keys)
                {
                    Utils.Log(k);
                }
                continue;
            }

            if (key.ToLowerInvariant() == "clear")
            {
                Console.Clear();
                goto start;
            }
            try
            {
                LabManager.ExecuteLab(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            
            if (!Utils.YesNo("\n// Program exited.\n// Back to start?")) break;
            goto start;
        }
    }
}