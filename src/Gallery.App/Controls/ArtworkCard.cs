using System.ComponentModel;
using Gallery.Core.Models;

namespace Gallery.App.Controls;

[ToolboxItem(false)]
public sealed class ArtworkCard : UserControl
{
    private readonly PictureBox _pictureBox;
    private readonly Label _titleLabel;
    private Artwork? _artwork;

    public event EventHandler<Artwork>? Clicked;

    public ArtworkCard()
    {
        Size = new Size(320, 360);
        BackColor = Color.FromArgb(24, 24, 28);
        BorderStyle = BorderStyle.None;
        Cursor = Cursors.Hand;
        Padding = new Padding(16);

        _pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.Zoom,
            BackColor = Color.FromArgb(16, 16, 20),
            Margin = new Padding(0, 0, 0, 72)
        };

        _titleLabel = new Label
        {
            Dock = DockStyle.Bottom,
            Height = 72,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.FromArgb(235, 230, 215),
            Font = new Font("Segoe UI", 9F, FontStyle.Regular),
            Padding = new Padding(12, 8, 12, 16)
        };

        Controls.Add(_pictureBox);
        Controls.Add(_titleLabel);

        _pictureBox.Click += (s, e) => OnClicked();
        _titleLabel.Click += (s, e) => OnClicked();
        Click += (s, e) => OnClicked();

        MouseEnter += (s, e) => BackColor = Color.FromArgb(36, 34, 28);
        MouseLeave += (s, e) => BackColor = Color.FromArgb(24, 24, 28);
    }

    [Browsable(false)]
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public Artwork? Artwork
    {
        get => _artwork;
        set
        {
            _artwork = value;
            if (value is null)
            {
                _titleLabel.Text = string.Empty;
                _pictureBox.Image?.Dispose();
                _pictureBox.Image = null;
                return;
            }

            _titleLabel.Text = value.Caption;
        }
    }

    public PictureBox ImageBox => _pictureBox;

    private void OnClicked()
    {
        if (_artwork is not null)
            Clicked?.Invoke(this, _artwork);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _pictureBox.Image?.Dispose();
        }
        base.Dispose(disposing);
    }
}
