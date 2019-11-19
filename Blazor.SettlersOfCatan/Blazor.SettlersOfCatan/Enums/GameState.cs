namespace Blazor.SettlersOfCatan.Enums
{
    public enum GameState
    {
        Unknown,
        WaitingForPlayers,
        Started
    }

    public static class GameStateExtensions
    {
        public static string AsString(this GameState gameState)
        {
            var asString = gameState switch
            {
                GameState.Unknown => "Unknown",
                GameState.WaitingForPlayers => "Waiting for other players to join",
                GameState.Started => "The game has been already started",
                _ => ""
            };

            return asString;
        }
    }
}