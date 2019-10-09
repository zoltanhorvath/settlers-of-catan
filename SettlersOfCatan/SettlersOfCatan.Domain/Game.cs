using SettlersOfCatan.Domain.DevelopmentCard;
using SettlersOfCatan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfCatan.Domain
{
    public class Game
    {
        public List<Player> Players { get; }
        public int NumberOfTurns { get; private set; }
        public Player WhoseTurnIsIt { get; }
        public Dictionary<ResourceType, int> AvailableResources { get; } = new Dictionary<ResourceType, int>();
        

        public List<DevelopmentCardType> DevelopmentCards { get; } = new List<DevelopmentCardType>();

        public Game(List<Player> players, Dictionary<ResourceType,int> availableResources, List<DevelopmentCardType> developmentCards)
        {
            Players = players;
            AvailableResources = availableResources;
            DevelopmentCards = developmentCards;
        }
        public Dictionary<DiceColor, int> RoleDice()
        {
            Random random = new Random();
            var roles = new Dictionary<DiceColor, int>()
            {
                {DiceColor.Red, random.Next(1,7) },
                {DiceColor.Yellow,random.Next(1,7) }
            };
            return roles;
        }     

    }
}
