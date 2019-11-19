using System;
using Newtonsoft.Json.Linq;
using SettlersOfCatan.Domain.Enums;

namespace SettlersOfCatan.Domain.Map
{
    public class Hexagon : IdentifiableBase
    {
        private bool _isBuilt;

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
                    vertex.Settlement?.ProduceResource(Terrain);
                }
            }
        }

        public void Build(MapSupervisor mapSupervisor)
        {
            if (!_isBuilt)
            {
                CreateOrAssignNeighbors(mapSupervisor);
                CreateOrAssignVerticesAndEdgesFromNeighbour();
                ConnectVerticesAndEdges();
                _isBuilt = true;
                foreach (var neighbor in Neighbours) neighbor?.Build(mapSupervisor);
            }
        }

        private void CreateOrAssignNeighbors(MapSupervisor mapSupervisor)
        {
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var directionAsInt = (int)direction;
                var neighborHexagonCoordinates = direction.GetNeighbourCoordinates(Coordinates);
                if (neighborHexagonCoordinates.IsWithinBoundaries(mapSupervisor.MapSettings))
                {
                    var alreadyExists =
                        mapSupervisor.Map.TryGetValue(neighborHexagonCoordinates, out var neighborHexagon);
                    if (!alreadyExists)
                    {
                        neighborHexagon = new Hexagon { Coordinates = neighborHexagonCoordinates };
                        mapSupervisor.Map.Add(neighborHexagonCoordinates, neighborHexagon);
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

        public JToken ToJToken()
        {
            var verticesJArray = new JArray();
            foreach (var vertex in Vertices)
            {
                verticesJArray.Add(vertex.ToJToken());
            }

            var edgesJArray = new JArray();
            foreach (var edge in Edges)
            {
                edgesJArray.Add(edge.ToJToken());
            }
            var neighborsJArray = new JArray();
            foreach (var neighbor in Neighbours)
            {
                if (neighbor != null)
                {
                    neighborsJArray.Add(neighbor.Id);
                }
            }

            var jObject = new JObject
            {
                { nameof(Id), Id },
                { nameof(Coordinates), Coordinates.ToJToken() },
                { nameof(Terrain), Terrain.ToString() },
                { nameof(HasRobber), HasRobber },
                { nameof(Neighbours), neighborsJArray },
                { nameof(Vertices), verticesJArray },
                { nameof(Edges), edgesJArray }
            };

            return jObject;
        }

    }
}