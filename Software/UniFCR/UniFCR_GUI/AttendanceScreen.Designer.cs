namespace UniFCR_GUI {
    partial class AttendanceScreen {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceScreen));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.attendancePercentageCircle = new CircularProgressBar.CircularProgressBar();
            this.studentListView = new System.Windows.Forms.ListView();
            this.numCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.firstNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.matNoCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uniFCRLogoBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.attendanceLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.camPanel = new System.Windows.Forms.Panel();
            this.camView = new Emgu.CV.UI.ImageBox();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.logoTextPanel = new System.Windows.Forms.Panel();
            this.loadingLogo = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniFCRLogoBox)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.camPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.camView)).BeginInit();
            this.loadingPanel.SuspendLayout();
            this.logoTextPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.sidePanel);
            this.mainPanel.Controls.Add(this.camPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1198, 1100);
            this.mainPanel.TabIndex = 0;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.White;
            this.sidePanel.Controls.Add(this.infoPanel);
            this.sidePanel.Controls.Add(this.buttonPanel);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidePanel.Location = new System.Drawing.Point(1000, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(198, 1100);
            this.sidePanel.TabIndex = 6;
            // 
            // infoPanel
            // 
            this.infoPanel.ColumnCount = 1;
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoPanel.Controls.Add(this.attendancePercentageCircle, 0, 2);
            this.infoPanel.Controls.Add(this.studentListView, 0, 4);
            this.infoPanel.Controls.Add(this.uniFCRLogoBox, 0, 0);
            this.infoPanel.Controls.Add(this.titleLabel, 0, 1);
            this.infoPanel.Controls.Add(this.attendanceLabel, 0, 3);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.RowCount = 5;
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPanel.Size = new System.Drawing.Size(198, 1030);
            this.infoPanel.TabIndex = 0;
            // 
            // attendancePercentageCircle
            // 
            this.attendancePercentageCircle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attendancePercentageCircle.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.attendancePercentageCircle.AnimationSpeed = 500;
            this.attendancePercentageCircle.BackColor = System.Drawing.Color.Transparent;
            this.attendancePercentageCircle.Font = new System.Drawing.Font("Century Gothic", 32F);
            this.attendancePercentageCircle.ForeColor = System.Drawing.Color.DarkGray;
            this.attendancePercentageCircle.InnerColor = System.Drawing.Color.Transparent;
            this.attendancePercentageCircle.InnerMargin = 2;
            this.attendancePercentageCircle.InnerWidth = -1;
            this.attendancePercentageCircle.Location = new System.Drawing.Point(3, 595);
            this.attendancePercentageCircle.Margin = new System.Windows.Forms.Padding(0, 100, 0, 100);
            this.attendancePercentageCircle.MarqueeAnimationSpeed = 2000;
            this.attendancePercentageCircle.Name = "attendancePercentageCircle";
            this.attendancePercentageCircle.OuterColor = System.Drawing.Color.LightSteelBlue;
            this.attendancePercentageCircle.OuterMargin = -25;
            this.attendancePercentageCircle.OuterWidth = 26;
            this.attendancePercentageCircle.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.attendancePercentageCircle.ProgressWidth = 25;
            this.attendancePercentageCircle.SecondaryFont = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendancePercentageCircle.Size = new System.Drawing.Size(192, 192);
            this.attendancePercentageCircle.StartAngle = 270;
            this.attendancePercentageCircle.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.attendancePercentageCircle.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.attendancePercentageCircle.SubscriptText = "";
            this.attendancePercentageCircle.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.attendancePercentageCircle.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.attendancePercentageCircle.SuperscriptText = "";
            this.attendancePercentageCircle.TabIndex = 12;
            this.attendancePercentageCircle.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.attendancePercentageCircle.Value = 68;
            // 
            // studentListView
            // 
            this.studentListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.studentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.numCol,
            this.firstNameCol,
            this.lastNameCol,
            this.matNoCol});
            this.studentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentListView.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.studentListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.studentListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.studentListView.HideSelection = false;
            this.studentListView.Location = new System.Drawing.Point(0, 937);
            this.studentListView.Margin = new System.Windows.Forms.Padding(0);
            this.studentListView.MultiSelect = false;
            this.studentListView.Name = "studentListView";
            this.studentListView.Size = new System.Drawing.Size(198, 293);
            this.studentListView.TabIndex = 11;
            this.studentListView.TabStop = false;
            this.studentListView.UseCompatibleStateImageBehavior = false;
            this.studentListView.View = System.Windows.Forms.View.Details;
            this.studentListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.studentListView_ItemSelectionChanged);
            // 
            // numCol
            // 
            this.numCol.Text = "No.";
            // 
            // firstNameCol
            // 
            this.firstNameCol.Text = "FirstName";
            // 
            // lastNameCol
            // 
            this.lastNameCol.Text = "Last Name";
            // 
            // matNoCol
            // 
            this.matNoCol.Text = "Mat. No.";
            // 
            // uniFCRLogoBox
            // 
            this.uniFCRLogoBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uniFCRLogoBox.Image = ((System.Drawing.Image)(resources.GetObject("uniFCRLogoBox.Image")));
            this.uniFCRLogoBox.Location = new System.Drawing.Point(24, 0);
            this.uniFCRLogoBox.Margin = new System.Windows.Forms.Padding(0);
            this.uniFCRLogoBox.MaximumSize = new System.Drawing.Size(150, 150);
            this.uniFCRLogoBox.MinimumSize = new System.Drawing.Size(10, 10);
            this.uniFCRLogoBox.Name = "uniFCRLogoBox";
            this.uniFCRLogoBox.Size = new System.Drawing.Size(150, 150);
            this.uniFCRLogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uniFCRLogoBox.TabIndex = 3;
            this.uniFCRLogoBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(3, 150);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(191, 345);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "UniFCR";
            // 
            // attendanceLabel
            // 
            this.attendanceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attendanceLabel.Font = new System.Drawing.Font("Century Gothic", 21.75F);
            this.attendanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.attendanceLabel.Location = new System.Drawing.Point(3, 887);
            this.attendanceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.attendanceLabel.Name = "attendanceLabel";
            this.attendanceLabel.Size = new System.Drawing.Size(192, 50);
            this.attendanceLabel.TabIndex = 4;
            this.attendanceLabel.Text = "Students present: ";
            this.attendanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.White;
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 1030);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(198, 70);
            this.buttonPanel.TabIndex = 6;
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Century Gothic", 21.75F);
            this.backButton.ForeColor = System.Drawing.Color.DarkGray;
            this.backButton.Location = new System.Drawing.Point(0, 0);
            this.backButton.Margin = new System.Windows.Forms.Padding(0);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(198, 70);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "BACK";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // camPanel
            // 
            this.camPanel.BackColor = System.Drawing.Color.Black;
            this.camPanel.Controls.Add(this.camView);
            this.camPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.camPanel.Location = new System.Drawing.Point(0, 0);
            this.camPanel.Name = "camPanel";
            this.camPanel.Size = new System.Drawing.Size(1000, 1100);
            this.camPanel.TabIndex = 0;
            this.camPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.camPanel_Paint);
            // 
            // camView
            // 
            this.camView.BackColor = System.Drawing.Color.Black;
            this.camView.Dock = System.Windows.Forms.DockStyle.Top;
            this.camView.Location = new System.Drawing.Point(0, 0);
            this.camView.Margin = new System.Windows.Forms.Padding(0);
            this.camView.Name = "camView";
            this.camView.Size = new System.Drawing.Size(1000, 894);
            this.camView.TabIndex = 5;
            this.camView.TabStop = false;
            // 
            // loadingPanel
            // 
            this.loadingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.loadingPanel.Controls.Add(this.logoTextPanel);
            this.loadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingPanel.Location = new System.Drawing.Point(0, 0);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(1198, 1100);
            this.loadingPanel.TabIndex = 6;
            this.loadingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.loadingPanel_Paint);
            // 
            // logoTextPanel
            // 
            this.logoTextPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoTextPanel.Controls.Add(this.loadingLogo);
            this.logoTextPanel.Controls.Add(this.loadingLabel);
            this.logoTextPanel.Location = new System.Drawing.Point(406, 393);
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "First Name";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last Name";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mat. No";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AttendanceScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 1100);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.loadingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AttendanceScreen";
            this.Text = "Form2";
            this.mainPanel.ResumeLayout(false);
            this.sidePanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniFCRLogoBox)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.camPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.camView)).EndInit();
            this.loadingPanel.ResumeLayout(false);
            this.logoTextPanel.ResumeLayout(false);
            this.logoTextPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel camPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TableLayoutPanel infoPanel;
        private System.Windows.Forms.PictureBox uniFCRLogoBox;
        private System.Windows.Forms.Label attendanceLabel;
        public System.Windows.Forms.Label NameLabel {
            get { return attendanceLabel; }
            set { attendanceLabel = value; }
        }
        private Emgu.CV.UI.ImageBox camView;
        public Emgu.CV.UI.ImageBox CamView {
            get { return camView;  }
            set { camView = value; }
        }
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel loadingPanel;
        private System.Windows.Forms.PictureBox loadingLogo;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Panel logoTextPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListView studentListView;
        private System.Windows.Forms.ColumnHeader numCol;
        private CircularProgressBar.CircularProgressBar attendancePercentageCircle;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader firstNameCol;
        private System.Windows.Forms.ColumnHeader lastNameCol;
        private System.Windows.Forms.ColumnHeader matNoCol;
    }
}