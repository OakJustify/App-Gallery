using System.Drawing;

namespace Gallery.Core.Abstractions;

public interface IImageLoader
{
    Task<Image> LoadFullImageAsync(string imagePath, CancellationToken cancellationToken = default);
    Task<Image> LoadThumbnailAsync(string imagePath, int maxSize, CancellationToken cancellationToken = default);
}
