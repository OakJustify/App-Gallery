using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Gallery.Core.Abstractions;

namespace Gallery.Imaging.Services;

public sealed class ImageLoader : IImageLoader
{
    private readonly IThumbnailCache _cache;

    public ImageLoader(IThumbnailCache cache)
    {
        _cache = cache;
    }

    public async Task<Image> LoadFullImageAsync(string imagePath, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var img = Image.FromStream(stream);
            return (Image)img.Clone();
        }, cancellationToken);
    }

    public async Task<Image> LoadThumbnailAsync(string imagePath, int maxSize, CancellationToken cancellationToken = default)
    {
        var key = $"{imagePath}|{maxSize}";
        if (_cache.TryGet(key, out var cached) && cached is not null)
            return cached;

        return await Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var original = Image.FromStream(stream);

            var ratio = Math.Min((double)maxSize / original.Width, (double)maxSize / original.Height);
            var newWidth = Math.Max(1, (int)(original.Width * ratio));
            var newHeight = Math.Max(1, (int)(original.Height * ratio));

            var thumbnail = new Bitmap(newWidth, newHeight);
            using var graphics = Graphics.FromImage(thumbnail);
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            graphics.DrawImage(original, 0, 0, newWidth, newHeight);
            thumbnail.SetResolution(original.HorizontalResolution, original.VerticalResolution);

            _cache.Set(key, thumbnail);
            return (Image)thumbnail.Clone();
        }, cancellationToken);
    }
}
