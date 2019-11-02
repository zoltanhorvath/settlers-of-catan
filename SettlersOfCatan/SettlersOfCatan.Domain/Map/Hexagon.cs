using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SettlersOfCatan.Domain.Enums;
using SettlersOfCatan.Domain.Map;

namespace SettlersOfCatan.Domain
{
    public class Hexagon : IdentifiableBase
    {
        private bool IsInitialized;
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
                foreach (var vertex in Vertices)
                    vertex.Settlement.ProduceResource(Terrain);
        }

        public void G(MapSettings mapSetting)
        {
            if (!IsInitialized)
            {
                CreateOrAssignNeighbors(mapSetting);
                CreateOrAssignVerticesAndEdgesFromNeighbour();
                ConnectVerticesAndEdges();
                IsInitialized = true;
                Console.WriteLine(ToString());
                foreach (var neighbor in Neighbours) neighbor?.G(mapSetting);
            }
        }

        private void CreateOrAssignNeighbors(MapSettings mapSettings)
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var directionAsInt = (int)direction;
                var neighborHexagonCoordinates = direction.GetNeighbourCoordinates(Coordinates);
                if (neighborHexagonCoordinates.IsWithinBoudaries(mapSettings))
                {
                    var alreadyExists =
                        mapSettings.Map.TryGetValue(neighborHexagonCoordinates, out var neighborHexagon);
                    if (!alreadyExists)
                    {
                        neighborHexagon = new Hexagon { Coordinates = neighborHexagonCoordinates };
                        mapSettings.Map.Add(neighborHexagonCoordinates, neighborHexagon);
                    }

                    Neighbours[directionAsInt] = neighborHexagon;
                }
            }
        }

        private void CreateOrAssignVerticesAndEdgesFromNeighbour()
        {
            foreach (int direction in Enum.GetValues(typeof(Direction)))
            {
                Vertices[direction] = Neighbours[direction]?.Vertices[GetIndex(direction, 4)] ?? new Vertex();
                Edges[direction] = Neighbours[direction]?.Edges[GetIndex(direction, 3)] ?? new Edge();
            }
        }


        private void ConnectVerticesAndEdges()
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var directionAsInt = (int)direction;

                var currentVertex = Vertices[directionAsInt];
                var nextVertex = Vertices[GetIndex(directionAsInt, 1)];
                var edgeIndex = direction.TranslateToEdgeIndex();
                if (currentVertex.Edges[edgeIndex] == null && nextVertex.Edges[edgeIndex] == null)
                {
                    var edge = Edges[directionAsInt];
                    edge.Vertices.Push(currentVertex);
                    edge.Vertices.Push(nextVertex);
                    currentVertex.Edges[direction.TranslateToEdgeIndex()] = edge;
                    nextVertex.Edges[direction.TranslateToEdgeIndex()] = edge;
                }
            }
        }

        private int GetIndex(int i, int offset)
        {
            if (offset == 0) return i;

            offset %= 6;

            if (offset < 0) return (6 + offset + i) % 6;
            return (i + offset) % 6;
        }
    }

    public class MapSettings
    {
        public MapSettings(int minimumCoordinateValue, int maximumCoordinateValue)
        {
            MinimumCoordinateValue = minimumCoordinateValue;
            MaximumCoordinateValue = maximumCoordinateValue;
        }

        public int MinimumCoordinateValue { get; }

        public int MaximumCoordinateValue { get; }

        public SortedDictionary<Coordinates, Hexagon> Map { get; } = new SortedDictionary<Coordinates, Hexagon>();
    }
}