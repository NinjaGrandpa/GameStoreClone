using GameStore.Client.Shared;
using GameStore.Shared.Cascade;
using GameStore.Shared.DataModels.Products;
using GameStore.Shared.DTO;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Json;

namespace GameStore.Client.Pages.ProductPages
{
    partial class Peripheral : ComponentBase
    {

        private List<ProductDto> AllPeripherals;
        private List<ProductDto> filteredPeripheral;
        private List<string> ListOfManufacturers = new();
        private List<string> ListOfCategories= new();

        private List<string> manufacturer = new();
        private List<string> category = new();
        public double minValue;
        public double maxValue;

        private int AmountOfItemsToShowOnPage = 16;
        private int pageNumber = 0;
        private int pageMultiplier = 1;

        private bool IsClickedOn = true;
        private string? AddClassToBtn => IsClickedOn ? null : "AddColor";

        private List<string> SelectedManufacturers = new List<string>();
        private List<string> SelectedCats = new List<string>();


        private ModalDialog? ProductModal { get; set; }

        public ProductDto ProductInFocus { get; set; } = new ProductDto();

        [CascadingParameter]
        public CascadeValue SelectedItem { get; set; }

        public double MinValue
        {
            get => minValue;
            set
            {
                if (value > maxValue) maxValue = value;
                minValue = value;
                FilterPeripheral();
            }
        }
        public double MaxValue
        {
            get => maxValue;
            set
            {
                if (value < minValue) minValue = value;
                maxValue = value;
                FilterPeripheral();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            AllPeripherals = await client.client.GetFromJsonAsync<List<ProductDto>>("/Product/all");


            minValue = Convert.ToDouble(AllPeripherals.Min(p => p.UnitPrice));
            maxValue = Convert.ToDouble(AllPeripherals.Max(p => p.UnitPrice));
            FilterPeripheral();
            MakeAnArrayWithAllManufacturers();

            StateHasChanged();
            await base.OnInitializedAsync();
        }

        private async Task FilterPeripheral()
        {

            filteredPeripheral = AllPeripherals
                .Where(p => Convert.ToDouble(p.UnitPrice) >= MinValue && Convert.ToDouble(p.UnitPrice) <= MaxValue && (manufacturer.Count == 0 || manufacturer.Contains(p.Manufacturer)) && p.Name != null)
                .ToList();


            pageNumber = 0;
            pageMultiplier = 1;
            
            StateHasChanged();
        }


        private void ResetFilter()
        {
            minValue = Convert.ToDouble(AllPeripherals.Min(p => p.UnitPrice));
            maxValue = Convert.ToDouble(AllPeripherals.Max(p => p.UnitPrice));
            manufacturer.Clear();
            SelectedManufacturers.Clear(); // clear the list of selected manufacturers
            FilterPeripheral();
        }

        private void ChangeToPreviousPage()
        {
            pageNumber -= 1;
            pageMultiplier -= 1;

        }

        private void FilterManufacturer(string man)
        {
            if(manufacturer.Contains(man))
            {
                manufacturer.Remove(man);
            }
            else
            {

            manufacturer.Add(man);
            }
            FilterPeripheral();
        }

        private void filterCategory(string cat)
        {
            if (category.Contains(cat))
            {
                category.Remove(cat);
            }
            else
            {

                category.Add(cat);
            }
            FilterPeripheral();
        }

        private void MakeAnArrayWithAllManufacturers()
        {

            for (int i = 0; i < AllPeripherals.Count; i++)
            {
                if (!ListOfManufacturers.Contains(AllPeripherals[i].Manufacturer))
                {

                ListOfManufacturers.Add(AllPeripherals[i].Manufacturer);
                }
                for (int j = 0; j < AllPeripherals[i].SpecificationGroups.Count;j++)
                {

                if (!ListOfCategories.Contains(AllPeripherals[i].SpecificationGroups[j].Title) && (AllPeripherals[i].SpecificationGroups[j].Title.Contains("Hörlurar") || AllPeripherals[i].SpecificationGroups[j].Title.Contains("mus") || AllPeripherals[i].SpecificationGroups[j].Title.Contains("tangentbord")))
                    {

                        ListOfCategories.Add(AllPeripherals[i].SpecificationGroups[j].Title);
                }
                }
            }
        }

        private void ChangeToNextPage()
        {
            pageNumber += 1;
            pageMultiplier += 1;

        }

        public void FocusSelectedPeripheral(Guid id)
        {
            SelectedItem.Id = id;
        }

        private void ToggleClassOnBtn()
        {
            IsClickedOn = !IsClickedOn;
        }

        private void ToggleSelectedManufacturer(string manufacturer)
        {
            if (SelectedManufacturers.Contains(manufacturer))
            {
                SelectedManufacturers.Remove(manufacturer);
            }
            else
            {
                SelectedManufacturers.Add(manufacturer);
            }
        }

        private void ToggleSelectedCategories(string cat)
        {
            if (SelectedCats.Contains(cat))
            {
                SelectedCats.Remove(cat);
            }
            else
            {
                SelectedCats.Add(cat);
            }
        }

        public void OpenProductModal(ProductDto product)
        {
            Console.WriteLine($"Opening modal for product {product.Name}");
            ProductInFocus = product;
            if (ProductModal != null)
            {
                ProductModal.Open();
            }
            else
            {
                Console.WriteLine("ProductModal is null");
            }
        }
    }
}
