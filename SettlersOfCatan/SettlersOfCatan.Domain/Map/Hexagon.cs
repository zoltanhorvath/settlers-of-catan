using SettlersOfCatan.Domain.Enums;
using SettlersOfCatan.Domain.Map;
using System;
using System.Collections.Generic;

namespace SettlersOfCatan.Domain
{
    public class Hexagon : IdentifiableBase
    {
        public Coordinates Coordinates { get; set; }

        public TerrainType Terrain { get; set; }

        public int Number { get; set; }

        public Vertex[] Vertices { get; } = new Vertex[6];

        public Edge[] Edges { get; } = new Edge[6];

        public Hexagon[] Neighbours { get; } = new Hexagon[6];

        public bool HasRobber { get; set; }

        public void ProduceResource()
        {
            if (!HasRobber)
            {
                foreach (var vertex in Vertices)
                {
                    vertex.Settlement.ProduceResource(Terrain);
                }
            }
        }

        public void G(MapSettings mapSetting)
        {
            CreateNeighbours(mapSetting);
            AssignVertices();
        }

        private void CreateNeighbours(MapSettings mapSettings)
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var directionAsInt = (int)direction;
                var neighbourHexagonCoordinates = direction.GetNeighbourCoordinates(Coordinates);
                if (neighbourHexagonCoordinates.IsWithinBoudaries(mapSettings))
                {
                    bool alreadyExists = mapSettings.Map.TryGetValue(neighbourHexagonCoordinates, out Hexagon neighbourHexagon);
                    if (!alreadyExists)
                    {
                        neighbourHexagon = new Hexagon { Coordinates = neighbourHexagonCoordinates };
                        mapSettings.Map.Add(neighbourHexagonCoordinates, neighbourHexagon);
                    }
                    Neighbours[directionAsInt] = neighbourHexagon;
                }
            }
        }

        private void AssignVertices()
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var directionAsInt = (int)direction;
                var edge = new Edge();
                var vertex = new Vertex();
                Vertices[directionAsInt] = vertex;
                Edges[directionAsInt] = edge;
                edge.Vertices.Push(vertex);
                vertex.Edges[direction.TranslateToEdgeIndex()] = edge;
                if (directionAsInt - 1 >= 0)
                {

                }



                var neighbour = Neighbours[directionAsInt];
                if (neighbour != null)
                {
                    for (var i = 0; i < 2; i++)
                    {
                        var calculatedIndex = GetIndex(directionAsInt, i);
                        var vertex = neighbour.Vertices[GetIndex(calculatedIndex, 4 - 2 * i)];
                        if (vertex == null)
                        {
                            vertex = new Vertex();
                        }
                        else
                        {
                            Vertices[directionAsInt] = vertex;
                        }
                    }
                }
                else
                {
                    Edge edge = new Edge();
                    Edges[directionAsInt] = edge;
                    for (var i = 0; i < 2; i++)
                    {
                        var calculatedIndex = GetIndex(directionAsInt, i);
                        var vertex = new Vertex();
                        vertex.Edges.Push(edge);
                        edge.Vertices.Push(vertex);
                        Vertices[calculatedIndex] = vertex;
                    }
                }
            }
        }

        private int GetIndex(int i, int offset)
        {
            if (offset == 0) return i;

            offset %= 6;

            if (offset < 0)
            {
                return (6 + offset + i) % 6;
            }
            return (i + offset) % 6;
        }
        private void CreateTwoVerticesWith()
        {

        }

    }

    public class MapSettings
    {
        public int MinimumCoordinateValue { get; }

        public int MaximumCoordianteValue { get; }

        public SortedDictionary<Coordinates, Hexagon> Map { get; } = new SortedDictionary<Coordinates, Hexagon>();

        public MapSettings(int minimumCoordinateValue, int maximuCoordianteValue)
        {
            MinimumCoordinateValue = minimumCoordinateValue;
            MaximumCoordianteValue = maximuCoordianteValue;
        }
    }
}
