using System.Text.Json;
using Gallery.Core.Abstractions;
using Gallery.Core.Models;
using Gallery.Data.Exhibitions;

namespace Gallery.Data.Repositories;

public sealed class JsonArtworkRepository : IArtworkRepository
{
    private readonly string _exhibitionPath;
    private Exhibition? _exhibition;

    public JsonArtworkRepository(string? exhibitionPath = null)
    {
        _exhibitionPath = exhibitionPath ?? Path.Combine(AppContext.BaseDirectory, "Assets", "data", "exhibition.json");
    }

    public async Task<Exhibition> LoadExhibitionAsync(CancellationToken cancellationToken = default)
    {
        if (_exhibition is not null)
            return _exhibition;

        if (File.Exists(_exhibitionPath))
        {
            await using var stream = File.OpenRead(_exhibitionPath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _exhibition = await JsonSerializer.DeserializeAsync<Exhibition>(stream, options, cancellationToken);
        }

        _exhibition ??= ImpressionistGallery.Create();
        return _exhibition;
    }

    public IEnumerable<Artwork> GetArtworks(string? room = null)
    {
        if (_exhibition is null)
            _ = LoadExhibitionAsync().GetAwaiter().GetResult();

        var items = _exhibition!.Artworks.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(room))
            items = items.Where(a => a.Room == room);
        return items;
    }

    public IEnumerable<string> GetRooms()
    {
        if (_exhibition is null)
            _ = LoadExhibitionAsync().GetAwaiter().GetResult();

        return _exhibition!.Artworks
            .Select(a => a.Room)
            .Where(r => !string.IsNullOrWhiteSpace(r))
            .Distinct()
            .OrderBy(r => r)
            .ToList();
    }
}
