namespace SettlersOfCatan.Domain
{
    public class Edge : IdentifiableBase
    {
        public Vertex[] Vertices { get; } = new Vertex[2];
        
        public Road Road { get; set; }
            
    }
}
