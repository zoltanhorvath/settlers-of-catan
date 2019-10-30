using System;
using System.Collections.Generic;
using System.Text;

namespace SettlersOfCatan.Domain.Map
{
    public interface IMapCreator
    {
        SortedDictionary<Coordinates, Hexagon> Create();
    }
}
