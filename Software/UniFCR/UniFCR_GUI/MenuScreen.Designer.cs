﻿namespace UniFCR_GUI {
    partial class MenuScreen {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsContentPanel = new System.Windows.Forms.Panel();
            this.optionsDeleteButton = new System.Windows.Forms.Button();
            this.optionsDeleteBox = new System.Windows.Forms.TextBox();
            this.thresholdTextBox = new System.Windows.Forms.TextBox();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.thresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.cameraListBox = new System.Windows.Forms.ComboBox();
            this.optionsBackPanel = new System.Windows.Forms.Panel();
            this.optionsBackButton = new System.Windows.Forms.Button();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.trainButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.uniFCRLogoBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.trainPanel = new System.Windows.Forms.Panel();
            this.trainButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.trainCaptureButton = new System.Windows.Forms.Button();
            this.numberLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.trainCamPanel = new System.Windows.Forms.Panel();
            this.trainCamView = new Emgu.CV.UI.ImageBox();
            this.trainSaveButton = new System.Windows.Forms.Button();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.trainBackButton = new System.Windows.Forms.Button();
            this.trainLoadingPanel = new System.Windows.Forms.Panel();
            this.logoTextPanel = new System.Windows.Forms.Panel();
            this.loadingLogo = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.optionsContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).BeginInit();
            this.optionsBackPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniFCRLogoBox)).BeginInit();
            this.trainPanel.SuspendLayout();
            this.trainButtonPanel.SuspendLayout();
            this.trainCamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainCamView)).BeginInit();
            this.trainLoadingPanel.SuspendLayout();
            this.logoTextPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.menuPanel);
            this.mainPanel.Controls.Add(this.titlePanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 500);
            this.mainPanel.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.menuPanel.Controls.Add(this.optionsPanel);
            this.menuPanel.Controls.Add(this.buttonPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuPanel.ForeColor = System.Drawing.Color.DarkGray;
            this.menuPanel.Location = new System.Drawing.Point(0, 155);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(800, 345);
            this.menuPanel.TabIndex = 1;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.optionsPanel.Controls.Add(this.optionsContentPanel);
            this.optionsPanel.Controls.Add(this.optionsBackPanel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(800, 345);
            this.optionsPanel.TabIndex = 5;
            // 
            // optionsContentPanel
            // 
            this.optionsContentPanel.Controls.Add(this.optionsDeleteButton);
            this.optionsContentPanel.Controls.Add(this.optionsDeleteBox);
            this.optionsContentPanel.Controls.Add(this.thresholdTextBox);
            this.optionsContentPanel.Controls.Add(this.thresholdLabel);
            this.optionsContentPanel.Controls.Add(this.thresholdTrackBar);
            this.optionsContentPanel.Controls.Add(this.cameraListBox);
            this.optionsContentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsContentPanel.Location = new System.Drawing.Point(0, 0);
            this.optionsContentPanel.Name = "optionsContentPanel";
            this.optionsContentPanel.Size = new System.Drawing.Size(800, 259);
            this.optionsContentPanel.TabIndex = 3;
            // 
            // optionsDeleteButton
            // 
            this.optionsDeleteButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.optionsDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsDeleteButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsDeleteButton.ForeColor = System.Drawing.Color.DarkGray;
            this.optionsDeleteButton.Location = new System.Drawing.Point(455, 169);
            this.optionsDeleteButton.MaximumSize = new System.Drawing.Size(170, 48);
            this.optionsDeleteButton.MinimumSize = new System.Drawing.Size(170, 48);
            this.optionsDeleteButton.Name = "optionsDeleteButton";
            this.optionsDeleteButton.Size = new System.Drawing.Size(170, 48);
            this.optionsDeleteButton.TabIndex = 7;
            this.optionsDeleteButton.Text = "DELETE";
            this.optionsDeleteButton.UseVisualStyleBackColor = true;
            this.optionsDeleteButton.Click += new System.EventHandler(this.optionsDeleteButton_Click);
            // 
            // optionsDeleteBox
            // 
            this.optionsDeleteBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.optionsDeleteBox.Font = new System.Drawing.Font("Century Gothic", 25F);
            this.optionsDeleteBox.Location = new System.Drawing.Point(191, 174);
            this.optionsDeleteBox.Name = "optionsDeleteBox";
            this.optionsDeleteBox.Size = new System.Drawing.Size(255, 41);
            this.optionsDeleteBox.TabIndex = 6;
            this.optionsDeleteBox.TabStop = false;
            this.optionsDeleteBox.Text = "Enter Mat. No.";
            this.optionsDeleteBox.Enter += new System.EventHandler(this.optionsDeleteBox_Enter);
            // 
            // thresholdTextBox
            // 
            this.thresholdTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.thresholdTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.thresholdTextBox.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.thresholdTextBox.ForeColor = System.Drawing.Color.DarkGray;
            this.thresholdTextBox.Location = new System.Drawing.Point(432, 115);
            this.thresholdTextBox.Name = "thresholdTextBox";
            this.thresholdTextBox.Size = new System.Drawing.Size(100, 33);
            this.thresholdTextBox.TabIndex = 5;
            this.thresholdTextBox.Text = "30";
            this.thresholdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.thresholdTextBox_KeyPress);
            this.thresholdTextBox.Leave += new System.EventHandler(this.thresholdTextBox_Leave);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.thresholdLabel.Location = new System.Drawing.Point(282, 115);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(144, 33);
            this.thresholdLabel.TabIndex = 4;
            this.thresholdLabel.Text = "Threshold:";
            // 
            // thresholdTrackBar
            // 
            this.thresholdTrackBar.Location = new System.Drawing.Point(191, 97);
            this.thresholdTrackBar.Maximum = 100;
            this.thresholdTrackBar.Minimum = 1;
            this.thresholdTrackBar.Name = "thresholdTrackBar";
            this.thresholdTrackBar.Size = new System.Drawing.Size(434, 45);
            this.thresholdTrackBar.TabIndex = 3;
            this.thresholdTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.thresholdTrackBar.Value = 30;
            this.thresholdTrackBar.Scroll += new System.EventHandler(this.thresholdTrackBar_Scroll);
            // 
            // cameraListBox
            // 
            this.cameraListBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cameraListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cameraListBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cameraListBox.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraListBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cameraListBox.FormattingEnabled = true;
            this.cameraListBox.Location = new System.Drawing.Point(191, 36);
            this.cameraListBox.MaximumSize = new System.Drawing.Size(434, 0);
            this.cameraListBox.MinimumSize = new System.Drawing.Size(434, 0);
            this.cameraListBox.Name = "cameraListBox";
            this.cameraListBox.Size = new System.Drawing.Size(434, 38);
            this.cameraListBox.TabIndex = 2;
            // 
            // optionsBackPanel
            // 
            this.optionsBackPanel.Controls.Add(this.optionsBackButton);
            this.optionsBackPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.optionsBackPanel.Location = new System.Drawing.Point(0, 262);
            this.optionsBackPanel.Name = "optionsBackPanel";
            this.optionsBackPanel.Size = new System.Drawing.Size(800, 83);
            this.optionsBackPanel.TabIndex = 4;
            // 
            // optionsBackButton
            // 
            this.optionsBackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.optionsBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsBackButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsBackButton.ForeColor = System.Drawing.Color.DarkGray;
            this.optionsBackButton.Location = new System.Drawing.Point(322, 23);
            this.optionsBackButton.MaximumSize = new System.Drawing.Size(170, 48);
            this.optionsBackButton.MinimumSize = new System.Drawing.Size(170, 48);
            this.optionsBackButton.Name = "optionsBackButton";
            this.optionsBackButton.Size = new System.Drawing.Size(170, 48);
            this.optionsBackButton.TabIndex = 1;
            this.optionsBackButton.Text = "BACK";
            this.optionsBackButton.UseVisualStyleBackColor = true;
            this.optionsBackButton.Click += new System.EventHandler(this.optionsBackButton_Click);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPanel.Controls.Add(this.startButton);
            this.buttonPanel.Controls.Add(this.trainButton);
            this.buttonPanel.Controls.Add(this.optionsButton);
            this.buttonPanel.Controls.Add(this.exitButton);
            this.buttonPanel.Location = new System.Drawing.Point(173, 97);
            this.buttonPanel.MaximumSize = new System.Drawing.Size(452, 150);
            this.buttonPanel.MinimumSize = new System.Drawing.Size(452, 150);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(452, 150);
            this.buttonPanel.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.Color.DarkGray;
            this.startButton.Location = new System.Drawing.Point(3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(170, 48);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // trainButton
            // 
            this.trainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trainButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainButton.ForeColor = System.Drawing.Color.DarkGray;
            this.trainButton.Location = new System.Drawing.Point(3, 102);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(170, 48);
            this.trainButton.TabIndex = 3;
            this.trainButton.Text = "TRAIN";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.ForeColor = System.Drawing.Color.DarkGray;
            this.optionsButton.Location = new System.Drawing.Point(282, 3);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(170, 48);
            this.optionsButton.TabIndex = 1;
            this.optionsButton.Text = "OPTIONS";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.DarkGray;
            this.exitButton.Location = new System.Drawing.Point(279, 99);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(170, 48);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.White;
            this.titlePanel.Controls.Add(this.uniFCRLogoBox);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(800, 157);
            this.titlePanel.TabIndex = 0;
            this.titlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuScreen_MouseDown);
            this.titlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuScreen_MouseMove);
            this.titlePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuScreen_MouseUp);
            // 
            // uniFCRLogoBox
            // 
            this.uniFCRLogoBox.Image = ((System.Drawing.Image)(resources.GetObject("uniFCRLogoBox.Image")));
            this.uniFCRLogoBox.Location = new System.Drawing.Point(130, 12);
            this.uniFCRLogoBox.Name = "uniFCRLogoBox";
            this.uniFCRLogoBox.Size = new System.Drawing.Size(133, 134);
            this.uniFCRLogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uniFCRLogoBox.TabIndex = 2;
            this.uniFCRLogoBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(284, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(374, 115);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "UniFCR";
            // 
            // trainPanel
            // 
            this.trainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.trainPanel.Controls.Add(this.trainButtonPanel);
            this.trainPanel.Controls.Add(this.trainLoadingPanel);
            this.trainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainPanel.Location = new System.Drawing.Point(0, 0);
            this.trainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.trainPanel.Name = "trainPanel";
            this.trainPanel.Size = new System.Drawing.Size(800, 500);
            this.trainPanel.TabIndex = 6;
            // 
            // trainButtonPanel
            // 
            this.trainButtonPanel.ColumnCount = 3;
            this.trainButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.trainButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.trainButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.trainButtonPanel.Controls.Add(this.trainCaptureButton, 2, 1);
            this.trainButtonPanel.Controls.Add(this.numberLabel, 2, 3);
            this.trainButtonPanel.Controls.Add(this.lastNameLabel, 1, 3);
            this.trainButtonPanel.Controls.Add(this.numberBox, 2, 4);
            this.trainButtonPanel.Controls.Add(this.lastNameBox, 1, 4);
            this.trainButtonPanel.Controls.Add(this.trainCamPanel, 0, 0);
            this.trainButtonPanel.Controls.Add(this.trainSaveButton, 2, 0);
            this.trainButtonPanel.Controls.Add(this.firstNameBox, 0, 4);
            this.trainButtonPanel.Controls.Add(this.firstNameLabel, 0, 3);
            this.trainButtonPanel.Controls.Add(this.trainBackButton, 2, 2);
            this.trainButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.trainButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.trainButtonPanel.Name = "trainButtonPanel";
            this.trainButtonPanel.RowCount = 5;
            this.trainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.trainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.trainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.trainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.trainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.trainButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.trainButtonPanel.Size = new System.Drawing.Size(800, 500);
            this.trainButtonPanel.TabIndex = 0;
            // 
            // trainCaptureButton
            // 
            this.trainCaptureButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trainCaptureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainCaptureButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainCaptureButton.ForeColor = System.Drawing.Color.DarkGray;
            this.trainCaptureButton.Location = new System.Drawing.Point(581, 183);
            this.trainCaptureButton.MaximumSize = new System.Drawing.Size(170, 48);
            this.trainCaptureButton.MinimumSize = new System.Drawing.Size(170, 48);
            this.trainCaptureButton.Name = "trainCaptureButton";
            this.trainCaptureButton.Size = new System.Drawing.Size(170, 48);
            this.trainCaptureButton.TabIndex = 7;
            this.trainCaptureButton.Text = "CAPTURE";
            this.trainCaptureButton.UseVisualStyleBackColor = true;
            this.trainCaptureButton.Click += new System.EventHandler(this.trainCaptureButton_Click);
            // 
            // numberLabel
            // 
            this.numberLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Century Gothic", 21.75F);
            this.numberLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.numberLabel.Location = new System.Drawing.Point(564, 414);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(204, 36);
            this.numberLabel.TabIndex = 9;
            this.numberLabel.Text = "Mat. Number";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Century Gothic", 21.75F);
            this.lastNameLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lastNameLabel.Location = new System.Drawing.Point(316, 414);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(165, 36);
            this.lastNameLabel.TabIndex = 8;
            this.lastNameLabel.Text = "Last Name";
            // 
            // numberBox
            // 
            this.numberBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numberBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numberBox.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberBox.Location = new System.Drawing.Point(536, 458);
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(260, 34);
            this.numberBox.TabIndex = 6;
            this.numberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastNameBox.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameBox.Location = new System.Drawing.Point(269, 458);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(260, 34);
            this.lastNameBox.TabIndex = 5;
            this.lastNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trainCamPanel
            // 
            this.trainCamPanel.BackColor = System.Drawing.Color.Black;
            this.trainButtonPanel.SetColumnSpan(this.trainCamPanel, 2);
            this.trainCamPanel.Controls.Add(this.trainCamView);
            this.trainCamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainCamPanel.Location = new System.Drawing.Point(0, 0);
            this.trainCamPanel.Margin = new System.Windows.Forms.Padding(0);
            this.trainCamPanel.Name = "trainCamPanel";
            this.trainButtonPanel.SetRowSpan(this.trainCamPanel, 3);
            this.trainCamPanel.Size = new System.Drawing.Size(532, 414);
            this.trainCamPanel.TabIndex = 1;
            this.trainCamPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.trainCamPanel_Paint);
            this.trainCamPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuScreen_MouseDown);
            this.trainCamPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuScreen_MouseMove);
            this.trainCamPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MenuScreen_MouseUp);
            // 
            // trainCamView
            // 
            this.trainCamView.BackColor = System.Drawing.Color.DarkGray;
            this.trainCamView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainCamView.Location = new System.Drawing.Point(0, 0);
            this.trainCamView.Margin = new System.Windows.Forms.Padding(0);
            this.trainCamView.Name = "trainCamView";
            this.trainCamView.Size = new System.Drawing.Size(532, 414);
            this.trainCamView.TabIndex = 5;
            this.trainCamView.TabStop = false;
            // 
            // trainSaveButton
            // 
            this.trainSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trainSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainSaveButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainSaveButton.ForeColor = System.Drawing.Color.DarkGray;
            this.trainSaveButton.Location = new System.Drawing.Point(581, 45);
            this.trainSaveButton.MaximumSize = new System.Drawing.Size(170, 48);
            this.trainSaveButton.MinimumSize = new System.Drawing.Size(170, 48);
            this.trainSaveButton.Name = "trainSaveButton";
            this.trainSaveButton.Size = new System.Drawing.Size(170, 48);
            this.trainSaveButton.TabIndex = 2;
            this.trainSaveButton.Text = "SAVE";
            this.trainSaveButton.UseVisualStyleBackColor = true;
            this.trainSaveButton.Click += new System.EventHandler(this.trainSaveButton_Click);
            // 
            // firstNameBox
            // 
            this.firstNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstNameBox.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameBox.Location = new System.Drawing.Point(3, 458);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(260, 34);
            this.firstNameBox.TabIndex = 4;
            this.firstNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Century Gothic", 21.75F);
            this.firstNameLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.firstNameLabel.Location = new System.Drawing.Point(52, 414);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(162, 36);
            this.firstNameLabel.TabIndex = 7;
            this.firstNameLabel.Text = "First Name";
            // 
            // trainBackButton
            // 
            this.trainBackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trainBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainBackButton.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainBackButton.ForeColor = System.Drawing.Color.DarkGray;
            this.trainBackButton.Location = new System.Drawing.Point(581, 321);
            this.trainBackButton.MaximumSize = new System.Drawing.Size(170, 48);
            this.trainBackButton.MinimumSize = new System.Drawing.Size(170, 48);
            this.trainBackButton.Name = "trainBackButton";
            this.trainBackButton.Size = new System.Drawing.Size(170, 48);
            this.trainBackButton.TabIndex = 3;
            this.trainBackButton.Text = "BACK";
            this.trainBackButton.UseVisualStyleBackColor = true;
            this.trainBackButton.Click += new System.EventHandler(this.trainBackButton_Click);
            // 
            // trainLoadingPanel
            // 
            this.trainLoadingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.trainLoadingPanel.Controls.Add(this.logoTextPanel);
            this.trainLoadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainLoadingPanel.Location = new System.Drawing.Point(0, 0);
            this.trainLoadingPanel.Name = "trainLoadingPanel";
            this.trainLoadingPanel.Size = new System.Drawing.Size(800, 500);
            this.trainLoadingPanel.TabIndex = 7;
            this.trainLoadingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.trainLoadingPanel_Paint);
            // 
            // logoTextPanel
            // 
            this.logoTextPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoTextPanel.Controls.Add(this.loadingLogo);
            this.logoTextPanel.Controls.Add(this.loadingLabel);
            this.logoTextPanel.Location = new System.Drawing.Point(207, 93);
            this.logoTextPanel.MaximumSize = new System.Drawing.Size(370, 350);
            this.logoTextPanel.MinimumSize = new System.Drawing.Size(35, 25);
            this.logoTextPanel.Name = "logoTextPanel";
            this.logoTextPanel.Size = new System.Drawing.Size(350, 350);
            this.logoTextPanel.TabIndex = 2;
            // 
            // loadingLogo
            // 
            this.loadingLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingLogo.Image = ((System.Drawing.Image)(resources.GetObject("loadingLogo.Image")));
            this.loadingLogo.Location = new System.Drawing.Point(47, 0);
            this.loadingLogo.MaximumSize = new System.Drawing.Size(250, 250);
            this.loadingLogo.MinimumSize = new System.Drawing.Size(10, 10);
            this.loadingLogo.Name = "loadingLogo";
            this.loadingLogo.Size = new System.Drawing.Size(250, 250);
            this.loadingLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingLogo.TabIndex = 0;
            this.loadingLogo.TabStop = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadingLabel.Font = new System.Drawing.Font("Century Gothic", 69F);
            this.loadingLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.loadingLabel.Location = new System.Drawing.Point(0, 250);
            this.loadingLabel.MaximumSize = new System.Drawing.Size(370, 100);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(358, 100);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "UniFCR";
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.trainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuScreen";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsContentPanel.ResumeLayout(false);
            this.optionsContentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdTrackBar)).EndInit();
            this.optionsBackPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniFCRLogoBox)).EndInit();
            this.trainPanel.ResumeLayout(false);
            this.trainButtonPanel.ResumeLayout(false);
            this.trainButtonPanel.PerformLayout();
            this.trainCamPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trainCamView)).EndInit();
            this.trainLoadingPanel.ResumeLayout(false);
            this.logoTextPanel.ResumeLayout(false);
            this.logoTextPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Button optionsBackButton;
        private System.Windows.Forms.PictureBox uniFCRLogoBox;
        private System.Windows.Forms.Panel trainPanel;
        private System.Windows.Forms.TableLayoutPanel trainButtonPanel;
        private System.Windows.Forms.Panel trainCamPanel;
        private Emgu.CV.UI.ImageBox trainCamView;
        private System.Windows.Forms.Button trainSaveButton;
        private System.Windows.Forms.Button trainBackButton;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.TextBox lastNameBox;
        private System.Windows.Forms.TextBox firstNameBox;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Panel trainLoadingPanel;
        private System.Windows.Forms.Panel logoTextPanel;
        private System.Windows.Forms.PictureBox loadingLogo;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Button trainCaptureButton;
        private System.Windows.Forms.ComboBox cameraListBox;
        private System.Windows.Forms.Panel optionsBackPanel;
        private System.Windows.Forms.Panel optionsContentPanel;
        private System.Windows.Forms.TrackBar thresholdTrackBar;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.TextBox thresholdTextBox;
        private System.Windows.Forms.Button optionsDeleteButton;
        private System.Windows.Forms.TextBox optionsDeleteBox;
    }
}

