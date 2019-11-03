using Newtonsoft.Json;
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
            var mapSupervisor = new MapSupervisor( new MapSettings());
            var hexagon = new Hexagon { Coordinates = new Coordinates { X = 0, Y = 0, Z = 0 } };
            output.WriteLine(hexagon.ToString());
        }
    }
}
