namespace Gallery.Core.Models;

public sealed class Artwork
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Medium { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string CreditLine { get; set; } = string.Empty;
    public string CollectionUrl { get; set; } = string.Empty;
    public string ImageFileName { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsPublicDomain { get; set; } = true;

    public string Caption => string.IsNullOrWhiteSpace(Artist)
        ? Title
        : $"{Title} — {Artist}, {Date}";
}
