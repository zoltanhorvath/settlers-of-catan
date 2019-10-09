using SettlersOfCatan.Domain.Enums;

namespace SettlersOfCatan.Domain
{
    public abstract class SettlementBase
    {
        abstract public int VictoryPoint { get; }
        
        public Player Owner { get; }

        private int _amount;

        public SettlementBase(Player owner, int amount)
        {
            Owner = owner;
            _amount = amount;
        }
        
        public void ProduceResource(TerrainType terrainType)
        {
            var resourceType = terrainType.ProduceResource();
            Owner.AddResource(resourceType, _amount);
        }
      
    }
}
