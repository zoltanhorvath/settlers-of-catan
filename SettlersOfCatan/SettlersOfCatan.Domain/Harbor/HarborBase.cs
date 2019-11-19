using SettlersOfCatan.Domain.Enums;
using SettlersOfCatan.Domain.Map;

namespace SettlersOfCatan.Domain.Harbor
{
    public abstract class HarborBase
    {
        private protected Vertex _vertex;
        public abstract void Trade(ResourceType offer, ResourceType demand, int amount);

        public HarborBase(Vertex vertex)
        {
            _vertex = vertex;
        }
    }
}
