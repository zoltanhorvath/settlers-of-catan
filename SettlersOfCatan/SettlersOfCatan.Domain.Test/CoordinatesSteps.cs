using FluentAssertions;
using SettlersOfCatan.Domain.Enums;
using SettlersOfCatan.Domain.Map;
using System;
using TechTalk.SpecFlow;

namespace SettlersOfCatan.Domain.Test
{
    [Binding]
    public class CoordinatesSteps
    {
        private Coordinates _givenCoordinates;
        private Direction _direction;

        [Given(@"I have '(.*)','(.*)', '(.*)' of a hexagon")]
        public void GivenIHaveOfAHexagon(int X, int Y, int Z)
        {

            _givenCoordinates = new Coordinates { X = X, Y = Y, Z = Z };

        }

        [When(@"I want to know the coordinates of the hexagon that lies (.*)")]
        public void WhenIWantToKnowTheCoordinatesOfTheHexagonThatLies(Direction direction)
        {
            _direction = direction;
        }

        [Then(@"the '(.*)','(.*)','(.*)' should be returned")]
        public void ThenTheShouldBeReturned(int X, int Y, int Z)
        {

            var expectedCoordinates = new Coordinates { X = X, Y = Y, Z = Z };
            var calculatedCoordinates = _direction.GetNeighbourCoordinates(_givenCoordinates);
            calculatedCoordinates.Should().Equals(expectedCoordinates);

        }

    }
}
