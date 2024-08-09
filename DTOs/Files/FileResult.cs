namespace dotnet.DTOs.Files;

public class FileResult
{
    public required byte[] FileBytes { get; set; }
    public required string ContentType { get; set; }
    public required string FileName { get; set; }

}