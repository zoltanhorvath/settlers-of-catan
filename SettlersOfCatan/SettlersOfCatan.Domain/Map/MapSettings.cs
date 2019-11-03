using System.Collections.Generic;
using SettlersOfCatan.Domain.Enums;
using SettlersOfCatan.Domain.Map;

namespace SettlersOfCatan.Domain
{
    public class MapSettings
    {
        public int MinimumCoordinateValue { get; } = -2;

        public int MaximumCoordinateValue { get; } = 2;

        private readonly Dictionary<TerrainType, int> numberOfDifferentTerrainTypes = new Dictionary<TerrainType, int>
        {
            { TerrainType.Desert, 1 },
            { TerrainType.Fields, 4 },
            { TerrainType.Forest, 4 },
            { TerrainType.Hills, 3 },
            { TerrainType.Mountains, 3 },
            { TerrainType.Pasture,4 }
        };

        private List<TerrainType> AvailableTerrainTypes = new List<TerrainType>();

        public MapSettings()
        {          
            FillUpAvailableTerrainTypes();
        }


        public Hexagon CreateHexagon(Coordinates coordinates)
        {
            return new Hexagon { Coordinates = coordinates, Terrain = AvailableTerrainTypes.Pop() };
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
    }
}