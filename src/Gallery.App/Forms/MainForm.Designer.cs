namespace Gallery.App.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private Panel HeaderPanel = null!;
    private Label ExhibitionTitleLabel = null!;
    private Label ExhibitionSubtitleLabel = null!;
    private Label CuratorLabel = null!;
    private Panel RoomCarouselContainer = null!;
    private FlowLayoutPanel RoomCarouselPanel = null!;
    private Panel ThumbnailContainerPanel = null!;
    private FlowLayoutPanel ThumbnailFlowPanel = null!;
    private Panel DetailPanel = null!;
    private Button BackToGalleryButton = null!;
    private PictureBox DetailPictureBox = null!;
    private Label DetailLoadingLabel = null!;
    private Label DetailTitleLabel = null!;
    private Label DetailArtistLabel = null!;
    private Label DetailMetaLabel = null!;
    private Label DetailRoomLabel = null!;
    private Label DetailCreditLabel = null!;
    private TextBox DetailDescriptionLabel = null!;
    private Label DetailCollectionLinkLabel = null!;
    private Label DetailInfoHeaderLabel = null!;

        private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        HeaderPanel = new Panel();
        ExhibitionTitleLabel = new Label();
        ExhibitionSubtitleLabel = new Label();
        CuratorLabel = new Label();
        RoomCarouselContainer = new Panel();
        RoomCarouselPanel = new FlowLayoutPanel();
        ThumbnailContainerPanel = new Panel();
        ThumbnailFlowPanel = new FlowLayoutPanel();
        DetailPanel = new Panel();
        BackToGalleryButton = new Button();
        DetailPictureBox = new PictureBox();
        DetailLoadingLabel = new Label();
        DetailInfoHeaderLabel = new Label();
        DetailTitleLabel = new Label();
        DetailArtistLabel = new Label();
        DetailMetaLabel = new Label();
        DetailRoomLabel = new Label();
        DetailCreditLabel = new Label();
        DetailDescriptionLabel = new TextBox();
        DetailCollectionLinkLabel = new Label();

        HeaderPanel.SuspendLayout();
        RoomCarouselContainer.SuspendLayout();
        RoomCarouselPanel.SuspendLayout();
        ThumbnailContainerPanel.SuspendLayout();
        ThumbnailFlowPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DetailPictureBox).BeginInit();
        DetailPanel.SuspendLayout();
        SuspendLayout();

        // HeaderPanel
        HeaderPanel.BackColor = Color.FromArgb(18, 18, 22);
        HeaderPanel.Controls.Add(ExhibitionTitleLabel);
        HeaderPanel.Controls.Add(ExhibitionSubtitleLabel);
        HeaderPanel.Controls.Add(CuratorLabel);
        HeaderPanel.Controls.Add(RoomCarouselContainer);
        HeaderPanel.Dock = DockStyle.Top;
        HeaderPanel.Location = new Point(0, 0);
        HeaderPanel.Name = "HeaderPanel";
        HeaderPanel.Padding = new Padding(32, 16, 32, 12);
        HeaderPanel.Size = new Size(1280, 150);
        HeaderPanel.TabIndex = 0;

        // ExhibitionTitleLabel
        ExhibitionTitleLabel.AutoSize = true;
        ExhibitionTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        ExhibitionTitleLabel.ForeColor = Color.FromArgb(235, 230, 215);
        ExhibitionTitleLabel.Location = new Point(32, 16);
        ExhibitionTitleLabel.Name = "ExhibitionTitleLabel";
        ExhibitionTitleLabel.Size = new Size(400, 41);
        ExhibitionTitleLabel.TabIndex = 0;
        ExhibitionTitleLabel.Text = "Loading...";

        // ExhibitionSubtitleLabel
        ExhibitionSubtitleLabel.AutoSize = true;
        ExhibitionSubtitleLabel.Font = new Font("Segoe UI", 9F);
        ExhibitionSubtitleLabel.ForeColor = Color.FromArgb(160, 155, 140);
        ExhibitionSubtitleLabel.Location = new Point(34, 58);
        ExhibitionSubtitleLabel.Name = "ExhibitionSubtitleLabel";
        ExhibitionSubtitleLabel.Size = new Size(200, 20);
        ExhibitionSubtitleLabel.TabIndex = 1;
        ExhibitionSubtitleLabel.Text = "";

        // CuratorLabel
        CuratorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        CuratorLabel.Font = new Font("Segoe UI", 9F);
        CuratorLabel.ForeColor = Color.FromArgb(160, 155, 140);
        CuratorLabel.Location = new Point(800, 24);
        CuratorLabel.Name = "CuratorLabel";
        CuratorLabel.Size = new Size(448, 20);
        CuratorLabel.TabIndex = 2;
        CuratorLabel.TextAlign = ContentAlignment.MiddleRight;
        CuratorLabel.Text = "";

        // RoomCarouselContainer
        RoomCarouselContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        RoomCarouselContainer.AutoScroll = true;
        RoomCarouselContainer.BackColor = Color.FromArgb(18, 18, 22);
        RoomCarouselContainer.Controls.Add(RoomCarouselPanel);
        RoomCarouselContainer.Location = new Point(32, 92);
        RoomCarouselContainer.Name = "RoomCarouselContainer";
        RoomCarouselContainer.Padding = new Padding(0, 4, 0, 4);
        RoomCarouselContainer.Size = new Size(1216, 68);
        RoomCarouselContainer.TabIndex = 3;
        RoomCarouselContainer.AutoScrollMargin = new Size(16, 0);

        // RoomCarouselPanel
        RoomCarouselPanel.AutoSize = true;
        RoomCarouselPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        RoomCarouselPanel.BackColor = Color.FromArgb(18, 18, 22);
        RoomCarouselPanel.Dock = DockStyle.Top;
        RoomCarouselPanel.FlowDirection = FlowDirection.LeftToRight;
        RoomCarouselPanel.Location = new Point(0, 4);
        RoomCarouselPanel.Name = "RoomCarouselPanel";
        RoomCarouselPanel.Padding = new Padding(0, 2, 0, 2);
        RoomCarouselPanel.Size = new Size(0, 60);
        RoomCarouselPanel.TabIndex = 0;
        RoomCarouselPanel.WrapContents = false;

        // ThumbnailContainerPanel
        ThumbnailContainerPanel.AutoScroll = true;
        ThumbnailContainerPanel.BackColor = Color.FromArgb(14, 14, 18);
        ThumbnailContainerPanel.Controls.Add(ThumbnailFlowPanel);
        ThumbnailContainerPanel.Dock = DockStyle.Fill;
        ThumbnailContainerPanel.Location = new Point(0, 150);
        ThumbnailContainerPanel.Name = "ThumbnailContainerPanel";
        ThumbnailContainerPanel.Padding = new Padding(24, 24, 24, 40);
        ThumbnailContainerPanel.Size = new Size(1280, 570);
        ThumbnailContainerPanel.TabIndex = 1;

        // ThumbnailFlowPanel
        ThumbnailFlowPanel.AutoSize = true;
        ThumbnailFlowPanel.BackColor = Color.FromArgb(14, 14, 18);
        ThumbnailFlowPanel.Dock = DockStyle.Top;
        ThumbnailFlowPanel.FlowDirection = FlowDirection.TopDown;
        ThumbnailFlowPanel.Location = new Point(24, 24);
        ThumbnailFlowPanel.Name = "ThumbnailFlowPanel";
        ThumbnailFlowPanel.Size = new Size(1232, 0);
        ThumbnailFlowPanel.TabIndex = 0;
        ThumbnailFlowPanel.WrapContents = false;

        // DetailPanel
        DetailPanel.BackColor = Color.FromArgb(12, 12, 16);
        DetailPanel.Controls.Add(BackToGalleryButton);
        DetailPanel.Controls.Add(DetailPictureBox);
        DetailPanel.Controls.Add(DetailLoadingLabel);
        DetailPanel.Controls.Add(DetailInfoHeaderLabel);
        DetailPanel.Controls.Add(DetailTitleLabel);
        DetailPanel.Controls.Add(DetailArtistLabel);
        DetailPanel.Controls.Add(DetailMetaLabel);
        DetailPanel.Controls.Add(DetailRoomLabel);
        DetailPanel.Controls.Add(DetailCreditLabel);
        DetailPanel.Controls.Add(DetailDescriptionLabel);
        DetailPanel.Controls.Add(DetailCollectionLinkLabel);
        DetailPanel.Dock = DockStyle.Fill;
        DetailPanel.Location = new Point(0, 150);
        DetailPanel.Name = "DetailPanel";
        DetailPanel.Padding = new Padding(32, 24, 32, 40);
        DetailPanel.Size = new Size(1280, 570);
        DetailPanel.TabIndex = 2;
        DetailPanel.Visible = false;

        // BackToGalleryButton
        BackToGalleryButton.BackColor = Color.FromArgb(32, 32, 38);
        BackToGalleryButton.FlatAppearance.BorderColor = Color.FromArgb(72, 68, 52);
        BackToGalleryButton.FlatStyle = FlatStyle.Flat;
        BackToGalleryButton.Font = new Font("Segoe UI", 9F);
        BackToGalleryButton.ForeColor = Color.FromArgb(235, 230, 215);
        BackToGalleryButton.Location = new Point(32, 24);
        BackToGalleryButton.Name = "BackToGalleryButton";
        BackToGalleryButton.Size = new Size(180, 36);
        BackToGalleryButton.TabIndex = 0;
        BackToGalleryButton.Text = "← Back to Gallery";
        BackToGalleryButton.UseVisualStyleBackColor = false;
        BackToGalleryButton.Click += BackToGalleryButton_Click;

        // DetailPictureBox
        DetailPictureBox.Location = new Point(32, 84);
        DetailPictureBox.Name = "DetailPictureBox";
        DetailPictureBox.Size = new Size(760, 480);
        DetailPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        DetailPictureBox.TabIndex = 1;
        DetailPictureBox.TabStop = false;

        // DetailLoadingLabel
        DetailLoadingLabel.AutoSize = true;
        DetailLoadingLabel.Font = new Font("Segoe UI", 9F);
        DetailLoadingLabel.ForeColor = Color.FromArgb(160, 155, 140);
        DetailLoadingLabel.Location = new Point(380, 310);
        DetailLoadingLabel.Name = "DetailLoadingLabel";
        DetailLoadingLabel.Size = new Size(72, 20);
        DetailLoadingLabel.TabIndex = 2;
        DetailLoadingLabel.Text = "Loading...";
        DetailLoadingLabel.TextAlign = ContentAlignment.MiddleCenter;

        // DetailInfoHeaderLabel
        DetailInfoHeaderLabel.AutoSize = true;
        DetailInfoHeaderLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        DetailInfoHeaderLabel.ForeColor = Color.FromArgb(200, 190, 160);
        DetailInfoHeaderLabel.Location = new Point(820, 84);
        DetailInfoHeaderLabel.Name = "DetailInfoHeaderLabel";
        DetailInfoHeaderLabel.Size = new Size(110, 23);
        DetailInfoHeaderLabel.TabIndex = 3;
        DetailInfoHeaderLabel.Text = "Exhibit Info";

        // DetailTitleLabel
        DetailTitleLabel.AutoSize = true;
        DetailTitleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        DetailTitleLabel.ForeColor = Color.FromArgb(235, 230, 215);
        DetailTitleLabel.Location = new Point(820, 120);
        DetailTitleLabel.MaximumSize = new Size(420, 0);
        DetailTitleLabel.Name = "DetailTitleLabel";
        DetailTitleLabel.Size = new Size(80, 32);
        DetailTitleLabel.TabIndex = 4;
        DetailTitleLabel.Text = "";

        // DetailArtistLabel
        DetailArtistLabel.AutoSize = true;
        DetailArtistLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
        DetailArtistLabel.ForeColor = Color.FromArgb(210, 200, 175);
        DetailArtistLabel.Location = new Point(820, 170);
        DetailArtistLabel.MaximumSize = new Size(420, 0);
        DetailArtistLabel.Name = "DetailArtistLabel";
        DetailArtistLabel.Size = new Size(60, 25);
        DetailArtistLabel.TabIndex = 5;
        DetailArtistLabel.Text = "";

        // DetailMetaLabel
        DetailMetaLabel.AutoSize = true;
        DetailMetaLabel.Font = new Font("Segoe UI", 9F);
        DetailMetaLabel.ForeColor = Color.FromArgb(160, 155, 140);
        DetailMetaLabel.Location = new Point(820, 210);
        DetailMetaLabel.MaximumSize = new Size(420, 0);
        DetailMetaLabel.Name = "DetailMetaLabel";
        DetailMetaLabel.Size = new Size(50, 20);
        DetailMetaLabel.TabIndex = 6;
        DetailMetaLabel.Text = "";

        // DetailRoomLabel
        DetailRoomLabel.AutoSize = true;
        DetailRoomLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        DetailRoomLabel.ForeColor = Color.FromArgb(160, 155, 140);
        DetailRoomLabel.Location = new Point(820, 240);
        DetailRoomLabel.Name = "DetailRoomLabel";
        DetailRoomLabel.Size = new Size(50, 20);
        DetailRoomLabel.TabIndex = 7;
        DetailRoomLabel.Text = "";

        // DetailCreditLabel
        DetailCreditLabel.AutoSize = true;
        DetailCreditLabel.Font = new Font("Segoe UI", 8F);
        DetailCreditLabel.ForeColor = Color.FromArgb(130, 125, 110);
        DetailCreditLabel.Location = new Point(820, 500);
        DetailCreditLabel.MaximumSize = new Size(420, 0);
        DetailCreditLabel.Name = "DetailCreditLabel";
        DetailCreditLabel.Size = new Size(50, 19);
        DetailCreditLabel.TabIndex = 8;
        DetailCreditLabel.Text = "";

        // DetailDescriptionLabel
        DetailDescriptionLabel.BackColor = Color.FromArgb(12, 12, 16);
        DetailDescriptionLabel.BorderStyle = BorderStyle.None;
        DetailDescriptionLabel.Font = new Font("Segoe UI", 9F);
        DetailDescriptionLabel.ForeColor = Color.FromArgb(210, 205, 190);
        DetailDescriptionLabel.Location = new Point(820, 280);
        DetailDescriptionLabel.Multiline = true;
        DetailDescriptionLabel.Name = "DetailDescriptionLabel";
        DetailDescriptionLabel.ReadOnly = true;
        DetailDescriptionLabel.ScrollBars = ScrollBars.Vertical;
        DetailDescriptionLabel.Size = new Size(420, 200);
        DetailDescriptionLabel.TabIndex = 9;
        DetailDescriptionLabel.Text = "";

        // DetailCollectionLinkLabel
        DetailCollectionLinkLabel.AutoSize = true;
        DetailCollectionLinkLabel.Cursor = Cursors.Hand;
        DetailCollectionLinkLabel.Font = new Font("Segoe UI", 8F, FontStyle.Underline);
        DetailCollectionLinkLabel.ForeColor = Color.FromArgb(190, 175, 130);
        DetailCollectionLinkLabel.Location = new Point(820, 540);
        DetailCollectionLinkLabel.Name = "DetailCollectionLinkLabel";
        DetailCollectionLinkLabel.Size = new Size(120, 19);
        DetailCollectionLinkLabel.TabIndex = 10;
        DetailCollectionLinkLabel.Text = "View on MetMuseum.org";
        DetailCollectionLinkLabel.Click += DetailCollectionLinkLabel_Click;

        // MainForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(14, 14, 18);
        ClientSize = new Size(1280, 720);
        Controls.Add(DetailPanel);
        Controls.Add(ThumbnailContainerPanel);
        Controls.Add(HeaderPanel);
        MinimumSize = new Size(1024, 640);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Museum Gallery Prototype";

        HeaderPanel.ResumeLayout(false);
        HeaderPanel.PerformLayout();
        RoomCarouselContainer.ResumeLayout(false);
        RoomCarouselPanel.ResumeLayout(false);
        ThumbnailContainerPanel.ResumeLayout(false);
        ThumbnailFlowPanel.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)DetailPictureBox).EndInit();
        DetailPanel.ResumeLayout(false);
        DetailPanel.PerformLayout();
        ResumeLayout(false);
    }
}
