namespace GameStore.Client.Services.Interfaces;

public interface IConvertImage
{
    Task<string> ConvertToSvg(byte[] imageData);
    Task<string> ConvertToPng(byte[] imageData);
    Task<string> ConvertToJpeg(byte[] imageData);
    Task<byte[]> ConvertToBytes(string imageUrl);
}