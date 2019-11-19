using System;
using System.Collections.Generic;
using System.Linq;
using Blazor.SettlersOfCatan.Enums;
using Blazor.SettlersOfCatan.Hubs;

namespace Blazor.SettlersOfCatan.Managers
{
    public class GameManager : IGameManager, IGameHubServer
    {
        private GameState _state = GameState.WaitingForPlayers;
        private Game _game;
        private Dictionary<string, Player> _userTolPlayerMapping = new Dictionary<string, Player>();

        public IEnumerable<PlayerColor> GetAvailableColors()
        {
            var listOfUnavailableColors = new List<PlayerColor>();
            foreach (var (connectionId, player) in _userTolPlayerMapping)
            {
                listOfUnavailableColors.Add(player.Color);
            }

            var listOfAllColors = Enum.GetValues(typeof(PlayerColor)).Cast<PlayerColor>();

            return listOfAllColors.Except(listOfUnavailableColors);
        }

        public GameState GetCurrentGameState()
        {
            return _state;
        }


    }
}
