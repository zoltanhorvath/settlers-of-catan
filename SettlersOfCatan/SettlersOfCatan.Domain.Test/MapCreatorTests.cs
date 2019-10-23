using Newtonsoft.Json;
using SettlersOfCatan.Domain.Map;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Xunit;
using Xunit.Abstractions;

namespace SettlersOfCatan.Domain.Test
{

    public class MapCreatorTests
    {
        private readonly ITestOutputHelper output;

        public MapCreatorTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        private readonly MapCreator MapCreator = new MapCreator();
        [Fact]
        public void TestCreate()
        {
            var map = MapCreator.BuildMap();
            foreach (var kvp in map)
            {
                output.WriteLine("X=  {0}, Y=  {1}, Z=  {2}", kvp.Key.X, kvp.Key.Y, kvp.Key.Z);
            }
        }
    }
}
