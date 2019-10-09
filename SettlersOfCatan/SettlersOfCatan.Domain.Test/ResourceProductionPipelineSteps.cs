using SettlersOfCatan.Domain.Enums;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using SettlersOfCatan.Domain.Builders;
using System.Collections.Generic;

namespace SettlersOfCatan.Domain.Test
{
    [Binding]
    public class ResourceProductionPipelineSteps
    {
        private Player _player;
        private SettlementBase _settlement;
        private TerrainType _terrainType;
        private PlayerBuilder _playerBuilder = new PlayerBuilder();

        [Given(@"a player")]
        public void GivenAPlayer(Table table)
        {
            var row = table.Rows[0];
            _playerBuilder.Name = row.GetString("Name");
            _playerBuilder.Color = row.GetEnumValue<PlayerColor>("Color");
         
        }

        [Given(@"without any resources")]
        public void GivenWithoutAnyResources()
        {
            _player = _playerBuilder.Build();
        }

        [Given(@"a village owner by the given player")]
        public void GivenAVillageOwnerByTheGivenPlayer()
        {
            _settlement = new Village(_player);
        }

        [Given(@"a terrainType")]
        public void GivenATerrainType(Table table)
        {
            _terrainType = table.Rows[0].GetEnumValue<TerrainType>("TerrainType");
        }

        [When(@"the ProduceResource method is being called with the given TerrainType on the village")]
        public void WhenTheProduceResourceMethodIsBeingCalledWithTheGivenTerrainTypeOnTheVillage()
        {
            _settlement.ProduceResource(_terrainType);
        }

        [Then(@"should be added to the player's resources\.")]
        public void ThenShouldBeAddedToThePlayerSResources_(Table table)
        {
            var row = table.Rows[0];
            var resourceType = row.GetEnumValue<ResourceType>("ResourceType");
            var expectedAmount = row.GetInt32("Amount");

            _player.Resources[resourceType].Should().Be(expectedAmount);
        }
     

        [Given(@"some resources")]
        public void GivenSomeResources(Table table)
        {
            var resources = table.CreateSet<KeyValuePair<ResourceType,int>>();
            _playerBuilder.Resources = new Dictionary<ResourceType, int>(resources);
            _player = _playerBuilder.Build();
        }

        [Then(@"the player should have the following resources")]
        public void ThenThePlayerShouldHaveTheFollowingResources(Table table)
        {
            ScenarioContext.Current.Pending();
        }
      

       

    }
}
