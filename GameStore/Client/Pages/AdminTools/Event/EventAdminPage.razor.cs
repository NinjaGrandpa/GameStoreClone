using System.Net.Http.Json;
using GameStore.Shared.Cascade;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Pages.AdminTools.Event;
partial class EventAdminPage : ComponentBase
{
    public List<EventDto>? AllEvents { get; set; }

    [CascadingParameter]
    public CascadeValue? SelectedItem { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            AllEvents = await _client.client.GetFromJsonAsync<List<EventDto>>("/event/all");
        }
        catch (Exception ex)
        {
            AllEvents = null;
        }

    }

    public void ChangeIdToSelectedEvent(Guid id)
    {
        SelectedItem.Id = id;
    }
}
