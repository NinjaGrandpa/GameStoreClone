using System.Net.Http.Json;
using GameStore.Shared.Cascade;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Pages.AdminTools.Order
{
    partial class OrderAdminPage : ComponentBase
    {
        public List<EventOrderDto>? AllEventOrders { get; set; }

        [CascadingParameter]
        public CascadeValue? SelectedItem { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                AllEventOrders = await _client.client.GetFromJsonAsync<List<EventOrderDto>>("/eventOrder/all");
            }
            catch (Exception ex)
            {
                AllEventOrders = null;
            }

        }

        public void ChangeIdToSelectedOrder(Guid id)
        {
            if (SelectedItem is not null)
            {
                SelectedItem.Id = id;
            }
        }
    }
}
