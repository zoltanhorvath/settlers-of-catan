using Newtonsoft.Json;
using SettlersOfCatan.Domain.Map;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace SettlersOfCatan.Domain.Test
{
    public class RMapCreatorTest
    {
        private readonly ITestOutputHelper output;

        public RMapCreatorTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test()
        {
            var creator = new RMapCreator();
            var mapSettings = creator.Create();
            var json = JsonConvert.SerializeObject(mapSettings.Map, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
