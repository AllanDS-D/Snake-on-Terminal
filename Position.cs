namespace snake.position;

public class Position
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(Position p1, Position p2)
    {
        // Se ambos forem nulos, ou apontarem para o mesm objeto na memória;
        if(ReferenceEquals(p1, p2)) return true;
        // Se um deles for nulo (e o outro não), são diferentes
        if(p1 is null || p2 is null) return false;

        return p1.X == p2.X && p1.Y == p2.Y;
    }

    public static bool operator !=(Position p1, Position p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object? obj)
    {
        if(obj is Position other) return X == other.X && Y == other.Y;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}