namespace dotnet.Services.FileService;

public interface IFileService
{
    Task<(string? file , string? error)> Upload(IFormFile file);
    Task<(List<string>? files , string? error)> Upload(IFormFile[] files);
    Task<(FileResult? data , string? erorr)> DownloadFile(string FileName);
}