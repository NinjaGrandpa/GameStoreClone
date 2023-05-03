using System.Net.Http.Json;
using GameStore.Shared.Cascade;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Pages.AdminTools.User
{
    partial class UserAdminPage : ComponentBase
    {
        public List<CustomerDto>? AllUsers { get; set; }

        [CascadingParameter]
        public CascadeValue? SelectedItem { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                AllUsers = await _client.client.GetFromJsonAsync<List<CustomerDto>>("/customer/all");
            }
            catch (Exception ex)
            {
                AllUsers = null;
            }

        }

        public void ChangeIdToSelectedUser(Guid id)
        {
            SelectedItem.Id = id;
        }
    }
}
