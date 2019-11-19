using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SettlersOfCatan.Domain.Map;
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
            var mapSupervisor = new MapSupervisor(new MapSettings());
            mapSupervisor.Create();

            var jArray = new JArray();
            foreach (var keyValuePair in mapSupervisor.Map)
            {
                var hexagonJObject = new JObject
                {
                    {nameof(Hexagon), keyValuePair.Value.ToJToken() }
                };
                jArray.Add(hexagonJObject);

            }
            output.WriteLine(jArray.ToString());
        }
    }
}
