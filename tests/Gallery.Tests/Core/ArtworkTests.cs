using Gallery.Core.Models;

namespace Gallery.Tests.Core;

public class ArtworkTests
{
    [Fact]
    public void Caption_ReturnsTitleAndArtistWhenArtistPresent()
    {
        var artwork = new Artwork
        {
            Title = "The Starry Night",
            Artist = "Vincent van Gogh",
            Date = "1889"
        };

        Assert.Equal("The Starry Night — Vincent van Gogh, 1889", artwork.Caption);
    }

    [Fact]
    public void Caption_ReturnsTitleWhenArtistMissing()
    {
        var artwork = new Artwork
        {
            Title = "Unknown Work"
        };

        Assert.Equal("Unknown Work", artwork.Caption);
    }
}
