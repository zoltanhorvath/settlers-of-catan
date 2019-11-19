using System.Collections.Generic;
using Blazor.SettlersOfCatan.Enums;
using Blazor.SettlersOfCatan.Managers;
using Microsoft.AspNetCore.SignalR;

namespace Blazor.SettlersOfCatan.Hubs
{
    public class GameHub : Hub<IGameHub>
    {
        private readonly IGameManager _gameManager;


        public GameHub(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public IEnumerable<PlayerColor> GetAvailableColors()
        {
            return _gameManager.GetAvailableColors();
        }

        public GameState GetCurrentGameState()
        {
            return  _gameManager.GetCurrentGameState();
        }


    }
}
