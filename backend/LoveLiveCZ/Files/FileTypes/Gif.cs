namespace LoveLiveCZ.Files.FileTypes;

// Credits: https://khalidabuhakmeh.com/verify-user-file-uploads-with-dotnet
public sealed class Gif : FileType
{
    public Gif() : base(
        new List<byte[]>
        {
            "GIF"u8.ToArray()
        })
    {
    }
}