namespace AsyncDataLibrary.Infrastructure;

public sealed class FileStorageProvider
{
    public string RootDirectory { get; }

    public FileStorageProvider(string rootDirectory)
    {
        RootDirectory = rootDirectory;
        Directory.CreateDirectory(RootDirectory);
    }

    public string GetPath(string fileName)
    {
        return Path.Combine(RootDirectory, fileName);
    }
}
