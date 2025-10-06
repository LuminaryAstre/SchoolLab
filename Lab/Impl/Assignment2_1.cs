using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.Impl;

public class Assignment2_1 : IBaseLab
{
    private Vector2I currentPos = new Vector2I(0, 0);
    private Vector2I lastPos = new Vector2I(0, 0);
    private List<Vector2I> Segments = [];
    private readonly string InstructionMessage = "~  :|:  W/A/S/D to move.   :|:   Q to exit.";
    private readonly int SegmentLength = 12;
    
    public void Execute()
    {
        Console.Clear();
        Console.SetCursorPosition(0, Console.WindowHeight - 1);
        Console.Write(InstructionMessage);
        Console.SetCursorPosition(0, 0);
        while (true)
        {
            Vector2I res = new Vector2I(Console.WindowWidth, Console.WindowHeight);
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.A:
                    currentPos.x--;
                    break;
                case ConsoleKey.W:
                    currentPos.y--;
                    break;
                case ConsoleKey.S:
                    currentPos.y++;
                    break;
                case ConsoleKey.D:
                    currentPos.x++;
                    break;
                case ConsoleKey.Q:
                    goto exit;
            }

            currentPos.Conform(res.x - 1, res.y - 2);
            currentPos.Apply(i => Math.Max(i, 0));
            if (currentPos.Equals(lastPos) || Segments.Find(x => currentPos.Equals(x)) != null)
            {
                currentPos = lastPos.Copy();
                Console.SetCursorPosition(0, res.y - 1);
                Console.Write(InstructionMessage);
                Console.SetCursorPosition(0, res.y - 1);
                continue;
            }
            if (Segments.Count >= SegmentLength)
            {
                Vector2I toRemove = Segments.Pop();
                Console.SetCursorPosition(toRemove.x, toRemove.y);
                Console.Write(" ");
            }

            Console.SetCursorPosition(lastPos.x, lastPos.y);
            Console.Write("#");
            Segments.Add(lastPos.Copy());
            lastPos = currentPos.Copy();
            Console.SetCursorPosition(currentPos.x, currentPos.y);
            Console.Write("@");
            Console.SetCursorPosition(0, res.y - 1);
            Console.Write(InstructionMessage);
            Console.SetCursorPosition(0, res.y - 1);
        }
        exit:
        Console.WriteLine("Exiting...");
    }

    public bool Test()
    {
        throw new NotImplementedException();
    }
}