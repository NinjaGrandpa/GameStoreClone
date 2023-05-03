using System.Net.Http.Json;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Pages.EventPages;

partial class EventApplicationForm : ComponentBase
{
    [Parameter]
    public EventDto CurrentEvent { get; set; }

    public CustomerDto CurrentCustomer { get; set; }
    public EventOrderDto CurrentEventOrder { get; set; } = new();

    private bool _hasAgreedToSaveCustomerInformation;
    private bool _isLoggedIn;
    private bool _showCheckboxAlert;

    protected override async Task OnInitializedAsync()
    {
        var existingCustomer = await GetCustomerFromUser();

        if (existingCustomer is null)
        {
            _isLoggedIn = false;
        }

        else
        {
            _isLoggedIn = true;
            CurrentCustomer = existingCustomer;
        }

        await base.OnInitializedAsync();
    }

    private async Task ApplyForEvent()
    {
        if (_hasAgreedToSaveCustomerInformation && !_isLoggedIn)
        {
            await CreateCustomerFromEventOrder();
            CurrentCustomer = await _client.client.GetFromJsonAsync<CustomerDto>("/customer/email/" + CurrentEventOrder.Email);
        }

        if (_hasAgreedToSaveCustomerInformation)
        {
            CurrentEventOrder.CustomerId = CurrentCustomer.Id;
            CurrentEventOrder.EventId = CurrentEvent.Id;

            var response = await _client.client.PostAsJsonAsync("/eventOrder/", CurrentEventOrder);

            var results = await response.Content.ReadFromJsonAsync<EventOrderDto>();

            CurrentEventOrder = results;

            await SendApplicationMail();
        }

        else
        {
            _showCheckboxAlert = true;
        }
    }

    private async Task<CustomerDto?> GetCustomerFromUser()
    {
        var userInfo = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userEmail = userInfo.User.Identity.Name;

        if (userEmail is null)
        {
            return null;
        }

        var existingCustomer = await _client.client.GetFromJsonAsync<CustomerDto>($"/customer/{userEmail}");

        return existingCustomer;
    }

    private async Task CreateCustomerFromEventOrder()
    {
        var newCustomer = new CustomerDto()
        {
            FirstName = CurrentEventOrder.FirstName,
            LastName = CurrentEventOrder.LastName,
            Email = CurrentEventOrder.Email,
            PhoneNumber = CurrentEventOrder.PhoneNumber
        };

        await _client.client.PostAsJsonAsync("/customer/", newCustomer);
    }

    public async Task SendApplicationMail()
    {
        var newApplication = new MailDTO()
        {
            EventOrderId = CurrentEventOrder.Id,
            Email = CurrentEventOrder.Email,
            FirstName = CurrentEventOrder.FirstName,
            EventName = CurrentEvent.EventName,
            Seats = CurrentEventOrder.AmountOfSeats,
            Date = CurrentEvent.Date,
            Adress = CurrentEvent.Address,
            PostalCode = CurrentEvent.PostalCode,
        };

        await _client.client.PostAsJsonAsync<MailDTO>("/mail/", newApplication);

    }
}
