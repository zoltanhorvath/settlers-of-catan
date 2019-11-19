using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.SettlersOfCatan.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace Blazor.SettlersOfCatan
{
    public class GameRendererBase : ComponentBase
    {
        protected HubConnection Connection;
        protected GameState GameState;
        protected List<string> Logs = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:51738/game")
                .WithAutomaticReconnect()
                .Build();
            await Connection.StartAsync();
            await GetCurrentGameStateAsync();
        }

        protected async Task GetCurrentGameStateAsync()
        {
            GameState = await Connection.InvokeAsync<GameState>("GetCurrentGameState");
            Logs.Add(GameState.AsString());
            StateHasChanged();
        }
    }
}
