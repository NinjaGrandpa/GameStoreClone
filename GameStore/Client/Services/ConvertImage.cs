using GameStore.Client.Services.Interfaces;

namespace GameStore.Client.Services;

public class ConvertImage : IConvertImage
{
    public HttpClient _client { get; set; }

    public async Task<string> ConvertToSvg(byte[] imageData)
    {
        throw new NotImplementedException();
    }

    public async Task<string> ConvertToPng(byte[] imageData)
    {
        var imageSrc = Convert.ToBase64String(imageData);

        var imageUrl = $"data:image/png;base64,{imageSrc}";

        return imageUrl;
    }

    public async Task<string> ConvertToJpeg(byte[] imageData)
    {
        throw new NotImplementedException();
    }

    public async Task<byte[]> ConvertToBytes(string imageUrl)
    {
        var imageData = await _client.GetByteArrayAsync(imageUrl);

        return imageData;
    }
}