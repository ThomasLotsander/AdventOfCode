namespace Hub.Days;

public class Directory
{
    public int Index { get; set; }
    public string? Name { get; set; }
    public Directory? Parent { get; set; }

    public List<DirectoryFile>? Files { get; set; } = new List<DirectoryFile>();
    public List<Directory> Children { get; set; } = new List<Directory>();
}