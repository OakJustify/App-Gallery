# Architecture Documentation

## Overview

This project implements a modular museum-style gallery using Clean Architecture principles. Dependencies flow inward: `Gallery.App` depends on `Gallery.Data` and `Gallery.Imaging`, which depend on `Gallery.Core`. `Gallery.Core` has no dependencies on other project layers.

## Module Responsibilities

### Gallery.Core
- **Models**: `Artwork` (rich metadata), `Exhibition` (collection container). Pure POCOs with computed properties.
- **Abstractions**: Contracts for data access and image operations (`IArtworkRepository`, `IImageLoader`, `IThumbnailCache`). Enables testability and swappability.

### Gallery.Data
- **Repositories**: `JsonArtworkRepository` loads from JSON with fallback to embedded sample data. Manages exhibition lifecycle and room filtering.
- **Exhibitions**: `ImpressionistGallery` provides curated sample content with Met Museum metadata and credits.

### Gallery.Imaging
- **Services**: `ImageLoader` performs async image loading from disk with bicubic thumbnail generation.
- **Caching**: `ThumbnailCache` provides thread-safe in-memory caching with cloning to prevent disposal issues.

### Gallery.App
- **Forms**: `MainForm` orchestrates the gallery experience (browse → detail). Manages async loading and UI state.
- **Controls**: `ArtworkCard` is a reusable thumbnail card with click handling and hover effects.
- **Helpers**: `PathHelper` resolves asset paths for both deployed and development scenarios.

## Data Flow

1. **Startup**: `Program.Main()` creates `MainForm` with composed dependencies (cache, loader, repository).
2. **Load exhibition**: `MainForm_Load` calls `IArtworkRepository.LoadExhibitionAsync()`, populates header and room filter.
3. **Browse**: `LoadThumbnails()` creates `ArtworkCard` controls for filtered artworks and triggers async thumbnail loading.
4. **View details**: Card click shows `DetailPanel`, loads full-resolution image asynchronously.
5. **Navigate**: Back button returns to gallery grid.

## Design Patterns

- **Repository Pattern**: `IArtworkRepository` abstracts data source.
- **Strategy/Interface Segregation**: Small, focused interfaces.
- **Lazy Loading**: Thumbnails and full images loaded on demand.
- **Object Caching**: In-memory thumbnail cache reduces disk I/O.
- **MVVM-lite**: Forms act as presenters with minimal business logic.

## Extensibility

- **New data sources**: Implement `IArtworkRepository` (e.g., SQLite, API, folder scanner).
- **Image processing**: Extend `ImageLoader` for effects, EXIF, etc.
- **Themes**: Centralize colors/fonts or add theme support.
- **Slideshow/walkthrough**: Add kiosk mode or guided tour.
- **Multi-exhibition**: Extend `Exhibition` model.

## Testing Strategy

- Unit tests validate model behavior, repository fallbacks, cache operations, and contracts.
- UI tested manually on Windows/Wine as part of prototype validation.
- Integration points (file I/O) can be abstracted further for full isolation.

## Performance Considerations

- Thumbnails resized to ~600px max to balance quality and memory.
- Images cloned when cached/returned to prevent lifetime issues.
- UI uses double-buffering and async/await to avoid blocking.
- `FlowLayoutPanel` with `SuspendLayout/ResumeLayout` minimizes redraws.
