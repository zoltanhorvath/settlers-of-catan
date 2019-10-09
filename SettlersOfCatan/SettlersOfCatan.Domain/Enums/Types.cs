using System;
using System.Linq;

namespace SettlersOfCatan.Domain.Enums
{
    public enum TerrainType
    {
        Hills,
        Pasture,
        Mountains,
        Fields,
        Forest,
        Desert
    }
    public enum ResourceType
    {
        Brick,
        Wool,
        Ore,
        Grain,
        Lumber,     
        Nothing
    }

    public static class TerrainExtension
    {
        public static ResourceType ProduceResource(this TerrainType terrainType)
        {
            var resourceValues = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>().ToList();
            return resourceValues[(int)terrainType];
        }
    }
}
