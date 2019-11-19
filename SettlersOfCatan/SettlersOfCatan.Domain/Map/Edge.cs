using Newtonsoft.Json.Linq;

namespace SettlersOfCatan.Domain.Map
{
    public class Edge : IdentifiableBase
    {
        public Vertex[] Vertices { get; } = new Vertex[2];

        public Road Road { get; set; }

        public JToken ToJToken()
        {
            var edgeJObject = new JObject
            {
                { nameof(Id), Id }
            };

            var verticesJArray = new JArray();
            foreach (var vertex in Vertices)
            {
                verticesJArray.Add(vertex.Id);
            }
            edgeJObject.Add(nameof(Vertices), verticesJArray);

            return edgeJObject;
        }
    }
}
