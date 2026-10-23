using Gallery.Data.Repositories;

namespace Gallery.Tests.Data;

public class RepositoryTests
{
    [Fact]
    public async Task JsonArtworkRepository_LoadsSampleExhibition_WhenFileMissing()
    {
        var repo = new JsonArtworkRepository("/nonexistent/path/exhibition.json");
        var exhibition = await repo.LoadExhibitionAsync();

        Assert.False(string.IsNullOrWhiteSpace(exhibition.Name));
        Assert.True(exhibition.Artworks.Count > 0);
    }

    [Fact]
    public void GetRooms_ReturnsDistinctOrderedRooms()
    {
        var repo = new JsonArtworkRepository("/nonexistent/path/exhibition.json");
        var rooms = repo.GetRooms().ToList();

        Assert.True(rooms.Count > 0);
        Assert.Equal(rooms.OrderBy(r => r), rooms);
    }
}
