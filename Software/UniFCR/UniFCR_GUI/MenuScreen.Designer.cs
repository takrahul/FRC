namespace UniFCR_GUI
{
    partial class MenuScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.uniFCRLogoBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.trainButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsBackButton = new System.Windows.Forms.Button();
            this.trainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.trainSaveButton = new System.Windows.Forms.Button();
            this.numberLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.lastNameBox = new System.Windows.Forms.TextBox();
            this.trainCamPanel = new System.Windows.Forms.Panel();
            this.trainCamView = new Emgu.CV.UI.ImageBox();
            this.trainStartButton = new System.Windows.Forms.Button();
            this.firstNameBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.trainBackButton = new System.Windows.Forms.Button();
            this.trainLoadingPanel = new System.Windows.Forms.Panel();
            this.logoTextPanel = new System.Windows.Forms.Panel();
            this.loadingLogo = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniFCRLogoBox)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.trainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.trainCamPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainCamView)).BeginInit();
            this.trainLoadingPanel.SuspendLayout();
            this.logoTextPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.titlePanel);
            this.mainPanel.Controls.Add(this.menuPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 500);
            this.mainPanel.TabIndex = 0;
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
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(284, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(385, 108);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "UniFCR";
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.menuPanel.Controls.Add(this.buttonPanel);
            this.menuPanel.Controls.Add(this.optionsPanel);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuPanel.ForeColor = System.Drawing.Color.DarkGray;
            this.menuPanel.Location = new System.Drawing.Point(0, 155);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(800, 345);
            this.menuPanel.TabIndex = 1;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
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
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.trainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.Color.DarkGray;
            this.exitButton.Location = new System.Drawing.Point(279, 99);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(170, 48);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.optionsBackButton);
            this.optionsPanel.Location = new System.Drawing.Point(130, 48);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(528, 232);
            this.optionsPanel.TabIndex = 5;
            // 
            // optionsBackButton
            // 
            this.optionsBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsBackButton.ForeColor = System.Drawing.Color.DarkGray;
            this.optionsBackButton.Location = new System.Drawing.Point(174, 84);
            this.optionsBackButton.Name = "optionsBackButton";
            this.optionsBackButton.Size = new System.Drawing.Size(170, 48);
            this.optionsBackButton.TabIndex = 1;
            this.optionsBackButton.Text = "BACK";
            this.optionsBackButton.UseVisualStyleBackColor = true;
            this.optionsBackButton.Click += new System.EventHandler(this.optionsBackButton_Click);
            // 
            // trainPanel
            // 
            this.trainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.trainPanel.Controls.Add(this.tableLayoutPanel1);
            this.trainPanel.Controls.Add(this.trainLoadingPanel);
            this.trainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainPanel.Location = new System.Drawing.Point(0, 0);
            this.trainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.trainPanel.Name = "trainPanel";
            this.trainPanel.Size = new System.Drawing.Size(800, 500);
            this.trainPanel.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.trainSaveButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numberLabel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lastNameLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numberBox, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lastNameBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.trainCamPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.trainStartButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.firstNameBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.firstNameLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.trainBackButton, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // trainSaveButton
            // 
            this.trainSaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trainSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainSaveButton.ForeColor = System.Drawing.Color.DarkGray;
            this.trainSaveButton.Location = new System.Drawing.Point(581, 183);
            this.trainSaveButton.MaximumSize = new System.Drawing.Size(170, 48);
            this.trainSaveButton.MinimumSize = new System.Drawing.Size(170, 48);
            this.trainSaveButton.Name = "trainSaveButton";
            this.trainSaveButton.Size = new System.Drawing.Size(170, 48);
            this.trainSaveButton.TabIndex = 6;
            this.trainSaveButton.Text = "SAVE";
            this.trainSaveButton.UseVisualStyleBackColor = true;
            this.trainSaveButton.Click += new System.EventHandler(this.trainSaveButton_Click);
            // 
            // numberLabel
            // 
            this.numberLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.numberLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.numberLabel.Location = new System.Drawing.Point(574, 415);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(183, 33);
            this.numberLabel.TabIndex = 9;
            this.numberLabel.Text = "Mat. Number";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.lastNameLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.lastNameLabel.Location = new System.Drawing.Point(321, 415);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(156, 33);
            this.lastNameLabel.TabIndex = 8;
            this.lastNameLabel.Text = "Last Name";
            // 
            // numberBox
            // 
            this.numberBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numberBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberBox.Location = new System.Drawing.Point(536, 459);
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(260, 31);
            this.numberBox.TabIndex = 6;
            this.numberBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lastNameBox
            // 
            this.lastNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameBox.Location = new System.Drawing.Point(269, 459);
            this.lastNameBox.Name = "lastNameBox";
            this.lastNameBox.Size = new System.Drawing.Size(260, 31);
            this.lastNameBox.TabIndex = 5;
            this.lastNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trainCamPanel
            // 
            this.trainCamPanel.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.trainCamPanel, 2);
            this.trainCamPanel.Controls.Add(this.trainCamView);
            this.trainCamPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trainCamPanel.Location = new System.Drawing.Point(0, 0);
            this.trainCamPanel.Margin = new System.Windows.Forms.Padding(0);
            this.trainCamPanel.Name = "trainCamPanel";
            this.tableLayoutPanel1.SetRowSpan(this.trainCamPanel, 3);
            this.trainCamPanel.Size = new System.Drawing.Size(532, 414);
            this.trainCamPanel.TabIndex = 1;
            this.trainCamPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.trainCamPanel_Paint);
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
            this.trainCamView.BackColorChanged += new System.EventHandler(this.trainCamView_BackColorChanged);
            // 
            // trainStartButton
            // 
            this.trainStartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trainStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainStartButton.ForeColor = System.Drawing.Color.DarkGray;
            this.trainStartButton.Location = new System.Drawing.Point(581, 45);
            this.trainStartButton.MaximumSize = new System.Drawing.Size(170, 48);
            this.trainStartButton.MinimumSize = new System.Drawing.Size(170, 48);
            this.trainStartButton.Name = "trainStartButton";
            this.trainStartButton.Size = new System.Drawing.Size(170, 48);
            this.trainStartButton.TabIndex = 2;
            this.trainStartButton.Text = "START";
            this.trainStartButton.UseVisualStyleBackColor = true;
            this.trainStartButton.Click += new System.EventHandler(this.trainStartButton_Click);
            // 
            // firstNameBox
            // 
            this.firstNameBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstNameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.firstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameBox.Location = new System.Drawing.Point(3, 459);
            this.firstNameBox.Name = "firstNameBox";
            this.firstNameBox.Size = new System.Drawing.Size(260, 31);
            this.firstNameBox.TabIndex = 4;
            this.firstNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.firstNameLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.firstNameLabel.Location = new System.Drawing.Point(53, 415);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(159, 33);
            this.firstNameLabel.TabIndex = 7;
            this.firstNameLabel.Text = "First Name";
            // 
            // trainBackButton
            // 
            this.trainBackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trainBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trainBackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 69F);
            this.loadingLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.loadingLabel.Location = new System.Drawing.Point(0, 250);
            this.loadingLabel.MaximumSize = new System.Drawing.Size(370, 100);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(370, 100);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "UniFCR";
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.trainPanel);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuScreen";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniFCRLogoBox)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.trainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel trainCamPanel;
        private Emgu.CV.UI.ImageBox trainCamView;
        private System.Windows.Forms.Button trainStartButton;
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
        private System.Windows.Forms.Button trainSaveButton;
    }
}

