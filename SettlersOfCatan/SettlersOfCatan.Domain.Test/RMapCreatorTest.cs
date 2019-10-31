using Newtonsoft.Json;
using SettlersOfCatan.Domain.Map;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SettlersOfCatan.Domain.Test
{
    public class RMapCreatorTest
    {
        [Fact]
        public void Test()
        {
            var creator = new RMapCreator();
            var hexagon = creator.Create();
            var json = JsonConvert.SerializeObject(hexagon, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Serialize, PreserveReferencesHandling = PreserveReferencesHandling.Objects });
        }
    }
}
