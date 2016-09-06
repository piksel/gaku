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


        ImageSettings imageSettings;
        GeneralSettings settings;



        string imageFile = "";
        Image image;

        readonly Color GakuPink = Color.FromArgb(255, 75, 168);

        IImage imgurlImage;
        private WebClient wcDownload;
        private string versionString;
        private string gakuTitle;
        private string downloadFilename;
        private SizeHandler sizeHandler;
        private bool alphaForm;
        private int frameCount;
        private int animateSpeed = 1;
        private bool animateReverse = false;
        private bool animateEnabled = true;

        public FormGaku(bool alphaForm = false, string file = null)
        {
            InitializeComponent();

            this.alphaForm = alphaForm;

            wcDownload = new WebClient();
            wcDownload.DownloadFileCompleted += wcDownload_DownloadFileCompleted;
            wcDownload.DownloadProgressChanged += wcDownload_DownloadProgressChanged;

            settings = GeneralSettings.Load();

            sizeHandler = new SizeHandler(this, imageSettings, pbMain, settings);

            if (!string.IsNullOrEmpty(file))
            {
                openImage(file);
            }
            else
            {
                var args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    openImage(args[1]);
                }
                else
                {
                    pbMain.SizeMode = PictureBoxSizeMode.Zoom;
                    BackColor = GakuPink;
                    pbMain.Dock = DockStyle.Fill;
                    pbMain.BackColor = BackColor;
                    lTitle.Visible = true;
                    pbLogotype.Visible = true;
                    imageSettings = ImageSettings.Default;
                    sizeHandler.ImageSettings = imageSettings;
                    bClose.Visible = true;
                }
            }

            var v = Assembly.GetExecutingAssembly().GetName().Version;
            versionString = $"{v.Major}.{v.Minor}.{v.Revision}";
            gakuTitle = "Gaku v" + versionString;
            lTitle.Text = gakuTitle;
            gakuV100ToolStripMenuItem.Text = lTitle.Text;

            MouseWheel += global_MouseWheel;
            pbMain.MouseWheel += global_MouseWheel;
            pBorder.MouseWheel += global_MouseWheel;
            alHelp.MouseWheel += global_MouseWheel;
            alImageInfo.MouseWheel += global_MouseWheel;

            KeyDown += global_KeyDown;

            if (settings.FirstStart)
            {
                settings.FirstStart = false;
                settings.Save();
                ToggleHelp(true);
            }

            alHelp.FastTextDraw = settings.FastTextDraw;
            alImageInfo.FastTextDraw = settings.FastTextDraw;

            updateSettingsMenu();

            if(alphaForm)
            {
                var bmp = new Bitmap(pbMain.Image);
                SetBitmap(bmp, 255);
                sizeHandler.Resized += SizeHandler_Resized;
            }

            alphaFormToolStripMenuItem.Checked = alphaForm;
            //pbMain.Visible = false;
        }

        private void global_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right:
                    openImage(1); break;
                case Keys.Left:
                    openImage(-1); break;
                case Keys.Escape:
                    Close(); break;
                case Keys.Space:
                    animateEnabled = !animateEnabled;
                    updateAnimation();
                    break;
                case Keys.R:
                    animateReverse = !animateReverse;
                    updateAnimation();
                    break;
                case Keys.Add:
                    animateSpeed += 1;
                    updateAnimation();
                    break;
                case Keys.Subtract:
                    animateSpeed -= 1;
                    updateAnimation();
                    break;

                case Keys.M:
                    pbMain.Invalidate(); break;
            }
        }

        private void openImage(int offset)
        {
            var validExtensions = new string[] { ".jpg", ".jpeg", ".bmp", ".png", ".gif" };

            var filesInDirectory = new List<string>();

            var fp = Path.GetDirectoryName(imageFile);
            foreach(var file in Directory.EnumerateFiles(fp, "*", SearchOption.TopDirectoryOnly)) {
                if (validExtensions.Contains(Path.GetExtension(file)))
                    filesInDirectory.Add(file);
            }

            if (filesInDirectory.Contains(imageFile))
            {
                var index = (filesInDirectory.IndexOf(imageFile) + offset) % filesInDirectory.Count;
                openImage(filesInDirectory[index]);

            }
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
            //using (var ms = new MemoryStream())
            //{
                image = Image.FromFile(imageFile);
                //image.Save(ms, image.RawFormat);
                //ms.Seek(0, SeekOrigin.Begin);
                pbMain.Image = image;// Image.FromStream(ms);
            //}
            Text = Path.GetFileName(imageFile) + " - Gaku";

            lTitle.Visible = false;
            pbLogotype.Visible = false;
            bClose.Visible = false;
            BackColor = Color.Black;
            pbMain.BackColor = Color.Black;

            imageSettings = ImageSettings.ForFile(imageFile);
            sizeHandler.ImageSettings = imageSettings;
            pbMain.Location = imageSettings.ImageOffset;

            sizeHandler.UpdateZoom(initial: true);
            updateBorderStyle();
            if (imageSettings.New)
            {
                imageSettings.FrameSize = getAutoSize();
            }

            if (imageSettings.DisplayMode != DisplayMode.AutoFit)
            {
                pbMain.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pbMain.SizeMode = PictureBoxSizeMode.AutoSize;
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

            alImageInfo.Visible = false; imageInformationToolStripMenuItem.Checked = false;

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
            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;

            if (height < maxHeight && (width >= height || height > maxHeight))
            {
                if (width > maxWidth)
                {
                    width = maxWidth;
                }
                double scale = ((double)width + borderPadding) / pbMain.Image.PhysicalDimension.Width;
                height = (int)Math.Round(scale * height);
            }
            else
            {
                if (height > maxHeight)
                {
                    height = maxHeight;
                }
                double scale = ((double)height + borderPadding) / pbMain.Image.PhysicalDimension.Height;
                width = (int)Math.Round(scale * width);
            }

            return new Size(width, height);
        }

        private void setSize(Size frameSize)
        {
            Width = frameSize.Width;
            Height = frameSize.Height;
        }

       

        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams cp = base.CreateParams;
                if (alphaForm)
                {
                    cp.ExStyle |= 0x00080000; // This form has to have the WS_EX_LAYERED extended style
                }
                else
                {
                    cp.Style = (int)(Win32.WindowStyle.WS_VISIBLE);
                }
                //cp.Style = (int)(Win32.WindowStyle.WS_VISIBLE);
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

        private void global_DoubleClick(object sender, EventArgs e)
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
            if (imageSettings.DisplayMode == DisplayMode.AutoFit)
            {
                pbMain.Dock = DockStyle.Fill;
                pbMain.SizeMode = PictureBoxSizeMode.Zoom; //pbMain.Image.Width == pbMain.Image.Height ? PictureBoxSizeMode.StretchImage : PictureBoxSizeMode.AutoSize;
            }
            else
            {
                pbMain.Dock = DockStyle.None;
                pbMain.SizeMode = PictureBoxSizeMode.AutoSize;

            }

            sizeHandler.ConstrainCanvas();
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

            alHelp.Visible = false; helpToolStripMenuItem.Checked = false;
        }

        private void updateBorderStyle()
        {
            if(alphaForm) return;

            var wlstyle = Win32.GetWindowLong(Handle, Win32.WindowLongFlags.GWL_STYLE);
            var wlexstyle = Win32.GetWindowLong(Handle, Win32.WindowLongFlags.GWL_EXSTYLE);
            switch (imageSettings.BorderStyle)
            {
                case BorderStyle.Resizable:
                    wlstyle &= ~Win32.WindowStyle.WS_BORDER;
                    wlstyle |= Win32.WindowStyle.WS_SIZEBOX;
                    break;

                case BorderStyle.Toolbox:
                    wlstyle |= Win32.WindowStyle.WS_OVERLAPPEDWINDOW | Win32.WindowStyle.WS_BORDER;
                    wlexstyle |= Win32.WindowStyle.WS_EX_TOOLWINDOW;
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
            Win32.SetWindowLong(Handle, Win32.WindowLongFlags.GWL_EXSTYLE, wlexstyle);


            pBorder.Top = imageSettings.Padding;
            pBorder.Left = imageSettings.Padding;
            pBorder.Width = Width - (imageSettings.Padding * 2);
            pBorder.Height = Height - (imageSettings.Padding * 2);

            noneToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.None;
            thinToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.Thin;
            resizableToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.Resizable;
            customToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.Custom;
            toolboxToolStripMenuItem.Checked = imageSettings.BorderStyle == BorderStyle.Toolbox;

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
                if (MessageBox.Show("Error uploading image to Imgur:\n" + x.Message, "Upload failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    uploadImageToImgurToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void global_DragEnter(object sender, DragEventArgs e)
        {
            var allowedFormats = new[] { DataFormats.FileDrop, DataFormats.Bitmap, DataFormatsEx.URL };

            if (e.Data.GetFormats(true).Any(f => allowedFormats.Contains(f)))
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

        private void gakuV100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://p1k.se/gaku");
        }


        private void fileAssosciationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ffa = new FormFileAssociations();
            ffa.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleHelp();
        }

        private void ToggleHelp(bool? newState = null)
        {
            if(!newState.HasValue)
                newState = !alHelp.Visible;

            helpToolStripMenuItem.Checked = newState.Value;
            if (string.IsNullOrEmpty(imageFile))
            {
                alHelp.BackColor = Color.Black;

                alHelp.Top = 38;
                alHelp.Height = Height - 50;
                //alHelp.BackColor = GakuPink;
                alHelp.Alpha = 200;
                alHelp.HightlightColor = GakuPink;
                //alHelp.ForeColor = Color.HotPink;
                //alHelp.ShadowColor = GakuPink;
                //pbMain.Visible = !alHelp.Visible;
                //BackColor = alHelp.Visible ? Color.Black : GakuPink;
                pbLogotype.Visible = (!settings.FastTextDraw && newState.Value);
            }
            else
            {
                alHelp.Top = 12;
                alHelp.Height = Height - 24;
                alHelp.Alpha = 180;
                alHelp.BackColor = Color.Black;
                alHelp.HightlightColor = Color.HotPink;
                alHelp.ForeColor = Color.White;
            }

            alHelp.Visible = newState.Value;
            alImageInfo.Visible = false; imageInformationToolStripMenuItem.Checked = false;
        }

        private void global_MouseDown(object sender, MouseEventArgs e) { sizeHandler.HandleMouseDown(sender, e); }
        private void global_MouseWheel(object sender, MouseEventArgs e) { sizeHandler.HandleMouseWheel(sender, e); }
        private void global_MouseMove(object sender, MouseEventArgs e) { sizeHandler.HandleMouseMove(sender, e); }
        private void global_MouseUp(object sender, MouseEventArgs e) { sizeHandler.HandleMouseUp(sender, e); }

        private void keepAspectRatioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.KeepAspectRatio = !settings.KeepAspectRatio;
            updateSettingsMenu();
        }

        private void updateSettingsMenu()
        {
            keepAspectRatioToolStripMenuItem.Checked = settings.KeepAspectRatio;
            fastTextDrawingToolStripMenuItem.Checked = settings.FastTextDraw;
        }

        private void fastTextDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.FastTextDraw = !settings.FastTextDraw;
            updateSettingsMenu();
        }

        private void resetImageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageSettings = ImageSettings.Default;
            imageSettings.Save();
            openImage(imageFile);
        }

       

        private void alphaFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // HACK: This is terrible!
            // Every toggle of this option will spawn a new form that will wait until the child form has beeen closed
            // Closing one form will escalate all the way to the top and this will cause the program to exit normally -NM 2016-09-06
            Hide();

            // Save current settings
            imageSettings.Save();
            settings.Save();

            var af = new FormGaku(!alphaForm, imageFile);
            af.ShowDialog();

            // Reload settings that may have been changed by the child form
            imageSettings = ImageSettings.ForFile(imageFile);
            settings = GeneralSettings.Load();
            Close();
        }

        public void SetBitmap(Bitmap bitmap, byte opacity)
        {
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                throw new ApplicationException("The bitmap must be 32ppp with alpha-channel.");

            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));  // grab a GDI handle from this GDI+ bitmap
                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Win32.Size size = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.Point pointSource = new Win32.Point(0, 0);
                Win32.Point topPos = new Win32.Point(Left, Top);
                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = Win32.AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = Win32.AC_SRC_ALPHA;

                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }

        private void SizeHandler_Resized(object sender, EventArgs e)
        {
            var bmp = new Bitmap(image, Size);
            SetBitmap(bmp, 255);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animateEnabled = !animateEnabled;
            updateAnimation();
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            pbMain.Invalidate();
        }

        private void reverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animateReverse = !animateReverse;
            updateAnimation();
        }

        private void updateAnimation()
        {
            GakuAnimator.StopAnimate(image, OnFrameChanged);

            if(animateEnabled)
            {
                GakuAnimator.Animate(image, OnFrameChanged, animateReverse, animateSpeed);
            }

            updateAnimationMenu();
        }

        private void animationSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animateSpeed = int.Parse((sender as ToolStripMenuItem).Tag as string);
            updateAnimation();
        }

        private void updateAnimationMenu()
        {
            stopToolStripMenuItem.Checked = animateEnabled;
            reverseToolStripMenuItem.Checked = animateReverse;
            faster4ToolStripMenuItem.Checked = animateSpeed == 4;
            fast2ToolStripMenuItem.Checked = animateSpeed == 2;
            resetToolStripMenuItem.Checked = animateSpeed == 1;
            slowToolStripMenuItem.Checked = animateSpeed == -2;
            slower4ToolStripMenuItem.Checked = animateSpeed == -4;
        }
    }
}
