namespace AsyncDataLibrary.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class StorageFileAttribute : Attribute
{
    public string FileName { get; }

    public StorageFileAttribute(string fileName)
    {
        FileName = fileName;
    }
}
