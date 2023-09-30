using LoveLiveCZ.Files.FileTypes;

namespace LoveLiveCZ.Files;

public abstract class FileVerifier
{
    protected IEnumerable<FileType> Types { get; set; }
    public abstract bool Verify(IFormFile file);
}