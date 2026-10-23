using Gallery.App.Controls;
using Gallery.App.Helpers;
using Gallery.Core.Abstractions;
using Gallery.Core.Models;
using Gallery.Data.Repositories;
using Gallery.Imaging.Caching;
using Gallery.Imaging.Services;
using System.Drawing.Drawing2D;

namespace Gallery.App.Forms;

public partial class MainForm : Form
{
    private readonly IArtworkRepository _repository;
    private readonly IImageLoader _imageLoader;
    private Exhibition? _exhibition;
    private string? _selectedRoom;
    private Artwork? _selectedArtwork;
    private RoomCard? _selectedRoomCard;
    private bool _isSwiping;
    private int _lastMouseX;
    private int _swipeVelocity;
    private System.Windows.Forms.Timer? _swipeTimer;

    public MainForm()
    {
        InitializeComponent();

        var cache = new ThumbnailCache();
        _imageLoader = new ImageLoader(cache);
        _repository = new JsonArtworkRepository();

        DoubleBuffered = true;
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

        Load += MainForm_Load;
        ThumbnailFlowPanel.SizeChanged += ThumbnailFlowPanel_SizeChanged;

        _swipeTimer = new System.Windows.Forms.Timer { Interval = 16 };
        _swipeTimer.Tick += SwipeTimer_Tick;

        RoomCarouselContainer.MouseDown += RoomCarouselContainer_MouseDown;
        RoomCarouselContainer.MouseMove += RoomCarouselContainer_MouseMove;
        RoomCarouselContainer.MouseUp += RoomCarouselContainer_MouseUp;
        RoomCarouselContainer.MouseLeave += RoomCarouselContainer_MouseLeave;
        RoomCarouselContainer.MouseWheel += RoomCarouselContainer_MouseWheel;
    }

    private async void MainForm_Load(object? sender, EventArgs e)
    {
        _exhibition = await _repository.LoadExhibitionAsync();
        Text = $"{_exhibition.Name} — Museum Gallery Prototype";

        ExhibitionTitleLabel.Text = _exhibition.Name;
        ExhibitionSubtitleLabel.Text = _exhibition.Subtitle;
        CuratorLabel.Text = $"Curated by {_exhibition.Curator}";

        BuildRoomCarousel();

        LoadThumbnails();
    }

    private void BuildRoomCarousel()
    {
        RoomCarouselPanel.SuspendLayout();
        foreach (Control control in RoomCarouselPanel.Controls)
        {
            if (control is RoomCard card)
                card.Dispose();
        }
        RoomCarouselPanel.Controls.Clear();

        var allCard = new RoomCard { RoomName = null, Margin = new Padding(4, 2, 4, 2) };
        allCard.Clicked += RoomCard_Clicked;
        RoomCarouselPanel.Controls.Add(allCard);
        _selectedRoomCard = allCard;
        allCard.IsSelected = true;

        foreach (var room in _repository.GetRooms())
        {
            var card = new RoomCard { RoomName = room, Margin = new Padding(4, 2, 4, 2) };
            card.Clicked += RoomCard_Clicked;
            RoomCarouselPanel.Controls.Add(card);
        }

        RoomCarouselPanel.ResumeLayout();
    }

    private void RoomCard_Clicked(object? sender, string? room)
    {
        if (_selectedRoomCard is not null)
            _selectedRoomCard.IsSelected = false;

        if (sender is RoomCard card)
        {
            card.IsSelected = true;
            _selectedRoomCard = card;
        }

        _selectedRoom = room;
        LoadThumbnails();
        SmoothScrollToCard(sender as Control);
    }

    private void SmoothScrollToCard(Control? card)
    {
        if (card is null || RoomCarouselContainer is null) return;

        var target = card.Left - (RoomCarouselContainer.ClientSize.Width / 2) + (card.Width / 2);
        target = Math.Max(0, Math.Min(target, RoomCarouselContainer.HorizontalScroll.Maximum));
        AnimateScroll(target);
    }

    private void AnimateScroll(int targetX)
    {
        if (_swipeTimer is null) return;
        _swipeVelocity = (int)((targetX - RoomCarouselContainer.HorizontalScroll.Value) * 0.25);
        if (Math.Abs(_swipeVelocity) < 2) _swipeVelocity = _swipeVelocity >= 0 ? 2 : -2;
        _swipeTimer.Tag = targetX;
        _swipeTimer.Start();
    }

    private void SwipeTimer_Tick(object? sender, EventArgs e)
    {
        if (_swipeTimer is null) return;
        int target = (int)(_swipeTimer.Tag ?? RoomCarouselContainer.HorizontalScroll.Value);
        int current = RoomCarouselContainer.HorizontalScroll.Value;
        int diff = target - current;

        if (Math.Abs(diff) <= 4)
        {
            RoomCarouselContainer.HorizontalScroll.Value = target;
            RoomCarouselContainer.PerformLayout();
            _swipeTimer.Stop();
            return;
        }

        int step = Math.Max(4, (int)(diff * 0.18));
        RoomCarouselContainer.HorizontalScroll.Value = Math.Max(0, Math.Min(target, current + step));
        RoomCarouselContainer.PerformLayout();
    }

    private void RoomCarouselContainer_MouseWheel(object? sender, MouseEventArgs e)
    {
        if (RoomCarouselContainer is null) return;
        int newVal = RoomCarouselContainer.HorizontalScroll.Value - (e.Delta / 2);
        newVal = Math.Max(0, Math.Min(newVal, RoomCarouselContainer.HorizontalScroll.Maximum));
        RoomCarouselContainer.HorizontalScroll.Value = newVal;
        RoomCarouselContainer.PerformLayout();
        ((HandledMouseEventArgs)e).Handled = true;
    }

    private void RoomCarouselContainer_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _isSwiping = true;
            _lastMouseX = e.X;
            _swipeVelocity = 0;
            _swipeTimer?.Stop();
            RoomCarouselContainer.Cursor = Cursors.SizeAll;
        }
    }

    private void RoomCarouselContainer_MouseMove(object? sender, MouseEventArgs e)
    {
        if (!_isSwiping) return;
        int delta = e.X - _lastMouseX;
        _lastMouseX = e.X;
        _swipeVelocity = delta * 3;
        int newVal = RoomCarouselContainer.HorizontalScroll.Value - delta;
        newVal = Math.Max(0, Math.Min(newVal, RoomCarouselContainer.HorizontalScroll.Maximum));
        RoomCarouselContainer.HorizontalScroll.Value = newVal;
        RoomCarouselContainer.PerformLayout();
    }

    private void RoomCarouselContainer_MouseUp(object? sender, MouseEventArgs e)
    {
        if (!_isSwiping) return;
        _isSwiping = false;
        RoomCarouselContainer.Cursor = Cursors.Default;

        if (Math.Abs(_swipeVelocity) > 20)
        {
            int target = RoomCarouselContainer.HorizontalScroll.Value - _swipeVelocity * 6;
            target = Math.Max(0, Math.Min(target, RoomCarouselContainer.HorizontalScroll.Maximum));
            _swipeVelocity = (int)((target - RoomCarouselContainer.HorizontalScroll.Value) * 0.2);
            if (Math.Abs(_swipeVelocity) < 3) _swipeVelocity = _swipeVelocity >= 0 ? 3 : -3;
            if (_swipeTimer is not null)
            {
                _swipeTimer.Tag = target;
                _swipeTimer.Start();
            }
        }
    }

    private void RoomCarouselContainer_MouseLeave(object? sender, EventArgs e)
    {
        if (_isSwiping)
        {
            _isSwiping = false;
            RoomCarouselContainer.Cursor = Cursors.Default;
        }
    }

    private void ThumbnailFlowPanel_SizeChanged(object? sender, EventArgs e)
    {
        foreach (Control control in ThumbnailFlowPanel.Controls)
        {
            if (control is ArtworkCard card)
                card.Width = ThumbnailFlowPanel.ClientSize.Width - 8;
        }
    }

    private void LoadThumbnails()
    {
        ThumbnailFlowPanel.SuspendLayout();
        foreach (Control control in ThumbnailFlowPanel.Controls)
        {
            if (control is ArtworkCard card)
            {
                card.ImageBox.Image?.Dispose();
                card.Dispose();
            }
        }
        ThumbnailFlowPanel.Controls.Clear();

        var artworks = _repository.GetArtworks(_selectedRoom);
        foreach (var artwork in artworks)
        {
            var card = new ArtworkCard
            {
                Artwork = artwork,
                Width = ThumbnailFlowPanel.ClientSize.Width - 8,
                Margin = new Padding(4, 4, 4, 12)
            };
            card.Clicked += Card_Clicked;
            ThumbnailFlowPanel.Controls.Add(card);
            _ = LoadCardThumbnailAsync(card, artwork);
        }

        ThumbnailFlowPanel.ResumeLayout();
    }

    private async Task LoadCardThumbnailAsync(ArtworkCard card, Artwork artwork)
    {
        try
        {
            var imagesDir = PathHelper.GetImagesDirectory();
            var imagePath = Path.Combine(imagesDir, artwork.ImageFileName);
            if (!File.Exists(imagePath))
                return;

            var thumbnail = await _imageLoader.LoadThumbnailAsync(imagePath, 600);
            if (!IsDisposed && card.IsHandleCreated)
            {
                Invoke(() =>
                {
                    if (card.IsDisposed) return;
                    card.ImageBox.Image = thumbnail;
                });
            }
            else
            {
                thumbnail.Dispose();
            }
        }
        catch
        {
            // Silently skip thumbnails that fail to load
        }
    }

    private void Card_Clicked(object? sender, Artwork artwork)
    {
        _selectedArtwork = artwork;
        ShowDetailView(artwork);
    }

    private void ShowDetailView(Artwork artwork)
    {
        ThumbnailFlowPanel.Visible = false;
        RoomCarouselContainer.Enabled = false;
        DetailPanel.Visible = true;

        DetailTitleLabel.Text = artwork.Title;
        DetailArtistLabel.Text = artwork.Artist;
        DetailMetaLabel.Text = $"{artwork.Date} • {artwork.Medium} • {artwork.Dimensions}";
        DetailRoomLabel.Text = artwork.Room;
        DetailCreditLabel.Text = artwork.CreditLine;
        DetailDescriptionLabel.Text = artwork.Description;
        DetailCollectionLinkLabel.Text = artwork.CollectionUrl;
        DetailCollectionLinkLabel.Tag = artwork.CollectionUrl;

        _ = LoadDetailImageAsync(artwork);
    }

    private async Task LoadDetailImageAsync(Artwork artwork)
    {
        DetailPictureBox.Image?.Dispose();
        DetailPictureBox.Image = null;
        DetailLoadingLabel.Visible = true;

        try
        {
            var imagesDir = PathHelper.GetImagesDirectory();
            var imagePath = Path.Combine(imagesDir, artwork.ImageFileName);
            if (!File.Exists(imagePath)) return;

            var image = await _imageLoader.LoadFullImageAsync(imagePath);
            if (!IsDisposed)
            {
                Invoke(() =>
                {
                    if (IsDisposed) return;
                    DetailPictureBox.Image = image;
                    DetailLoadingLabel.Visible = false;
                });
            }
            else
            {
                image.Dispose();
            }
        }
        catch
        {
            if (!IsDisposed)
                Invoke(() => DetailLoadingLabel.Text = "Unable to load image");
        }
    }

    private void BackToGalleryButton_Click(object? sender, EventArgs e)
    {
        DetailPictureBox.Image?.Dispose();
        DetailPictureBox.Image = null;
        DetailLoadingLabel.Visible = true;
        DetailLoadingLabel.Text = "Loading...";

        DetailPanel.Visible = false;
        RoomCarouselContainer.Enabled = true;
        ThumbnailFlowPanel.Visible = true;
    }

    private void DetailCollectionLinkLabel_Click(object? sender, EventArgs e)
    {
        if (DetailCollectionLinkLabel.Tag is string url && !string.IsNullOrWhiteSpace(url))
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _swipeTimer?.Stop();
            _swipeTimer?.Dispose();
            DetailPictureBox.Image?.Dispose();
            foreach (Control control in ThumbnailFlowPanel.Controls)
            {
                if (control is ArtworkCard card)
                    card.ImageBox.Image?.Dispose();
            }
            foreach (Control control in RoomCarouselPanel.Controls)
            {
                if (control is RoomCard rc)
                    rc.Dispose();
            }
        }
        base.Dispose(disposing);
    }
}
