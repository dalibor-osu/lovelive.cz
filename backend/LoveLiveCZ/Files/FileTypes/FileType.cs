namespace LoveLiveCZ.Files.FileTypes;

// Credits: https://khalidabuhakmeh.com/verify-user-file-uploads-with-dotnet
public abstract class FileType
{
    private readonly List<byte[]> _signatures;
    private int MaxSignatureLength => _signatures.Max(m => m.Length);

    protected FileType(List<byte[]> signatures)
    {
        _signatures = signatures;
    }

    public bool Verify(Stream stream)
    {
        stream.Position = 0;
        var reader = new BinaryReader(stream);
        var headerBytes = reader.ReadBytes(MaxSignatureLength);

        return _signatures.Exists(signature =>
            headerBytes.Take(signature.Length)
                .SequenceEqual(signature)
        );
    }
}