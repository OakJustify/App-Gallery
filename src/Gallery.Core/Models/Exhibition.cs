namespace Gallery.Core.Models;

public sealed class Exhibition
{
    public string Name { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string Curator { get; set; } = string.Empty;
    public List<Artwork> Artworks { get; set; } = new();
}
