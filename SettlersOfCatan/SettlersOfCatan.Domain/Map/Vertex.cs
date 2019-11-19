using Newtonsoft.Json.Linq;
using SettlersOfCatan.Domain.Enums;

namespace SettlersOfCatan.Domain.Map
{
    public class Vertex : IdentifiableBase
    {
        public Edge[] Edges { get; } = new Edge[3];

        public TradingCapability TradingCapability { get; set; }

        public SettlementBase Settlement { get; set; }


        public JToken ToJToken()
        {
            var edgesJArray = new JArray();
            foreach (var edge in Edges)
            {
                if (edge != null)
                {
                    edgesJArray.Add(edge.Id);
                }
            }
            var jObject = new JObject
            {
                { nameof(Id),Id },
                { nameof(TradingCapability), TradingCapability.ToString() },
                { nameof(Edges),edgesJArray }
            };
            return jObject;
        }
    }
}
