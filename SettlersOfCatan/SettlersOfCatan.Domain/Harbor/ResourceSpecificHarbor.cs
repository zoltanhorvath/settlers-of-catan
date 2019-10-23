using SettlersOfCatan.Domain.Enums;
using System;

namespace SettlersOfCatan.Domain.Harbor
{
    public class ResourceSpecificHarbor : HarborBase
    {
        public ResourceType ResourceType { get;  }

     
        public ResourceSpecificHarbor(Vertex vertex, ResourceType resourceType): base(vertex)
        {
            ResourceType = resourceType;
        }

        public override void Trade(ResourceType offer, ResourceType demand, int amount)
        {
            
        }

    }
}
