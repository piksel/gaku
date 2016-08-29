namespace Gaku
{
    partial class FormGaku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGaku));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gakuV100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.imageInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileAssosciationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImagePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadImageToImgurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.customColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.customWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.pxToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.setSizeToImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lDownloading = new System.Windows.Forms.Label();
            this.pDownloading = new System.Windows.Forms.Panel();
            this.pBorder = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.imgurLoading = new Gaku.ImgurLoading();
            this.alphaLabel1 = new Gaku.AlphaLabel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pDownloading.SuspendLayout();
            this.pBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gakuV100ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.imageInformationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.hideCursorToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.borderTypeToolStripMenuItem,
            this.setSizeToImageToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 192);
            // 
            // gakuV100ToolStripMenuItem
            // 
            this.gakuV100ToolStripMenuItem.Name = "gakuV100ToolStripMenuItem";
            this.gakuV100ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.gakuV100ToolStripMenuItem.Text = "Gaku v1.0.0";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 6);
            // 
            // imageInformationToolStripMenuItem
            // 
            this.imageInformationToolStripMenuItem.Name = "imageInformationToolStripMenuItem";
            this.imageInformationToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.imageInformationToolStripMenuItem.Text = "Image information";
            this.imageInformationToolStripMenuItem.Click += new System.EventHandler(this.imageInformationToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileAssosciationsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // fileAssosciationsToolStripMenuItem
            // 
            this.fileAssosciationsToolStripMenuItem.Name = "fileAssosciationsToolStripMenuItem";
            this.fileAssosciationsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.fileAssosciationsToolStripMenuItem.Text = "File associations";
            // 
            // hideCursorToolStripMenuItem
            // 
            this.hideCursorToolStripMenuItem.CheckOnClick = true;
            this.hideCursorToolStripMenuItem.Name = "hideCursorToolStripMenuItem";
            this.hideCursorToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.hideCursorToolStripMenuItem.Text = "Hide cursor";
            this.hideCursorToolStripMenuItem.Click += new System.EventHandler(this.hideCursorToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImagePathToolStripMenuItem,
            this.copyImageToolStripMenuItem,
            this.uploadImageToImgurToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // openImagePathToolStripMenuItem
            // 
            this.openImagePathToolStripMenuItem.Name = "openImagePathToolStripMenuItem";
            this.openImagePathToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.openImagePathToolStripMenuItem.Text = "Open image path";
            this.openImagePathToolStripMenuItem.Click += new System.EventHandler(this.openImagePathToolStripMenuItem_Click);
            // 
            // copyImageToolStripMenuItem
            // 
            this.copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            this.copyImageToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyImageToolStripMenuItem.Text = "Copy image";
            this.copyImageToolStripMenuItem.Click += new System.EventHandler(this.copyImageToolStripMenuItem_Click);
            // 
            // uploadImageToImgurToolStripMenuItem
            // 
            this.uploadImageToImgurToolStripMenuItem.Name = "uploadImageToImgurToolStripMenuItem";
            this.uploadImageToImgurToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.uploadImageToImgurToolStripMenuItem.Text = "Upload image to Imgur";
            this.uploadImageToImgurToolStripMenuItem.Click += new System.EventHandler(this.uploadImageToImgurToolStripMenuItem_Click);
            // 
            // borderTypeToolStripMenuItem
            // 
            this.borderTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.thinToolStripMenuItem,
            this.resizableToolStripMenuItem,
            this.customToolStripMenuItem,
            this.toolStripMenuItem3,
            this.customColorToolStripMenuItem,
            this.customWidthToolStripMenuItem});
            this.borderTypeToolStripMenuItem.Name = "borderTypeToolStripMenuItem";
            this.borderTypeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.borderTypeToolStripMenuItem.Text = "Border type";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.noneToolStripMenuItem.Text = "None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // thinToolStripMenuItem
            // 
            this.thinToolStripMenuItem.Name = "thinToolStripMenuItem";
            this.thinToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.thinToolStripMenuItem.Text = "Thin";
            this.thinToolStripMenuItem.Click += new System.EventHandler(this.thinToolStripMenuItem_Click);
            // 
            // resizableToolStripMenuItem
            // 
            this.resizableToolStripMenuItem.Name = "resizableToolStripMenuItem";
            this.resizableToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.resizableToolStripMenuItem.Text = "Resizable";
            this.resizableToolStripMenuItem.Click += new System.EventHandler(this.resizableToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.customToolStripMenuItem.Text = "Custom";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(139, 6);
            // 
            // customColorToolStripMenuItem
            // 
            this.customColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.customToolStripMenuItem1});
            this.customColorToolStripMenuItem.Name = "customColorToolStripMenuItem";
            this.customColorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.customColorToolStripMenuItem.Text = "Border color";
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.blackToolStripMenuItem.Text = "Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem1
            // 
            this.customToolStripMenuItem1.Name = "customToolStripMenuItem1";
            this.customToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.customToolStripMenuItem1.Text = "Custom";
            this.customToolStripMenuItem1.Click += new System.EventHandler(this.customToolStripMenuItem1_Click);
            // 
            // customWidthToolStripMenuItem
            // 
            this.customWidthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pxToolStripMenuItem,
            this.pxToolStripMenuItem1,
            this.pxToolStripMenuItem2,
            this.pxToolStripMenuItem3,
            this.pxToolStripMenuItem4,
            this.pxToolStripMenuItem5});
            this.customWidthToolStripMenuItem.Name = "customWidthToolStripMenuItem";
            this.customWidthToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.customWidthToolStripMenuItem.Text = "Border width";
            // 
            // pxToolStripMenuItem
            // 
            this.pxToolStripMenuItem.Name = "pxToolStripMenuItem";
            this.pxToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem.Tag = "1";
            this.pxToolStripMenuItem.Text = "1px";
            this.pxToolStripMenuItem.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem1
            // 
            this.pxToolStripMenuItem1.Name = "pxToolStripMenuItem1";
            this.pxToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem1.Tag = "2";
            this.pxToolStripMenuItem1.Text = "2px";
            this.pxToolStripMenuItem1.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem2
            // 
            this.pxToolStripMenuItem2.Name = "pxToolStripMenuItem2";
            this.pxToolStripMenuItem2.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem2.Tag = "3";
            this.pxToolStripMenuItem2.Text = "3px";
            this.pxToolStripMenuItem2.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem3
            // 
            this.pxToolStripMenuItem3.Name = "pxToolStripMenuItem3";
            this.pxToolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem3.Tag = "5";
            this.pxToolStripMenuItem3.Text = "5px";
            this.pxToolStripMenuItem3.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem4
            // 
            this.pxToolStripMenuItem4.Name = "pxToolStripMenuItem4";
            this.pxToolStripMenuItem4.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem4.Tag = "8";
            this.pxToolStripMenuItem4.Text = "8px";
            this.pxToolStripMenuItem4.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // pxToolStripMenuItem5
            // 
            this.pxToolStripMenuItem5.Name = "pxToolStripMenuItem5";
            this.pxToolStripMenuItem5.Size = new System.Drawing.Size(98, 22);
            this.pxToolStripMenuItem5.Tag = "12";
            this.pxToolStripMenuItem5.Text = "12px";
            this.pxToolStripMenuItem5.Click += new System.EventHandler(this.pxToolStripMenuItem_Click);
            // 
            // setSizeToImageToolStripMenuItem
            // 
            this.setSizeToImageToolStripMenuItem.Name = "setSizeToImageToolStripMenuItem";
            this.setSizeToImageToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.setSizeToImageToolStripMenuItem.Text = "Resize to image";
            this.setSizeToImageToolStripMenuItem.Click += new System.EventHandler(this.setSizeToImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(170, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 37);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gaku v1.0.0";
            this.label4.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.pictureBox2.Image = global::Gaku.Properties.Resources.piksel_gaku;
            this.pictureBox2.Location = new System.Drawing.Point(738, 424);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(102, 78);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Image = global::Gaku.Properties.Resources._default;
            this.pictureBox1.Location = new System.Drawing.Point(18, -213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.progressBar1.Location = new System.Drawing.Point(24, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 10);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Value = 50;
            // 
            // lDownloading
            // 
            this.lDownloading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lDownloading.BackColor = System.Drawing.Color.Black;
            this.lDownloading.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.lDownloading.ForeColor = System.Drawing.Color.White;
            this.lDownloading.Location = new System.Drawing.Point(3, 8);
            this.lDownloading.Name = "lDownloading";
            this.lDownloading.Size = new System.Drawing.Size(438, 21);
            this.lDownloading.TabIndex = 8;
            this.lDownloading.Text = "downloading...";
            this.lDownloading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pDownloading
            // 
            this.pDownloading.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pDownloading.BackColor = System.Drawing.Color.Black;
            this.pDownloading.Controls.Add(this.lDownloading);
            this.pDownloading.Controls.Add(this.progressBar1);
            this.pDownloading.Location = new System.Drawing.Point(208, 435);
            this.pDownloading.Name = "pDownloading";
            this.pDownloading.Size = new System.Drawing.Size(441, 67);
            this.pDownloading.TabIndex = 9;
            this.pDownloading.Visible = false;
            // 
            // pBorder
            // 
            this.pBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBorder.Controls.Add(this.button1);
            this.pBorder.Controls.Add(this.alphaLabel1);
            this.pBorder.Controls.Add(this.pictureBox1);
            this.pBorder.Location = new System.Drawing.Point(0, 0);
            this.pBorder.Name = "pBorder";
            this.pBorder.Size = new System.Drawing.Size(854, 515);
            this.pBorder.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(817, -4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "x";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // imgurLoading
            // 
            this.imgurLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgurLoading.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgurLoading.Done = false;
            this.imgurLoading.Location = new System.Drawing.Point(12, 441);
            this.imgurLoading.Name = "imgurLoading";
            this.imgurLoading.Size = new System.Drawing.Size(61, 61);
            this.imgurLoading.Speed = 80;
            this.imgurLoading.TabIndex = 6;
            this.imgurLoading.Visible = false;
            // 
            // alphaLabel1
            // 
            this.alphaLabel1.Alpha = ((byte)(128));
            this.alphaLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alphaLabel1.Font = new System.Drawing.Font("monofur", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphaLabel1.ForeColor = System.Drawing.Color.White;
            this.alphaLabel1.Lines = new string[] {
        ""};
            this.alphaLabel1.Location = new System.Drawing.Point(12, 12);
            this.alphaLabel1.Name = "alphaLabel1";
            this.alphaLabel1.Padding = new System.Windows.Forms.Padding(10);
            this.alphaLabel1.Size = new System.Drawing.Size(828, 490);
            this.alphaLabel1.TabIndex = 1;
            this.alphaLabel1.Visible = false;
            this.alphaLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.alphaLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.alphaLabel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // FormGaku
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(852, 514);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pDownloading);
            this.Controls.Add(this.imgurLoading);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGaku";
            this.Text = "Gaku";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGaku_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormGaku_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormGaku_DragEnter);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pDownloading.ResumeLayout(false);
            this.pBorder.ResumeLayout(false);
            this.pBorder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem gakuV100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem imageInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem customColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem pxToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem setSizeToImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem hideCursorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImagePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadImageToImgurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private ImgurLoading imgurLoading;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lDownloading;
        private System.Windows.Forms.Panel pDownloading;
        private System.Windows.Forms.ToolStripMenuItem fileAssosciationsToolStripMenuItem;
        private System.Windows.Forms.Panel pBorder;
        private AlphaLabel alphaLabel1;
        private System.Windows.Forms.Button button1;
    }
}

