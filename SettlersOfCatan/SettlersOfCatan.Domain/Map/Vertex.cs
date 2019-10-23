using SettlersOfCatan.Domain.Enums;

namespace SettlersOfCatan.Domain
{
    public class Vertex : IdentifiableBase
    {
        public Edge[] Edges { get; } = new Edge[3];

        public TradingCapabilityType TradingCapabilityType { get; set; }
        
        public SettlementBase Settlement { get; set; }
       
    }
}
