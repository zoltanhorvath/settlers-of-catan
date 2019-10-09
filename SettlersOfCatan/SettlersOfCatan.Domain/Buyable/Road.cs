using SettlersOfCatan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SettlersOfCatan.Domain
{
    public class Road
    {
        public static Dictionary<ResourceType, int> Price { get; } = new Dictionary<ResourceType, int>
        {
            {ResourceType.Brick,1 },
            {ResourceType.Lumber,1 }
        };
    }
}
