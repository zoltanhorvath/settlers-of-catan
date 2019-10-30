using SettlersOfCatan.Domain.Map;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using System.Linq;
using Newtonsoft.Json;

namespace SettlersOfCatan.Domain.Test
{
    [Binding]
    public class MapCreatorSteps
    {
        private IMapCreator _mapCreator;
        private SortedDictionary<Coordinates, Hexagon> _map;

        [Given(@"a BasicMapCreator")]
        public void GivenABasicMapCreator()
        {
            _mapCreator = new BasicMapCreator();
        }

        [When(@"I call Create\(\) on the BasicMapCreator")]
        public void WhenICallCreateOnTheBasicMapCreator()
        {
            _map = _mapCreator.Create();
        }

        [Then(@"the BasicMapCreator should return a SortedDictionary\(Coordinates, Hexagon\) sorted by coordinates in the following order")]
        public void ThenTheBasicMapCreatorShouldReturnASortedDictionaryCoordinatesHexagonSortedByCoordinatesInTheFollowingOrder(Table table)
        {
            var listOfcoordinates = table.CreateSet<Coordinates>().ToList();
            listOfcoordinates.Count.Should().Be(_map.Count);
            var i = 0;
            foreach (var kvp in _map)
            {
                var coordinates = kvp.Key;
                coordinates.Should().Equals(listOfcoordinates[i++]);
            }
            var json = JsonConvert.SerializeObject(_map, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

    }
}
