using SettlersOfCatan.Domain.DevelopmentCard;
using SettlersOfCatan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace SettlersOfCatan.Domain
{
    public class Game : IdentifiableBase
    {
        public ImmutableList<Player> Players { get; }

        public int NumberOfTurns { get; private set; }

        public Player WhoseTurnIsIt { get; }

        public List<DevelopmentCardType> DevelopmentCards { get; }

        public Dictionary<PlayerColor, Dictionary<BuildableType, int>> BuildablePool { get; }

        public GamePhase GamePhase;

        public Game(List<Player> players, List<DevelopmentCardType> developmentCards, Dictionary<PlayerColor, Dictionary<BuildableType, int>> buildablePool)
        {
            Players = ImmutableList.CreateRange(players);
            DevelopmentCards = developmentCards;
            BuildablePool = buildablePool;
        }

        public Dictionary<DiceColor, int> RoleDice()
        {
            var random = new Random();
            var roles = new Dictionary<DiceColor, int>()
            {
                {DiceColor.Red, random.Next(1,7) },
                {DiceColor.Yellow,random.Next(1,7) }
            };
            return roles;
        }

    }
}
