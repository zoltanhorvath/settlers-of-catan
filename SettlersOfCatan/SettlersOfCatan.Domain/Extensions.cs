using SettlersOfCatan.Domain.Enums;
using SettlersOfCatan.Domain.Map;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SettlersOfCatan.Domain
{
    public static class Extensions
    {
        public static Dictionary<ResourceType, int> PutResourceTypes(this Dictionary<ResourceType, int> dictionary)
        {
            var resourceTypes = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>().ToList();
            resourceTypes.Remove(ResourceType.Nothing);
            foreach (var resourceType in resourceTypes)
            {
                dictionary.Add(resourceType, 0);
            }
            return dictionary;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static ResourceType GetResourceType(this TerrainType terrainType)
        {
            var resourceValues = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>().ToList();
            return resourceValues[(int)terrainType];
        }

        public static void Push<T>(this T[] array, T item)
        {
            var index = Array.FindIndex<T>(array, item => item == null);
            if (index == -1)
            {
                throw new ArgumentException("Array does not contain a null item.");
            }
            array[index] = item;
        }

        public static TerrainType Pop(this List<TerrainType> terrainTypes)
        {
            var terrainType = terrainTypes[0];
            terrainTypes.RemoveAt(0);
            return terrainType;
        }

        public static Coordinates GetNeighbourCoordinates(this Direction direction, Coordinates coordinates)
        {
            var x = coordinates.X;
            var y = coordinates.Y;
            var z = coordinates.Z;

            switch (direction)
            {
                case Direction.NorthEast:
                    x++; z--; break;
                case Direction.East:
                    y++; z--; break;
                case Direction.SouthEast:
                    x--; y++; break;
                case Direction.SouthWest:
                    x--; z++; break;
                case Direction.West:
                    y--; z++; break;
                case Direction.NorthWest:
                    x++; y--; break;

            }
            return new Coordinates { X = x, Y = y, Z = z };
        }

        public static int TranslateToEdgeIndex(this Direction direction)
        {
            var remainder = (int)direction % 3;
            return remainder switch
            {
                0 => 1,
                1 => 0,
                2 => 2,
                _ => throw new ArgumentException(),
            };
        }

        public static int TranslateToNeighbourVertexIndex(this Direction direction, int offset)
        {
            return ((int)direction + offset) % 6;
        }
    }
}
