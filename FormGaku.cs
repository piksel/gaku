using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaku
{
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.IO;
    using System.Drawing.Imaging;
    using System.Reflection;
    using global::Imgur.API.Models;
    using System.Net;

    public partial class FormGaku : Form
    {
        MoveMode moveMode = MoveMode.None;
        SizeMode sizeMode;

        Point moveOrigin;
        Rectangle rectOrigin;
        Point correction;

        ImageSettings imageSettings;

        double zoom = 1;

        int hysterisisCooldown = 0;

        bool localDelta = false;
        private readonly int WHEEL_DELTA = 120;

        string imageFile = "";

        IImage imgurlImage;
        private WebClient wcDownload;
        private string versionString;
        private string gakuTitle;
        private string downloadFilename;

        public FormGaku()
        {
            InitializeComponent();

            wcDownload = new WebClient();
            wcDownload.DownloadFileCompleted += wcDownload_DownloadFileCompleted;
            wcDownload.DownloadProgressChanged += wcDownload_DownloadProgressChanged;

            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                openImage(args[1]);
            }
            else
            {
                pbMain.SizeMode = PictureBoxSizeMode.Zoom;
                BackColor = Color.FromArgb(255, 255, 75, 168);
                pbMain.Dock = DockStyle.Fill;
                pbMain.BackColor = BackColor;
                lTitle.Visible = true;
                pbLogotype.Visible = true;
                imageSettings = ImageSettings.Default;
                bClose.Visible = true;
            }

            var v = Assembly.GetExecutingAssembly().GetName().Version;
            versionString = $"{v.Major}.{v.Minor}.{v.Revision}";
            gakuTitle = "Gaku v" + versionString;
            lTitle.Text = gakuTitle;
            gakuV100ToolStripMenuItem.Text = lTitle.Text;

            MouseWheel += global_MouseWheel;
            pbMain.MouseWheel += global_MouseWheel;
        }

        private void wcDownload_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbDownloading.Value = e.ProgressPercentage;
            var dlText = $"Downloading image, {e.BytesReceived} of {e.TotalBytesToReceive}";
            Text = $"{dlText} - {gakuTitle}";
            lDownloading.Text = dlText;
        }

        private void wcDownload_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pDownloading.Visible = false;
            openImage(downloadFilename);
        }

        private void openImage(string file)
        {
            imageFile = file;
            using (var ms = new MemoryStream())
            {
                var image = Image.FromFile(imageFile);
                image.Save(ms, image.RawFormat);
                ms.Seek(0, SeekOrigin.Begin);
                pbMain.Image = Image.FromStream(ms);
            }
            Text = Path.GetFileName(imageFile) + " - Gaku";

            lTitle.Visible = false;
            pbLogotype.Visible = false;
            bClose.Visible = false;
            BackColor = Color.Black;

            imageSettings = ImageSettings.ForFile(imageFile);
            pbMain.Location = imageSettings.ImageOffset;
            zoom = imageSettings.Zoom;
            updateZoom();
            updateBorderStyle();
            if (imageSettings.New)
            {
                if (imageSettings.DisplayMode == DisplayMode.AutoFit)
                {
                    imageSettings.FrameSize = getAutoSize();
                }
            }

            setSize(imageSettings.FrameSize);

            if (imageSettings.Position != Point.Empty)
            {
                StartPosition = FormStartPosition.Manual;
                Location = imageSettings.Position;
            }
            else
            {
                var wa = Screen.PrimaryScreen.WorkingArea;
                StartPosition = FormStartPosition.Manual;
                Location = new Point(
                    (wa.Width / 2) - (imageSettings.FrameSize.Width / 2) + wa.Location.X,
                    (wa.Height / 2) - (imageSettings.FrameSize.Height / 2) + wa.Location.Y
                );
            }

            updateDisplayMode();
            updateIcon();

        }

        private void updateIcon()
        {
            var th = pbMain.Image.GetThumbnailImage(32, 32, () => true, IntPtr.Zero);
            var bmp = new Bitmap(th);
            var hicon = bmp.GetHicon();
            Icon = Icon.FromHandle(hicon);
        }

        private Size getAutoSize()
        {
            int width = pbMain.Image.Width;
            int height = pbMain.Image.Height;

            var borderPadding = imageSettings.BorderStyle == BorderStyle.Custom ? imageSettings.BorderWidth * 2 : 0;

            int maxWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Width;

            if (width > height || height > maxHeight)
            {
                if (width > maxWidth)
                {
                    width = maxWidth;
                }
                double scale = ((double)width + borderPadding) / pbMain.Image.Width;
                height = (int)(scale * height);
            }
            else
            {
                if (height > maxHeight)
                {
                    height = maxHeight;
                }
                double scale = ((double)height + borderPadding) / pbMain.Image.Height;
                width = (int)(scale * width);
            }

            return new Size(width, height);
        }

        private void setSize(Size frameSize)
        {
            Width = frameSize.Width;
            Height = frameSize.Height;
        }

        private void updateZoom(int delta = 0)
        {
            var oldZoom = zoom;
            while (delta != 0)
            {
                if (delta > 0)
                {
                    zoom *= 1.1;
                    delta--;
                }
                else
                {
                    zoom *= 0.9;
                    delta++;
                }
            }
            if ((oldZoom > 1 && zoom < 1) ||
                (oldZoom < 1 && zoom > 1)
            )
            {
                zoom = 1;
                pbMain.SizeMode = PictureBoxSizeMode.Normal;
            }
            else
            {
                pbMain.SizeMode = PictureBoxSizeMode.Zoom;

            }
            label3.Text = zoom.ToString("F3");

            pbMain.Width = (int)(zoom * pbMain.Image.Width);
            pbMain.Height = (int)(zoom * pbMain.Image.Height);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = (int)(Win32.WindowStyle.WS_VISIBLE );
                //cp.ExStyle |= 0x80000 /* WS_EX_LAYERED */ | 0x20 /* WS_EX_TRANSPARENT */ | 0x80/* WS_EX_TOOLWINDOW */;
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setSize(imageSettings.FrameSize);
            //bClose.Text = "\uE8BB";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            ToggleDisplayMode();
        }

        private void ToggleDisplayMode()
        {
            imageSettings.DisplayMode = imageSettings.DisplayMode == 
                DisplayMode.AutoFit ? DisplayMode.PanMoveCrop : DisplayMode.AutoFit;
            updateDisplayMode();
        }

        private void updateDisplayMode()
        {
            if(imageSettings.DisplayMode == DisplayMode.AutoFit)
            {
                pbMain.Dock = DockStyle.Fill;
                pbMain.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pbMain.Dock = DockStyle.None;
                pbMain.SizeMode = PictureBoxSizeMode.AutoSize;

            }
        }


        void addKVItem(List<string> items, string key, object value)
        {
            if (value == null) return;
            addKVItem(items, key, value.ToString());
        }
        void addKVItem(List<string> items, string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            items.Add(key.PadRight(16) + ": " + value);
        }

        private void ToggleImageInformation()
        {
            if (!alImageInfo.Visible)
            {

                var items = new List<string>();


                var tf = TagLib.File.Create(imageFile);
                var image = tf as TagLib.Image.File;

                addKVItem(items, "File path", Path.GetDirectoryName(imageFile));
                addKVItem(items, "Filename", Path.GetFileName(imageFile));
                addKVItem(items, "Creator", image.ImageTag.Creator);
                addKVItem(items, "Comment", image.ImageTag.Comment);
                addKVItem(items, "Keywords", string.Join(" ", image.ImageTag.Keywords));
                addKVItem(items, "Rating", image.ImageTag.Rating);
                addKVItem(items, "DateTime", image.ImageTag.DateTime);
                addKVItem(items, "Orientation", image.ImageTag.Orientation);
                addKVItem(items, "Software", image.ImageTag.Software);
                addKVItem(items, "ExposureTime", image.ImageTag.ExposureTime);
                addKVItem(items, "FNumber", image.ImageTag.FNumber);
                addKVItem(items, "ISOSpeedRatings", image.ImageTag.ISOSpeedRatings);
                addKVItem(items, "FocalLength", image.ImageTag.FocalLength);
                addKVItem(items, "FocalLength35mm", image.ImageTag.FocalLengthIn35mmFilm);
                addKVItem(items, "Make", image.ImageTag.Make);
                addKVItem(items, "Model", image.ImageTag.Model);

                if (image.Properties != null)
                {
                    addKVItem(items, "Width", image.Properties.PhotoWidth);
                    addKVItem(items, "Height", image.Properties.PhotoHeight);
                    addKVItem(items, "Type", image.Properties.Description);
                }

                alImageInfo.Lines = items.ToArray();
            }
            alImageInfo.Visible = !alImageInfo.Visible;
            imageInformationToolStripMenuItem.Checked = alImageInfo.Visible;
        }

        private void updateBorderStyle()
        {
            var wlstyle = Win32.GetWindowLong(Handle, Win32.WindowLongFlags.GWL_STYLE);
            switch (imageSettings.BorderStyle)
            {
                case BorderStyle.Resizable:
                    wlstyle &= ~Win32.WindowStyle.WS_BORDER;
                    wlstyle |= Win32.WindowStyle.WS_SIZEBOX;
                    break;

                case BorderStyle.Thin:
                    wlstyle &= ~Win32.WindowStyle.WS_BORDER;
                    wlstyle |= Win32.WindowStyle.WS_SIZEBOX;
                    Win32.SetWindowLong(Handle, Win32.WindowLongFlags.GWL_STYLE, wlstyle);

                    wlstyle &= ~Win32.WindowStyle.WS_SIZEBOX;
                    wlstyle |= Win32.WindowStyle.WS_BORDER;
                    break;

                case BorderStyle.Custom:
                case BorderStyle.None:
                default:
                    wlstyle &= ~Win32.WindowStyle.WS_BORDER;
                    wlstyle &= ~Win32.WindowStyle.WS_SIZEBOX;
                    break;

            }
            Win32.SetWindowLong(Handle, Win32.WindowLongFlags.GWL_STYLE, wlstyle);

            var customBorder = imageSettings.BorderStyle == BorderStyle.Custom ? imageSettings.BorderWidth : 0;

            pBorder.Top = customBorder;
            pBorder.Left = customBorder;
            pBorder.Width = Width - (customBorder * 2);
            pBorder.Height = Height - (customBorder * 2);

            noneToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.None;
            thinToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.Thin;
            resizableToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.Resizable;
            customToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.Custom;
        }

        private void hideCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideCursorToolStripMenuItem.Checked)
                Cursor.Hide();
            else
                Cursor.Show();
        }

        private void openImagePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imageFile)) return;

            Process.Start("explorer", "/select, \"" + imageFile + "\"");
        }

        private async void uploadImageToImgurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imageFile)) return;

            imgurLoading.Show();
            try
            {

                using (var fs = new FileStream(imageFile, FileMode.Open))
                {
                    imgurlImage = await Imgur.Endpoint.UploadImageStreamAsync(fs);
                }

                imgurLoading.ImgurImage = imgurlImage;
                imgurLoading.Done = true;

            }
            catch (Exception x)
            {
                if(MessageBox.Show("Error uploading image to Imgur:\n" + x.Message, "Upload failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    uploadImageToImgurToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void global_DragEnter(object sender, DragEventArgs e)
        {
            var allowedFormats = new [] { DataFormats.FileDrop, DataFormats.Bitmap, DataFormatsEx.URL };

            if(e.Data.GetFormats(true).Any(f => allowedFormats.Contains(f)))
                e.Effect = DragDropEffects.Move;
        }

        private void global_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                var images = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (images.Length < 1) return;
                openImage(images[0]);
            }
            else if (e.Data.GetDataPresent(DataFormatsEx.URL))
            {
                var url = DataFormatsEx.GetDataString(e.Data, DataFormatsEx.URL);
                openImageUrl(url);
            }

            else if (e.Data.GetDataPresent(DataFormats.Bitmap, true))
            {
                var bitmap = e.Data.GetData(DataFormats.Bitmap, true) as Bitmap;
                var filename = GakuSettings.GetTempImageFilename();
                bitmap.Save(filename, bitmap.RawFormat);
                openImage(filename);
            }

            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void openImageUrl(string url)
        {
            downloadFilename = GakuSettings.GetTempImageFilename(Path.GetExtension(url));
            pDownloading.Visible = true;
            pbDownloading.Value = 0;
            wcDownload.DownloadFileAsync(new Uri(url), downloadFilename);
        }

 
        private void setBorderColor(Color newColor)
        {
            imageSettings.BorderColor = newColor;
            blackToolStripMenuItem.Checked = (newColor == Color.Black);
            whiteToolStripMenuItem.Checked = (newColor == Color.White);
            customColorToolStripMenuItem.Checked = (newColor != Color.Black && newColor != Color.White);
            updateBorderStyle();
        }

    }
}
