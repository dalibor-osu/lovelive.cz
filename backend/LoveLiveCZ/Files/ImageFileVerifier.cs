using LoveLiveCZ.Files.FileTypes;

namespace LoveLiveCZ.Files;

// Credits: https://khalidabuhakmeh.com/verify-user-file-uploads-with-dotnet
public class ImageFileVerifier : FileVerifier
{
    public ImageFileVerifier()
    {
        Types = new List<FileType>
        {
            new Jpeg(),
            new Png(),
            new Gif()
        };
    }
    
    public override bool Verify(IFormFile file)
    {
        using var ms = new MemoryStream();
        file.CopyTo(ms);
        return Types.Any(fileType => fileType.Verify(ms));
    }
}