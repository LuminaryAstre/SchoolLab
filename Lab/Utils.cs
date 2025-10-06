using System;
using System.Collections.Generic;
using System.Text;

namespace Lab;

public static class Utils
{
    private const string CYAN = "\x1B[36m";
    private const string DEFAULT = "\x1B[0m";

    private static readonly StringBuilder outputBuffer = new();

    public static bool DebugLoggingEnabled { get; set; }

    public static bool YesNo(string? msg)
    {
        Console.Write($"|: {msg} [y/n] :|: ");
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key is ConsoleKey.Y or ConsoleKey.N)
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
        // This seems to be the only time output is appended to.
        // I'll assume an unfinished feature :)
        outputBuffer.Append(msg);
    }

    public static void WriteLine(string msg)
    {
        Write(msg + "\n");
    }

    public static void Log(string msg)
    {
        if (!msg.Contains('\n', StringComparison.InvariantCulture))
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

    public static void LogDebug(string msg)
    {
        if (!DebugLoggingEnabled)
        {
            return;
        }

        // Cyan is just a personal preference for "debugging colors".
        // You can use another color if you'd like.
        Log(string.Concat(CYAN, msg, DEFAULT));
    }

    public static string PromptString(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine() ?? string.Empty;
    }

    public static int? PromptInt(string msg)
    {
        string input = PromptString(msg);

        // Exceptions are super slow. Unless you wanted the parsing fault reason...
        if (!int.TryParse(input, out int value))
        {
            Log($"Failed to parse double. Check formatting.");
            return null;
        }

        return value;
    }

    public static double? PromptDouble(string msg)
    {
        string input = PromptString(msg);

        if (!double.TryParse(input, out double value))
        {
            Log($"Failed to parse double. Check formatting.");
            return null;
        }

        return value;
    }

    public static T Pop<T>(this List<T> ls, int index = 0)
    {
        T value = ls[index];
        ls.RemoveAt(index);
        return value;
    }
}