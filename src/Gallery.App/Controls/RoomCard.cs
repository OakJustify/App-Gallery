using System.ComponentModel;

namespace Gallery.App.Controls;

[ToolboxItem(false)]
public sealed class RoomCard : UserControl
{
    private readonly Label _roomLabel;
    private string _roomName = string.Empty;
    private bool _isSelected;

    public event EventHandler<string?>? Clicked;

    public RoomCard()
    {
        Size = new Size(200, 56);
        BackColor = Color.FromArgb(28, 28, 34);
        Cursor = Cursors.Hand;
        Margin = new Padding(8, 4, 8, 4);

        _roomLabel = new Label
        {
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.FromArgb(160, 155, 140),
            Font = new Font("Segoe UI", 9F, FontStyle.Regular),
            AutoEllipsis = true
        };

        Controls.Add(_roomLabel);

        Click += (s, e) => OnClicked();
        _roomLabel.Click += (s, e) => OnClicked();

        MouseEnter += (s, e) => UpdateAppearance();
        MouseLeave += (s, e) => UpdateAppearance();
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string? RoomName
    {
        get => string.IsNullOrEmpty(_roomName) ? null : _roomName;
        set
        {
            _roomName = value ?? string.Empty;
            _roomLabel.Text = string.IsNullOrEmpty(_roomName) ? "All Rooms" : _roomName;
            UpdateAppearance();
        }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            UpdateAppearance();
        }
    }

    private void UpdateAppearance()
    {
        if (_isSelected)
        {
            BackColor = Color.FromArgb(72, 68, 52);
            _roomLabel.ForeColor = Color.FromArgb(235, 230, 215);
            _roomLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
        else if (ClientRectangle.Contains(PointToClient(MousePosition)))
        {
            BackColor = Color.FromArgb(40, 38, 32);
            _roomLabel.ForeColor = Color.FromArgb(200, 195, 175);
            _roomLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }
        else
        {
            BackColor = Color.FromArgb(28, 28, 34);
            _roomLabel.ForeColor = Color.FromArgb(160, 155, 140);
            _roomLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }
    }

    private void OnClicked()
    {
        Clicked?.Invoke(this, RoomName);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        UpdateAppearance();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        UpdateAppearance();
    }
}
