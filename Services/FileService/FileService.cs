using dotnet.Helper;
using Microsoft.AspNetCore.StaticFiles;
namespace dotnet.Services.FileService;

public class FileService : IFileService
{
    public async Task<(string? file , string? error)> Upload(IFormFile file) {
        var id = Guid.NewGuid();
        var extension = Path.GetExtension(file.FileName);
        var fileName = $"{id}{extension}";

        var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot", "Attachments");
        if (!File.Exists(attachmentsDir)) Directory.CreateDirectory(attachmentsDir);


        var path = Path.Combine(attachmentsDir, fileName);
        await using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
        var filePath = Path.Combine("Attachments", fileName);
        return (filePath , null);
    }
    public async Task<(List<string>? files , string? error)> Upload(IFormFile[] files)
    {
        var fileList = new List<string>();
        foreach (var file in files)
        { 
            var fileToAdd = await Upload(file);
            fileList.Add(fileToAdd.file!);
        }
        return (fileList , null);
    }
    
    
    public async Task<(FileResult? data , string? erorr)> DownloadFile(string fileName)
    {
        try
        {
            // fileName = "Attachments/29a61dc2-a1b5-4189-845b-74b696941b93.png" 
            var path = Common.GetFilePath(fileName);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                    var extension = Path.GetExtension(path);
                    contentType = GetContentType(extension);
                
            }
            if (!File.Exists(path))
            {
                return (null, "الملف غير موجود.");
            }
            var fileBytes = await File.ReadAllBytesAsync(path);
            var file = new FileResult()
            {
                FileBytes = fileBytes,
                FileName = Path.GetFileName(path),
                ContentType = contentType
            };
            return (file , null);
        }
        catch (Exception ex)
        {
            return (null, "حدث خطأ أثناء تنزيل الملف:");
        }
    }

    private string GetContentType(string extension)
    {
        return extension.ToLower() switch
        {
            ".pdf" => "application/pdf",
            ".jpg" => "image/jpeg",
            ".png" => "image/png",
            ".txt" => "text/plain",
            ".html" => "text/html",
            // Add more mappings as needed
            _ => "application/octet-stream" // Default MIME type for unknown files
        };
    }
}
