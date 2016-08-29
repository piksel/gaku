﻿namespace Gaku
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
            this.cmsGlobal = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.lTitle = new System.Windows.Forms.Label();
            this.pbLogotype = new System.Windows.Forms.PictureBox();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.pbDownloading = new System.Windows.Forms.ProgressBar();
            this.lDownloading = new System.Windows.Forms.Label();
            this.pDownloading = new System.Windows.Forms.Panel();
            this.pBorder = new System.Windows.Forms.Panel();
            this.bClose = new System.Windows.Forms.Button();
            this.alImageInfo = new Gaku.AlphaLabel();
            this.imgurLoading = new Gaku.ImgurLoading();
            this.cmsGlobal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogotype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.pDownloading.SuspendLayout();
            this.pBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsGlobal
            // 
            this.cmsGlobal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.cmsGlobal.Name = "contextMenuStrip1";
            this.cmsGlobal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmsGlobal.Size = new System.Drawing.Size(174, 214);
            // 
            // gakuV100ToolStripMenuItem
            // 
            this.gakuV100ToolStripMenuItem.Name = "gakuV100ToolStripMenuItem";
            this.gakuV100ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.gakuV100ToolStripMenuItem.Text = "Gaku v1.0.0";
            this.gakuV100ToolStripMenuItem.Click += new System.EventHandler(this.gakuV100ToolStripMenuItem_Click);
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
            this.fileAssosciationsToolStripMenuItem.Enabled = false;
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
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.lTitle.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(12, 9);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(143, 37);
            this.lTitle.TabIndex = 4;
            this.lTitle.Text = "Gaku v1.0.0";
            this.lTitle.Visible = false;
            // 
            // pbLogotype
            // 
            this.pbLogotype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogotype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.pbLogotype.Image = global::Gaku.Properties.Resources.piksel_gaku;
            this.pbLogotype.Location = new System.Drawing.Point(738, 424);
            this.pbLogotype.Name = "pbLogotype";
            this.pbLogotype.Size = new System.Drawing.Size(102, 78);
            this.pbLogotype.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogotype.TabIndex = 5;
            this.pbLogotype.TabStop = false;
            this.pbLogotype.Visible = false;
            // 
            // pbMain
            // 
            this.pbMain.BackColor = System.Drawing.Color.Black;
            this.pbMain.ContextMenuStrip = this.cmsGlobal;
            this.pbMain.Image = global::Gaku.Properties.Resources._default;
            this.pbMain.Location = new System.Drawing.Point(18, -213);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(1000, 1000);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.global_MouseDown);
            this.pbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.global_MouseMove);
            this.pbMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.global_MouseUp);
            // 
            // pbDownloading
            // 
            this.pbDownloading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDownloading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.pbDownloading.Location = new System.Drawing.Point(24, 36);
            this.pbDownloading.Name = "pbDownloading";
            this.pbDownloading.Size = new System.Drawing.Size(400, 10);
            this.pbDownloading.TabIndex = 7;
            this.pbDownloading.Value = 50;
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
            this.pDownloading.Controls.Add(this.pbDownloading);
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
            this.pBorder.Controls.Add(this.bClose);
            this.pBorder.Controls.Add(this.alImageInfo);
            this.pBorder.Controls.Add(this.pbMain);
            this.pBorder.Location = new System.Drawing.Point(0, 0);
            this.pBorder.Name = "pBorder";
            this.pBorder.Size = new System.Drawing.Size(854, 515);
            this.pBorder.TabIndex = 10;
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(168)))));
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.bClose.ForeColor = System.Drawing.Color.White;
            this.bClose.Location = new System.Drawing.Point(817, -4);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(35, 34);
            this.bClose.TabIndex = 2;
            this.bClose.Text = "x";
            this.bClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Visible = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            this.bClose.MouseEnter += new System.EventHandler(this.bClose_MouseEnter);
            this.bClose.MouseLeave += new System.EventHandler(this.bClose_MouseLeave);
            // 
            // alImageInfo
            // 
            this.alImageInfo.Alpha = ((byte)(128));
            this.alImageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alImageInfo.Font = new System.Drawing.Font("monofur", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alImageInfo.ForeColor = System.Drawing.Color.White;
            this.alImageInfo.Lines = new string[] {
        ""};
            this.alImageInfo.Location = new System.Drawing.Point(12, 12);
            this.alImageInfo.Name = "alImageInfo";
            this.alImageInfo.Padding = new System.Windows.Forms.Padding(10);
            this.alImageInfo.Size = new System.Drawing.Size(828, 490);
            this.alImageInfo.TabIndex = 1;
            this.alImageInfo.Visible = false;
            this.alImageInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.global_MouseDown);
            this.alImageInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.global_MouseMove);
            this.alImageInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.global_MouseUp);
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
            // FormGaku
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(852, 514);
            this.ContextMenuStrip = this.cmsGlobal;
            this.Controls.Add(this.pDownloading);
            this.Controls.Add(this.imgurLoading);
            this.Controls.Add(this.pbLogotype);
            this.Controls.Add(this.lTitle);
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
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.global_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.global_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.global_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.global_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.global_MouseUp);
            this.cmsGlobal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogotype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.pDownloading.ResumeLayout(false);
            this.pBorder.ResumeLayout(false);
            this.pBorder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsGlobal;
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
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.PictureBox pbLogotype;
        private System.Windows.Forms.ToolStripMenuItem hideCursorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImagePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadImageToImgurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private ImgurLoading imgurLoading;
        private System.Windows.Forms.ProgressBar pbDownloading;
        private System.Windows.Forms.Label lDownloading;
        private System.Windows.Forms.Panel pDownloading;
        private System.Windows.Forms.ToolStripMenuItem fileAssosciationsToolStripMenuItem;
        private System.Windows.Forms.Panel pBorder;
        private AlphaLabel alImageInfo;
        private System.Windows.Forms.Button bClose;
    }
}

