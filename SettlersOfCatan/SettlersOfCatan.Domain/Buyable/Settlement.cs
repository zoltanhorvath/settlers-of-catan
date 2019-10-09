using SettlersOfCatan.Domain.Enums;
using System.Collections.Generic;

namespace SettlersOfCatan.Domain
{
    public class Settlement
    {
        public static Dictionary<ResourceType, int> Price { get; } = new Dictionary<ResourceType, int>
        {
            {ResourceType.Brick,1 },
            {ResourceType.Grain,1 },
            {ResourceType.Lumber, 1},
            {ResourceType.Wool,1 }
        };
    }
}
