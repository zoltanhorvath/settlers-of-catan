using System;
using System.Collections.Generic;
using System.Text;

namespace SettlersOfCatan.Domain.Map
{
    public class RMapCreator
    {
        private List<Coordinates> _coordinates = new List<Coordinates>();
        public MapSettings Create()
        {
            var hexagon = new Hexagon
            {
                Coordinates = new Coordinates { X = 0, Y = 0, Z = 0 }
            };
            var mapSettings = new MapSettings(-2, 2);
            mapSettings.Map.Add(hexagon.Coordinates, hexagon);
            hexagon.G(mapSettings);
            return mapSettings;
        }


    }
}
