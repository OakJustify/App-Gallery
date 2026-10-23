# Museum Gallery Prototype (Windows)

A modular Windows Forms prototype of a museum-style photo gallery, inspired by walking through exhibition rooms. It features room-based filtering, thumbnail browsing, and a clean detail view with artwork metadata and attribution to The Metropolitan Museum of Art Open Access collection.

## Demo

https://github.com/user-attachments/assets/ba5b42ad-0760-4052-91f7-d937e87abe72

A 67-second walkthrough (1280×720) showing room filtering, thumbnail browsing, and the artwork detail view. The player above streams a compressed copy of the demo; the full-quality recording is available at [`src/Gallery.DemoVideo/Demo_App-Gallery.mp4`](src/Gallery.DemoVideo/Demo_App-Gallery.mp4).

## Architecture (Modular)

This solution follows a layered, modular structure to keep concerns separated and easy to extend:

```
app-gallery/
├── src/
│   ├── Gallery.Core/      # Domain models & abstractions (IArtworkRepository, IImageLoader, IThumbnailCache)
│   ├── Gallery.Data/      # Data access (JSON/embedded exhibition, Met-inspired sample set)
│   ├── Gallery.Imaging/   # Image loading, resizing, in-memory thumbnail caching
│   ├── Gallery.App/       # WinForms UI (museum-inspired layout, controls, forms)
│   └── Gallery.DemoVideo/ # Demo walkthrough video (MP4)
├── tests/
│   └── Gallery.Tests/     # Unit tests (xUnit)
└── docs/
    └── ARCHITECTURE.md   # Detailed design notes
```

### Projects

| Project | Type | Purpose |
| --- | --- | --- |
| `Gallery.Core` | Class library | `Artwork`, `Exhibition`, and interfaces for repositories/loaders/caching. No UI or I/O dependencies. |
| `Gallery.Data` | Class library | `JsonArtworkRepository`, `ImpressionistGallery` sample exhibition. Loads from `Assets/data/exhibition.json` with fallback to embedded sample data. |
| `Gallery.Imaging` | Class library | `ImageLoader` (async full image + bicubic thumbnails) and `ThumbnailCache` (thread-safe in-memory cache). |
| `Gallery.App` | WinForms app | `MainForm` (gallery grid + detail view), `ArtworkCard` control, museum-inspired dark UI. |
| `Gallery.Tests` | xUnit tests | Unit tests for core/data/imaging contracts. |

## Features

- **Museum-style browsing**: Header with exhibition title/curator, room filter dropdown, and vertically scrolling gallery grid.
- **Room organization**: Artworks grouped by gallery rooms (The Boulevards, The Studio, The Countryside, Pointillism, Vienna Secession, Ukiyo-e, Dutch Golden Age).
- **Thumbnail system**: Lazy-loaded, resized thumbnails with in-memory caching for smooth scrolling.
- **Detail view**: Full image preview, title/artist/date/medium/dimensions, room, description, credit line, and direct link to the original MetMuseum.org page.
- **Public domain samples**: Includes 9 high-quality public domain works from The Metropolitan Museum of Art (all images and metadata obtained from Met Open Access).
- **Async loading**: Non-blocking image loading keeps the UI responsive.
- **Modular & testable**: Dependency injection-friendly interfaces, clear separation of concerns.

## Getting Started

### Prerequisites

- [Windows 10/11](https://www.microsoft.com/windows) with [.NET 10 SDK](https://dotnet.microsoft.com/download)
- (For development) [Visual Studio 2022](https://visualstudio.microsoft.com/) or [JetBrains Rider](https://www.jetbrains.com/rider/)

### Build & Run

From the solution root:

```bash
# Restore and build
dotnet build Gallery.sln -c Release

# Run the app
dotnet run --project src/Gallery.App/Gallery.App.csproj -c Release
```

Or publish a self-contained executable for Windows:

```bash
dotnet publish src/Gallery.App/Gallery.App.csproj -c Release -r win-x64 --self-contained true -p:EnableWindowsTargeting=true
```

The published app will be in `src/Gallery.App/bin/Release/net10.0-windows/win-x64/publish/`. Images are copied to `Assets/images/` automatically.

### Running Tests

```bash
dotnet test Gallery.sln -c Release
```

## Assets & Licensing

- **Artwork images**: Sourced from [The Metropolitan Museum of Art Open Access](https://www.metmuseum.org/art/collection) and are in the public domain. Credit lines are displayed in-app.
- **Application code**: This prototype is provided for educational/project purposes.
- **Sample data**: `src/Gallery.Data/Exhibitions/ImpressionistGallery.cs` contains curated metadata for the sample exhibition.
- **Demo video**: `src/Gallery.DemoVideo/Demo_App-Gallery.mp4` is a screen recording of the app; it contains no third-party footage.

## Customization

### Add Your Own Exhibition

1. Add images to `src/Gallery.App/Assets/images/` (JPEG recommended).
2. Edit `src/Gallery.Data/Exhibitions/ImpressionistGallery.cs` to add/remove artworks, or create a new repository implementation.
3. Optionally create `src/Gallery.App/Assets/data/exhibition.json` and use `JsonArtworkRepository` to load it.

### Extend the UI

- `Gallery.App/Controls/ArtworkCard.cs` — Customize thumbnail card appearance and behavior.
- `Gallery.App/Forms/MainForm.*` — Modify layout, add sorting/filtering, or implement slideshow/walkthrough mode.
- `Gallery.Imaging/` — Swap in different caching strategies or image processing.

## Design Notes

- **Museum aesthetic**: Dark gallery walls (`#0e0e12`), warm accent lighting feel, serif/clean UI typography, generous padding mimicking gallery spacing.
- **Performance**: Thumbnails are generated on-demand and cached; full images load only in detail view.
- **Offline-first**: All assets are local; no network required at runtime.

## Documentation

See [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) for detailed module responsibilities, data flow, and extension points.
