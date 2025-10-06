using System;
using System.Runtime.CompilerServices;

namespace Lab;

public enum ClampMethod
{
    Individual = 0,
    Length = 1
}

public struct Vector2I
{
    public int x;
    public int y;

    public readonly float Length => MathF.Sqrt(x * x + y * y);

    public Vector2I(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2I Conform(int maxX, int maxY)
    {
        x = Math.Min(x, maxX);
        y = Math.Min(y, maxY);
        return this;
    }

    public Vector2I Conforming(int maxX, int maxY)
    {
        return Conform(maxX, maxY);
    }

    public Vector2I Clamp(int min, int max, ClampMethod method = ClampMethod.Individual)
    {
        if (method == ClampMethod.Individual)
        {
            x = Math.Clamp(x, min, max);
            y = Math.Clamp(y, min, max);
            return this;
        }

        int factor = (int)Math.Floor(Math.Clamp((int)Length, min, max) / Length);
        x *= factor;
        y *= factor;
        return this;
    }

    public readonly Vector2I Clamped(int min, int max, ClampMethod method = ClampMethod.Individual)
    {
        return new Vector2I(x, y).Clamp(min, max, method);
    }

    public Vector2I Apply(Func<int, int?> cb)
    {
        x = cb(x) ?? x;
        y = cb(y) ?? y;
        return this;
    }

    public readonly Vector2I Applied(Func<int, int?> cb)
    {
        return new Vector2I(x, y).Apply(cb);
    }

    public readonly override bool Equals(object? obj)
    {
        return obj?.GetType() == this.GetType() && this.Equals((Vector2I)obj);
    }

    public readonly bool Equals(Vector2I other)
    {
        return x == other.x && y == other.y;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = (hash * 23) + x.GetHashCode();
            hash = (hash * 23) + y.GetHashCode();
            return hash;
        }
    }

    public static bool operator ==(Vector2I left, Vector2I right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vector2I left, Vector2I right)
    {
        return !left.Equals(right);
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