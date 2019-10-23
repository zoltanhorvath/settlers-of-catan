using SettlersOfCatan.Domain.Enums;

namespace SettlersOfCatan.Domain
{
    public abstract class SettlementBase : IdentifiableBase
    {
        private int _resourceProductionMultiplier;

        public int VictoryPoint { get; }

        public Player Owner { get; }

        public SettlementBase(Player owner, int resourceProductionMultiplier, int victoryPoint)
        {
            Owner = owner;
            _resourceProductionMultiplier = resourceProductionMultiplier;
            VictoryPoint = victoryPoint;
        }

        public void ProduceResource(TerrainType terrainType)
        {
            var resourceType = terrainType.GetResourceType();
            Owner.AddResource(resourceType, _resourceProductionMultiplier);
        }

    }
}
