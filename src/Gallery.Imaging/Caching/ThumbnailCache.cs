using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Gallery.Core.Abstractions;

namespace Gallery.Imaging.Caching;

public sealed class ThumbnailCache : IThumbnailCache
{
    private readonly Dictionary<string, Image> _cache = new();
    private readonly object _lock = new();

    public bool TryGet(string key, out Image? image)
    {
        lock (_lock)
        {
            if (_cache.TryGetValue(key, out var cached))
            {
                image = (Image)cached.Clone();
                return true;
            }
        }
        image = null;
        return false;
    }

    public void Set(string key, Image image)
    {
        lock (_lock)
        {
            if (_cache.ContainsKey(key))
                _cache[key].Dispose();
            _cache[key] = (Image)image.Clone();
        }
    }

    public void Clear()
    {
        lock (_lock)
        {
            foreach (var img in _cache.Values)
                img.Dispose();
            _cache.Clear();
        }
    }
}
