namespace AdventOfCode2022.Utils;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents a coordinate in a 2-4 dimensional system.
/// </summary>
public class Coordinate : IComparable
{
    public Coordinate(int x, int y, int z = 0, int w = 0)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public int X { get; }

    public int Y { get; }

    public int Z { get; }

    public int W { get; }

    public IList<Coordinate> GetNeighbors(bool includeDiagonals = true)
    {
        var neighbors = new List<Coordinate>
        {
            this + Vector.North,
            this + Vector.South,
            this + Vector.West,
            this + Vector.East,
        };

        if (includeDiagonals)
        {
            neighbors.Add(this + Vector.North + Vector.East);
            neighbors.Add(this + Vector.North + Vector.West);
            neighbors.Add(this + Vector.South + Vector.East);
            neighbors.Add(this + Vector.South + Vector.West);
        }

        return neighbors;
    }

    public IList<Coordinate> GetCubeNeighbors()
    {
        return new List<Coordinate>
        {
            this + Vector.North,
            this + Vector.South,
            this + Vector.West,
            this + Vector.East,
            this + Vector.Up,
            this + Vector.Down
        };
    }

    public override string ToString()
    {
        return $"({X},{Y},{Z},{W})";
    }

    public override bool Equals(object obj)
    {
        if (obj is Coordinate otherCoordinate)
        {
            return otherCoordinate.X.Equals(X) && otherCoordinate.Y.Equals(Y) && otherCoordinate.Z.Equals(Z) && otherCoordinate.W.Equals(W);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
    }

    public int CompareTo(object obj)
    {
        if (obj is Coordinate other)
        {
            if (other.Equals(this))
            {
                return 0;
            }
        }

        return -1;
    }

    public static int ManhattanDistance(Coordinate origin, Coordinate destination)
    {
        if (origin.Equals(destination))
        {
            return 0;
        }

        return Math.Abs(destination.X - origin.X) + Math.Abs(destination.Y - origin.Y);
    }

    public static Coordinate Zero => new(0, 0);

    public static Coordinate operator +(Coordinate a, Vector b)
    {
        return new Coordinate(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }

    public static Coordinate operator -(Coordinate a, Vector b)
    {
        return new Coordinate(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }

    public static Vector operator -(Coordinate a, Coordinate b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }
}