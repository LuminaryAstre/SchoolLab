using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lab;

public static class Utils
{
    public static string Output = "";
    public static bool YesNo(string? msg)
    {
        Console.Write($"|: {msg} [y/n] :|: ");
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y || key.Key == ConsoleKey.N)
            {
                Console.Write("\n");
                return key.Key == ConsoleKey.Y;
            }

            if (key.KeyChar != '\0') Console.Write("\b \b");
        }
    }

    public static void Write(string msg)
    {
        Console.Write(msg);
        Output += msg;
    }

    public static void WriteLine(string msg)
    {
        Write(msg + "\n");
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
        catch (OverflowException e)
        {
            Log($"Value was too large to be parsed as an Int32.");
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

    public static T Pop<T>(this List<T> ls, int index = 0)
    {
        T value = ls[index];
        ls.RemoveAt(index);
        return value;
    }
}