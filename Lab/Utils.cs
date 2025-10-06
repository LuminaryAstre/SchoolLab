using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lab;

public static class Utils
{
    private static bool _reprompt = false;
    public static bool YesNo(string? msg)
    {
        Console.Write(_reprompt ? "\b \b" : $"|: {msg} [y/n] ");
        bool value;

        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key != ConsoleKey.Y && key.Key != ConsoleKey.N)
        {
            _reprompt = true;
            value = YesNo(msg);
        } else {
            Console.Write("\n");
            value = key.Key == ConsoleKey.Y;
        }

        _reprompt = false;
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

    public static T Pop<T>(this List<T> ls)
    {
        T value = ls[0];
        ls.RemoveAt(0);
        return value;
    }
}