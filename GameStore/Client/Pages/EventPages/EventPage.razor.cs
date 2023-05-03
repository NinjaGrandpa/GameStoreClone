using System.Net.Http.Json;
using GameStore.Client.Shared;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Pages.EventPages;

partial class EventPage : ComponentBase
{

    public EventDto EventInFocus { get; set; } = new EventDto();

    public IQueryable<EventDto> AllEventsList { get; set; }

    private ModalDialog? EventModal { get; set; }
    public ModalDialog? ApplicationModal { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var result = await _client.client.GetFromJsonAsync<IEnumerable<EventDto>>("/event/all");

        AllEventsList = result.AsQueryable();

        await base.OnInitializedAsync();
    }

    private void SetEventInFocusAndOpenEventModal(EventDto theEvent)
    {
        EventInFocus = theEvent;
        EventModal.Open();
        ApplicationModal.Close();
    }

    private void SetEventInFocusAndOpenApplicationModal(EventDto theEvent)
    {
        EventInFocus = theEvent;
        ApplicationModal.Open();
        EventModal.Close();
    }
}
