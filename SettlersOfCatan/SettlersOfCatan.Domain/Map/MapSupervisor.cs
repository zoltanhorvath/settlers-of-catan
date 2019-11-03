using System;
using System.Collections.Generic;

namespace SettlersOfCatan.Domain.Map
{
    public class MapSupervisor
    {
        public SortedDictionary<Coordinates, Hexagon> Map { get; } = new SortedDictionary<Coordinates, Hexagon>();
        
        private readonly Dictionary<Guid, Edge> Edges = new Dictionary<Guid, Edge>();
        
        private readonly Dictionary<Guid, Vertex> Vertices = new Dictionary<Guid, Vertex>();

        public readonly MapSettings MapSettings;

        public MapSupervisor(MapSettings mapSettings)
        {
            MapSettings = mapSettings;
        }

        public void Create()
        {
            var hexagon = MapSettings.CreateHexagon(new Coordinates { X = 0, Y = 0, Z = 0 });
            hexagon.Build(this);
        }
    }
}
