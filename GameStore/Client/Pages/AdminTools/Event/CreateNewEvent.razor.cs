using System.Collections;
using System.Net.Http.Json;
using System.Text;
using Azure;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using GameStore.Shared.DataModels.BlobStorage;
using GameStore.Shared.DTO;
using GameStore.Shared.Services.Blobstorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace GameStore.Client.Pages.AdminTools.Event
{
    partial class CreateNewEvent : ComponentBase
    {

        private DateTime minDate = DateTime.UtcNow.AddHours(2);
        private EventDto _event = new EventDto();

        private string warninngMessage = "";
        private string displayMessage = "";
        private List<IBrowserFile> loadedFiles = new();
        private long maxFileSize = 1024 * 15;
        private int maxAllowedFiles = 3;
        private bool fileLoading;
        string Message = "No file(s) selected";
        IReadOnlyList<IBrowserFile> selectedFiles;
        private List<FileUploadViewModel> fileUploadViewModels = new();
        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();
            Message = $"{selectedFiles.Count} file(s) selected";
            this.StateHasChanged();
        }


        private async Task HandleSubmit()
        {

            fileLoading = true;
            foreach (var file in selectedFiles)
            {
                try
                {
                    var trustedFileNameForFileStorage = file.Name;
                    var blobUrl = await blobStorageService.UploadFileToBlobAsync(trustedFileNameForFileStorage, file.ContentType, file.OpenReadStream(20971520));
                    if (blobUrl != null)
                    {
                        FileUploadViewModel fileUploadViewModel = new FileUploadViewModel()
                        {
                            FileName = trustedFileNameForFileStorage,
                            FileStorageUrl = blobUrl,
                            ContentType = file.ContentType,
                        };

                        fileUploadViewModels.Add(fileUploadViewModel);
                        displayMessage = trustedFileNameForFileStorage + " Uploaded!!";

                        EventDto newEvent = new();
                        if (_event != null)
                        {
                            newEvent = new()
                            {
                                Id = Guid.NewGuid(),
                                EventName = _event.EventName,
                                Date = _event.Date,
                                Price = _event.Price,
                                MaxAvailableSeats = _event.MaxAvailableSeats,
                                ImageData = blobUrl,
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
                            var updateResponse = await _client.client.PostAsJsonAsync<EventDto>("/event", newEvent);
                            if(updateResponse.IsSuccessStatusCode)
                            {
                                _nm.NavigateTo("/admin/event");
                            }
                        }
                    }
                    else
                        warninngMessage = "File Upload failed, Please try again!!";

                }
                catch (Exception ex)
                {
                    warninngMessage = "File Upload failed, Please try again!!";
                }
            }

            fileLoading = false;
            this.StateHasChanged();




            
        }


    }
}
