using System;
using System.Globalization;

namespace Lab;

public static class Utils
{
    public static bool YesNo(string? msg)
    {
        Console.Write($"|: {msg} [y/n] ");
        bool value;

        ConsoleKeyInfo key = Console.ReadKey();
        Console.Write("\n");
        if (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N)
            value = YesNo(msg);
        else
            value = key.Key == ConsoleKey.Y;

        return value;
    }

    public static void Log(string msg)
    {
        if (msg.IndexOf("\n", StringComparison.InvariantCulture) == -1)
        {
            Console.WriteLine($"// {msg}");
        }
        else
        {
            string output = string.Join("\n    ", msg.Split("\n"));
            output = $"/*\n    {output}\n*/";
            Console.WriteLine(output);
        }
    }

    public static string PromptString(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine() ?? "";
    }

    public static int? PromptInt(string msg)
    {
        string input = PromptString(msg);
        try
        {
            return Int32.Parse(input, NumberStyles.Integer);
        }
        catch (FormatException e)
        {
            Log($"Failed to parse integer: {e.Message}");
            return null;
        }
    }

    public static double? PromptDouble(string msg)
    {
        string input = PromptString(msg);
        try
        {
            return Double.Parse(input);
        }
        catch (FormatException e)
        {
            Log($"Failed to parse double: {e.Message}");
            return null;
        }
    }
}