using System.Net.Http.Json;
using System.Text;
using GameStore.Client.Services;
using GameStore.Client.Shared;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace GameStore.Client.Pages.AdminTools;

partial class ProductAdminPage : ComponentBase
{

    private ModalDialog? ProductModal { get; set; }

    public IQueryable<ProductDto>? Products { get; set; }

    public ProductDto NewProduct { get; set; } = new ProductDto();

    public SpecificationGroupDto NewSpecificationGroup { get; set; } = new SpecificationGroupDto();
    public List<SpecificationGroupDto> SpecificationGroupList { get; set; } = new List<SpecificationGroupDto>();

    public SpecificationItemDto NewSpecificationItem { get; set; } = new SpecificationItemDto();
    public List<SpecificationItemDto> SpecificationItemList { get; set; } = new List<SpecificationItemDto>();

    protected override async Task OnInitializedAsync()
    {
        var results = await _client.client.GetFromJsonAsync<IEnumerable<ProductDto>>("/product/all");

        Products = results.AsQueryable();

        await base.OnInitializedAsync();
    }

    private async Task HandleSubmit()
    {
        NewSpecificationGroup.SpecificationItems.Add(NewSpecificationItem);
        
        NewProduct.SpecificationGroups.Add(NewSpecificationGroup);

        await _client.client.PostAsJsonAsync("/product/", NewProduct);
    }

    private bool _showDropdown = false;

    private string? ShowDropdown => _showDropdown ? "show" : null;


    private void ToggleDropdown()
    {
        _showDropdown = !_showDropdown;
    }

    private async Task HandleFocusOut()
    {
        await Task.Delay(200);
        _showDropdown = false;
    }

    void AddSpecGroupToList(MouseEventArgs e)
    {
        SpecificationGroupList.Add(NewSpecificationGroup);
        StateHasChanged();
    }

    void AddSpecItemToList()
    {
        SpecificationItemList.Add(NewSpecificationItem);
        NewSpecificationGroup.SpecificationItems.Add(NewSpecificationItem);
        NewSpecificationItem = new SpecificationItemDto();
        StateHasChanged();
    }
}
