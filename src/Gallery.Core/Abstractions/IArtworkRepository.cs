using Gallery.Core.Models;

namespace Gallery.Core.Abstractions;

public interface IArtworkRepository
{
    Task<Exhibition> LoadExhibitionAsync(CancellationToken cancellationToken = default);
    IEnumerable<Artwork> GetArtworks(string? room = null);
    IEnumerable<string> GetRooms();
}
