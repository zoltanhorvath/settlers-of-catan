using SettlersOfCatan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SettlersOfCatan.Domain.Builders
{
    public class PlayerBuilder
    {
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public Dictionary<ResourceType,int> Resources { get; set; }

        public Player Build()
        {
            EnsureThatResourcesDictionaryContainsAllResourceType();
            return new Player(Name, Color, Resources);
        }

        private void EnsureThatResourcesDictionaryContainsAllResourceType()
        {
            if (Resources == null)
            {
                Resources = new Dictionary<ResourceType, int>();
            }

            var resourceTypes = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>();
            foreach (var resourceType in resourceTypes)
            {
                if (!Resources.ContainsKey(resourceType))
                {
                    Resources.Add(resourceType, 0);
                }
            }

        }
    }
}
