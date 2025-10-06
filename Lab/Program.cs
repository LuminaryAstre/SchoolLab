using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab;

partial class Program
{
    public static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        Utils.DebugLoggingEnabled = Utils.YesNo("Enable additional logging for LabManager?");

        if (Utils.YesNo("View TODO list?"))
        {
            Utils.Log("- Implement tests for each assignment.\n    [X] Output capture\n    [ ] Input manipulation\n    [ ] User Interface for testing");
        }

        var labs = typeof(Program).Assembly.GetTypes()
            .Where(p => typeof(IBaseLab).IsAssignableFrom(p) && !p.IsInterface)
            .ToList();

        foreach (var lab in labs)
        {
            try
            {
                if (Activator.CreateInstance(lab) is not IBaseLab instance) continue;

                Match m = InstanceRegisterRegex().Match(lab.Name);
                string name = $"{m.Groups[1]}.{m.Groups[2]}".Replace('_', '-');
                LabManager.Register(name, instance);
                Utils.LogDebug($"Registering lab {name} (./Impl/{lab.Name}.cs)");
            }
            catch (Exception e)
            {
                Utils.LogDebug($"Failed to register {lab.Name}:\n{e.Message}\n{e.StackTrace}");
            }
        }

        while (true)
        {
            MainLoop();
        }
    }

    private static void MainLoop()
    {
        Utils.Log("Input \"ls\" to list all available labs.\n\"clear\" to clear console.\n\"exit\" to terminate the program.\nInput the ID of a lab to execute it.");
        while (true)
        {
            Console.Write("|: ");
            string key = (Console.ReadLine() ?? string.Empty).Trim();
            if (key.Length == 0)
            {
                Console.Write("\r");
                continue;
            }

            if (key.Equals("exit", StringComparison.InvariantCultureIgnoreCase)) break;

            if (key.Equals("ls", StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (string k in LabManager.RegisteredLabs.Keys)
                {
                    Utils.Log(k);
                }
                continue;
            }

            if (key.Equals("clear", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.Clear();
                return;
            }

            if (!LabManager.Exists(key))
            {
                Utils.Log("Lab does not exist! (Perhaps it failed to load? Perhaps enable additional logs.)");
                return;
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

            if (!Utils.YesNo("\n// Program exited.\n// Back to start?"))
                break;
        }
    }

    [GeneratedRegex(@"Assignment(\d+)_(.+)")]
    private static partial Regex InstanceRegisterRegex();
}