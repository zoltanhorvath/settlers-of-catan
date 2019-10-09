using SettlersOfCatan.Domain.Enums;
using System.Collections.Generic;

namespace SettlersOfCatan.Domain
{
    public class Hexagon
    {
        public TerrainType Terrain { get;}
        public int Number { get; }
        public List<Vertex> Vertices { get; }

        public Hexagon(TerrainType terrain, int number, List<Vertex> vertices)
        {
            Terrain = terrain;
            Number = number;
            Vertices = vertices;
        }
    }
}
