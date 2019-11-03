using System;
using System.Diagnostics.CodeAnalysis;

namespace SettlersOfCatan.Domain.Map
{
    public class Coordinates : IEquatable<Coordinates>, IComparable<Coordinates>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public int CompareTo(Coordinates otherCoordinates)
        {
            if (X < otherCoordinates.X) return 1;
            if (X == otherCoordinates.X)
            {
                if (Y == otherCoordinates.Y)
                {
                    if (Z == otherCoordinates.Z) return 0;
                    if (Z > otherCoordinates.Z) return 1;
                    if (Z < otherCoordinates.Z) return -1;
                }
                if (Y < otherCoordinates.Y) return -1;
                return 1;
            }
            return -1;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Coordinates);
        }

        public bool Equals([AllowNull] Coordinates other)
        {
            return other != null &&
                   X == other.X &&
                   Y == other.Y &&
                   Z == other.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public bool IsWithinBoudaries(MapSettings mapSettings)
        {
            return X >= mapSettings.MinimumCoordinateValue && X <= mapSettings.MaximumCoordinateValue
                && Y >= mapSettings.MinimumCoordinateValue && Y <= mapSettings.MaximumCoordinateValue
                && Z >= mapSettings.MinimumCoordinateValue && Z <= mapSettings.MaximumCoordinateValue;
        }

        public override string ToString()
        {
            return @$"{{
                x: {X}, 
                y: {Y}, 
                z: {Z}
            }}";
        }
    }
}
