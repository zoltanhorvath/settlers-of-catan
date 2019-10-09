using SettlersOfCatan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SettlersOfCatan.Domain
{
    public class City
    {
        public Dictionary<ResourceType, int> Price { get; } = new Dictionary<ResourceType, int>
        {
            {ResourceType.Grain,2 },
            {ResourceType.Ore,3 },
        };
    }
}
