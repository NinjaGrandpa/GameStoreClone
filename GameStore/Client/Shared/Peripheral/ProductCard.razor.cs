using System.Net.Http.Json;
using GameStore.Shared.DataModels;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;

namespace GameStore.Client.Shared.Peripheral;

partial class ProductCard: ComponentBase
{
    [Parameter]
    public string ImageUrl { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public string Manufacturer { get; set; }

    [Parameter]
    public decimal Price { get; set; }

    [Parameter]
    public ProductDto Product { get; set; }

    [Parameter]
    public Action<ProductDto> OpenProductModal { get; set; }



    private void OnOpenProductModal()
    {
        Console.WriteLine("Buy button clicked");
        Console.WriteLine("Product: " + Product.ToString());


        OpenProductModal?.Invoke(Product);
    }



    private string TruncateTitle(string title, int maxLength = 15)
    {
        if (string.IsNullOrEmpty(title)) return string.Empty;
        return title.Length <= maxLength ? title : title.Substring(0, maxLength) + "...";
    }


}