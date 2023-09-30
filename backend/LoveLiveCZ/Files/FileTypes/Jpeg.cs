namespace LoveLiveCZ.Files.FileTypes;

// Credits: https://khalidabuhakmeh.com/verify-user-file-uploads-with-dotnet
public sealed class Jpeg : FileType
{
    public Jpeg() : base(
        new List<byte[]>
        {
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
        })
    {
    }
}