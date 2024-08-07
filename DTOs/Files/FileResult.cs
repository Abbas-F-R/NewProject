namespace dotnet.DTOs.Files;

public class FileResult
{
    public byte[]? FileBytes { get; set; }
    public string? ContentType { get; set; }
    public string? FileName { get; set; }

}