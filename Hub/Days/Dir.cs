namespace Hub.Days;

public class Dir
{
    public int Index { get; set; }
    public string? Name { get; set; }
    public Dir Parrent { get; set; }

    public List<DirectoryFile>? Files { get; set; } = new List<DirectoryFile>();
    public List<Dir> Directories { get; set; } = new List<Dir>();
}