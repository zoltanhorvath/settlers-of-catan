using SettlersOfCatan.Domain.Enums;
using System;
using System.Collections.Generic;
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
            var current = 100 * Z + 10 * X + Y;
            var other = otherCoordinates.Z * 100 + otherCoordinates.X * 10 + otherCoordinates.Y;
            return current - other;
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


    }
    public class MapCreator
    {
        private Dictionary<TerrainType, int> numberOfDifferentTerrainTypes = new Dictionary<TerrainType, int>
        {
            { TerrainType.Desert, 1 },
            { TerrainType.Fields, 4 },
            { TerrainType.Forest, 4 },
            { TerrainType.Hills, 3 },
            { TerrainType.Mountains, 3 },
            { TerrainType.Pasture,4 }
        };

        private int MAX = 5 / 2 + 1;
        private int MIN = (5 / 2) * -1;

        private List<TerrainType> AvailableTerrainTypes = new List<TerrainType>();

        private SortedDictionary<Coordinates, Hexagon> coMap = new SortedDictionary<Coordinates, Hexagon>();
        private List<Direction> DirectionsToCheck = new List<Direction>
        {
            Direction.SouthEast, Direction.SouthWest, Direction.West
        };

        public SortedDictionary<Coordinates, Hexagon> BuildMap()
        {
            for (var i = MIN; i < MAX; i++)
            {
                for (var j = MIN; j < MAX; j++)
                {
                    for (var k = MIN; k < MAX; k++)
                    {
                        if (i + j + k == 0)
                        {
                            var hexagon = new Hexagon();
                            var coordinates = new Coordinates { X = i, Y = j, Z = k };
                            coMap.Add(coordinates, hexagon);
                            
                        }
                    }
                }
            }
            foreach (var kvp in coMap)
            {
                CreateVertices(kvp.Key, kvp.Value);
            }
            return coMap;
        }

        private void CreateVertices(Coordinates coordinates, Hexagon hexagon)
        {
            for (var i = 0; i < 2; i++)
            {
                hexagon.Vertices[i] = new Vertex();
            }
            foreach (Direction direction in DirectionsToCheck)
            {
                var coordinateOfNeightbourInDirection = direction.GetNeighbourCoordinates(coordinates);
                if (coMap.TryGetValue(coordinateOfNeightbourInDirection, out var neighbourHexagon))
                {
                    var index = (int)direction;
                    hexagon.Vertices[index] = neighbourHexagon.Vertices[index - 2];
                    index++;
                    hexagon.Vertices[index] = neighbourHexagon.Vertices[index - 2];
                }
                else
                {
                    var index = (int)direction;
                    hexagon.Vertices[index] = new Vertex();
                    index = index++ % 6;
                    hexagon.Vertices[index] = new Vertex();
                }
            }
        }


        private void AssignVerticesToEdge(int i, Hexagon hexagon)
        {
            var edge = hexagon.Edges[i];
            var j = i + 1 > 5 ? 0 : i + 1;
            var listOfVertexIndices = new List<int>() { i, j };
            foreach (var index in listOfVertexIndices)
            {
                edge.Vertices.Push(hexagon.Vertices[index]);
            }
        }

        private void AssignEdgesToVertex(int i, Hexagon hexagon)
        {
            var vertex = hexagon.Vertices[i];
            var j = i - 1 < 0 ? 5 : i - 1;
            var listofEdgeIndices = new List<int>() { i, j };
            foreach (var index in listofEdgeIndices)
            {
                vertex.Edges.Push(hexagon.Edges[index]);
            }
        }

        private void FillUpAvailableTerrainTypes()
        {
            foreach (var kvp in numberOfDifferentTerrainTypes)
            {
                for (var i = 0; i < kvp.Value; i++)
                {
                    AvailableTerrainTypes.Add(kvp.Key);
                }
            }
            AvailableTerrainTypes.Shuffle();
        }

        private void FirstRow()
        {
            var hexagon = new Hexagon();

        }
        /*
       private void s()
       {
           var hexagon = CreateHexagon();
           var lastIndex = Hexagons.Count - 1;
           var previousHexagon = Hexagons[lastIndex];
           for (var index = 0; index < 6; index++)
           {
               if (index == 4)
               {
                   hexagon.Edges[index] = previousHexagon.Edges[2];
                   hexagon.Vertices[index] = previousHexagon.Vertices[1];
               }
               else if (index == 5)
               {
                   hexagon.Edges[index] = previousHexagon.Edges[1];
                   hexagon.Vertices[index] = new Vertex();
               }
               else
               {
                   hexagon.Edges[index] = new Edge();
                   hexagon.Vertices[index] = new Vertex();
               }
           }

           for (var index = 0; index < 6; index++)
           {

               if (index == 4)
               {
                   var firstNullIndexOfVertices = FindFirstNullIndex(hexagon.Edges[index].Vertices);
                   hexagon.Edges[index].Vertices[firstNullIndexOfVertices] = hexagon.Vertices[index - 1];
               }
               else if (index == 5)
               {
                   var firstNullIndexOfVertices = FindFirstNullIndex(hexagon.Edges[index].Vertices);
                   hexagon.Edges[index].Vertices[firstNullIndexOfVertices] = hexagon.Vertices[index];

                   var firstNullIndexOfEdges = FindFirstNullIndex(hexagon.Vertices[index].Edges);
                   hexagon.Vertices[index].Edges[firstNullIndexOfEdges] = hexagon.Edges[index];

                   firstNullIndexOfEdges = FindFirstNullIndex(hexagon.Vertices[index].Edges);
                   hexagon.Vertices[index].Edges[firstNullIndexOfEdges] = hexagon.Edges[0];
               }
               else
               {
                   AssignVerticesToEdge(index, hexagon);
                   AssignEdgesToVertex(index, hexagon);
               }

           }
           
        Map.Add(hexagon.Id, hexagon);
            Hexagons.Add(hexagon);
        }
        */
        private Hexagon CreateHexagon()
        {
            return new Hexagon()
            {
                Terrain = AvailableTerrainTypes.Pop()
            };
        }
    }
}
