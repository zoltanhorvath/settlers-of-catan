
using System.Collections.Generic;
using Blazor.SettlersOfCatan.Enums;

namespace Blazor.SettlersOfCatan.Hubs
{
    public interface IGameHubServer
    {
        IEnumerable<PlayerColor> GetAvailableColors();

        GameState GetCurrentGameState();
    }
}
