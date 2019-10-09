using System;
using System.Collections.Generic;
using System.Text;

namespace SettlersOfCatan.Domain
{
    public class Edge
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>(3);
    }
}
