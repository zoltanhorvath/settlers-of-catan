using SettlersOfCatan.Domain.Enums;
using System.Collections.Generic;

namespace SettlersOfCatan.Domain.DevelopmentCard
{
    public static class DevelopmentCard
    {
        public static Dictionary<ResourceType, int> Price { get; } = new Dictionary<ResourceType, int>
        {
            {ResourceType.Grain,1 },
            {ResourceType.Wool,1 },
            {ResourceType.Ore,1 }
        };
    }
    public enum DevelopmentCardType
    {
        Monopoly,
        RoadBuilding,
        YearOfPlenty,
        VictoryPoint,
        Knight
    }
}
