using System;

namespace Lab;

public enum ClampMethod
{
    Individual = 0,
    Length = 1
}

public class Vector2I
{
    public int x;
    public int y;

    public float Length => MathF.Sqrt(x * x + y * y);

    public Vector2I(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2I Copy() => this * 1;

    public Vector2I Conform(int maxX, int maxY)
    {
        x = Math.Min(x, maxX);
        y = Math.Min(y, maxY);
        return this;
    }

    public Vector2I Conforming(int maxX, int maxY)
    {
        return Copy().Conform(maxX, maxY);
    }

    public Vector2I Clamp(int min, int max, ClampMethod method = ClampMethod.Individual)
    {
        if (method == ClampMethod.Individual)
        {
                x = Math.Clamp(x, min, max);
                y = Math.Clamp(y, min, max);
                return this;
        }

        int factor = (int)Math.Floor(Math.Clamp((int)Length,  min, max) / Length);
        x *= factor;
        y *= factor;
        return this;
    }

    public Vector2I Clamped(int min, int max, ClampMethod method = ClampMethod.Individual)
    {
        return (this * 1).Clamp(min, max, method);
    }

    public Vector2I Apply(Func<int, int?> cb)
    {
        x = cb(x) ?? x;
        y = cb(y) ?? y;
        return this;
    }

    public Vector2I Applied(Func<int, int?> cb)
    {
        return Copy().Apply(cb);
    }

    public override bool Equals(object? obj)
    {
        return obj?.GetType() == this.GetType() && this.Equals((Vector2I)obj);
    }

    protected bool Equals(Vector2I other)
    {
        return x == other.x && y == other.y;
    }

    public static Vector2I operator +(Vector2I a, Vector2I b)
    {
        return new Vector2I(a.x + b.x, a.y + b.y);
    }

    public static Vector2I operator +(Vector2I a, int b)
    {
        return a + new Vector2I(b, b);
    }

    public static Vector2I operator /(Vector2I a, Vector2I b)
    {
        return new Vector2I(a.x / b.x, a.y / b.y);
    }

    public static Vector2I operator /(Vector2I a, int b)
    {
        return a / new Vector2I(b, b);
    }

    public static Vector2I operator *(Vector2I a, Vector2I b)
    {
        return new Vector2I(a.x * b.x, a.y * b.y);
    }

    public static Vector2I operator *(Vector2I a, int b)
    {
        return a * new Vector2I(b, b);
    }

    public static Vector2I operator %(Vector2I a, Vector2I b)
    {
        return new Vector2I(a.x % b.x, a.y % b.y);
    }

    public static Vector2I operator %(Vector2I a, int b)
    {
        return a % new Vector2I(b, b);
    }
}