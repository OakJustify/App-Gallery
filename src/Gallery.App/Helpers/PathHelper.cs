namespace Gallery.App.Helpers;

public static class PathHelper
{
    public static string GetAssetsDirectory()
    {
        var baseDir = AppContext.BaseDirectory;
        var assets = Path.Combine(baseDir, "Assets");
        if (Directory.Exists(assets))
            return assets;

        // Fallback for development
        var devPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "Assets"));
        return Directory.Exists(devPath) ? devPath : assets;
    }

    public static string GetImagesDirectory()
    {
        return Path.Combine(GetAssetsDirectory(), "images");
    }

    public static string GetDataDirectory()
    {
        return Path.Combine(GetAssetsDirectory(), "data");
    }
}
