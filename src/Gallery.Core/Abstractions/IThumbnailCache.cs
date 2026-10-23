using System.Drawing;

namespace Gallery.Core.Abstractions;

public interface IThumbnailCache
{
    bool TryGet(string key, out Image? image);
    void Set(string key, Image image);
    void Clear();
}
