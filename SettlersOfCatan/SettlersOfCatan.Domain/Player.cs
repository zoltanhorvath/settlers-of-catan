
using SettlersOfCatan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SettlersOfCatan.Domain
{
    public class Player
    {
        private Dictionary<ResourceType, int> _resources;

        public string Name { get; }

        public int VictoryPoints { get; }

        public PlayerColor Color { get; set; }

        public ImmutableDictionary<ResourceType, int> Resources { get { return _resources.ToImmutableDictionary(); } }


        public Player(string name, PlayerColor color, Dictionary<ResourceType, int> resources)
        {
            Name = name;
            Color = color;
            _resources = resources;
        }

        public void AddResource(ResourceType resourceType, int amount)
        {          
            _resources[resourceType] += amount;
        }

        private void InitResources()
        {
            var resourceTypes = Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>();
            foreach (var resourceType in resourceTypes)
            {
                _resources.Add(resourceType, 0);
            }
        }
    }
}
