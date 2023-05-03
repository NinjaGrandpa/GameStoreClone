using System.Net.Http.Json;
using GameStore.Shared.Cascade;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Pages.AdminTools.Event
{
    partial class EditEvent : ComponentBase
    {
        EventDto _event = new();


        [CascadingParameter]
        public CascadeValue? SelectedEvent { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _event = await _client.client.GetFromJsonAsync<EventDto>("/event/" + SelectedEvent.Id);
            }
            catch
            {
                _event = null;
            }


            await base.OnInitializedAsync();
        }

        private async Task UpdateEvent()
        {
            EventDto newEvent = new();
            if (_event != null)
            {
                newEvent = new()
                {
                    Id = _event.Id,
                    EventName = _event.EventName,
                    Date = _event.Date,
                    Price = _event.Price,
                    MaxAvailableSeats = _event.MaxAvailableSeats,
                    ImageData = _event.ImageData,
                    Description = _event.Description,
                    AgeRecommendation = _event.AgeRecommendation,
                    Allergies = _event.Allergies,
                    Address = _event.Address,
                    PostalCode = _event.PostalCode,
                    City = _event.City
                };


            }
            if (newEvent != null)
            {
                try
                {
                    var response = await _client.client.PutAsJsonAsync<EventDto>("/event/", newEvent, CancellationToken.None);

                    if (response.IsSuccessStatusCode)
                    {
                        _navigationmanager.NavigateTo("/Se-Event");
                    }
                }
                catch (Exception ex)
                {

                }
            }

        }

        private async Task DeleteEvent()
        {
            try
            {
                var response = await _client.client.DeleteAsync($"/event/{SelectedEvent.Id}");

                if (response.IsSuccessStatusCode)
                {
                    _navigationmanager.NavigateTo("/Se-Event");
                }
                // Handle success
            }
            catch (Exception ex)
            {
                // Handle exception
            }
        }
    }
}
