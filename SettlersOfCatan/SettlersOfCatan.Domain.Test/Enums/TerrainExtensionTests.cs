using SettlersOfCatan.Domain.Enums;
using Xunit;
using FluentAssertions;

namespace SettlersOfCatan.Domain.Test.Enums
{
    public class TerrainExtensionTests
    {
        [Theory]
        [InlineData(TerrainType.Hills, ResourceType.Brick)]
        [InlineData(TerrainType.Pasture, ResourceType.Wool)]
        [InlineData(TerrainType.Mountains, ResourceType.Ore)]
        [InlineData(TerrainType.Fields, ResourceType.Grain)]
        [InlineData(TerrainType.Forest, ResourceType.Lumber)]
        [InlineData(TerrainType.Desert, ResourceType.Nothing)]
        public void TerrainProductionTest(TerrainType terrainType, ResourceType expectedResourceType)
        {
            var resourceType = terrainType.GetResourceType();
            resourceType.Should().Be(expectedResourceType);
        }
    }
}
