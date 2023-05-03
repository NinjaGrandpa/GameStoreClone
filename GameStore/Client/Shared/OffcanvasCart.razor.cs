using System.Net.Http.Json;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Shared;

partial class OffcanvasCart : ComponentBase
{
    public CartDto Cart { get; set; }

    protected override async Task OnInitializedAsync()
    {
        
        await base.OnInitializedAsync();
    }

    public void Open()
    {

    }

    public void Close()
    {

    }
}