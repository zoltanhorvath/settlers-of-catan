using SettlersOfCatan.Domain.Enums;

namespace SettlersOfCatan.Domain
{
    public class Hexagon : IdentifiableBase
    {
        public TerrainType Terrain { get; set; }
        
        public int Number { get; set; }

        public Vertex[] Vertices { get; } = new Vertex[6];
       
        public Edge[] Edges { get; } = new Edge[6];

        public Hexagon[] Neighbours { get; } = new Hexagon[6];

        public bool HasRobber { get; set; }  
         
        public void ProduceResource()
        {
            if (!HasRobber)
            {              
                foreach (var vertex in Vertices)
                {
                    vertex.Settlement.ProduceResource(Terrain);
                }
            }           
        }
    }
}
