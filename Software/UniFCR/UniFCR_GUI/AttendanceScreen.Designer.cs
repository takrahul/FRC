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
            this.uniFCRLogoBox = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.camPanel = new System.Windows.Forms.Panel();
            this.camView = new Emgu.CV.UI.ImageBox();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.logoTextPanel = new System.Windows.Forms.Panel();
            this.loadingLogo = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
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
            this.mainPanel.Size = new System.Drawing.Size(1198, 626);
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
            this.sidePanel.Size = new System.Drawing.Size(198, 626);
            this.sidePanel.TabIndex = 6;
            // 
            // infoPanel
            // 
            this.infoPanel.ColumnCount = 1;
            this.infoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.infoPanel.Controls.Add(this.uniFCRLogoBox, 0, 0);
            this.infoPanel.Controls.Add(this.nameLabel, 0, 2);
            this.infoPanel.Controls.Add(this.titleLabel, 0, 1);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.RowCount = 3;
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.infoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.infoPanel.Size = new System.Drawing.Size(198, 556);
            this.infoPanel.TabIndex = 0;
            // 
            // uniFCRLogoBox
            // 
            this.uniFCRLogoBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uniFCRLogoBox.Image = ((System.Drawing.Image)(resources.GetObject("uniFCRLogoBox.Image")));
            this.uniFCRLogoBox.Location = new System.Drawing.Point(24, 3);
            this.uniFCRLogoBox.MaximumSize = new System.Drawing.Size(150, 150);
            this.uniFCRLogoBox.MinimumSize = new System.Drawing.Size(10, 10);
            this.uniFCRLogoBox.Name = "uniFCRLogoBox";
            this.uniFCRLogoBox.Size = new System.Drawing.Size(150, 150);
            this.uniFCRLogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uniFCRLogoBox.TabIndex = 3;
            this.uniFCRLogoBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F);
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(128)))));
            this.nameLabel.Location = new System.Drawing.Point(3, 483);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(192, 70);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name goes Here";
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(5, 156);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(188, 324);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "UniFCR";
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.White;
            this.buttonPanel.Controls.Add(this.backButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 556);
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
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.DarkGray;
            this.backButton.Location = new System.Drawing.Point(0, 0);
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
            this.camPanel.Size = new System.Drawing.Size(1000, 626);
            this.camPanel.TabIndex = 0;
            this.camPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.camPanel_Paint);
            // 
            // camView
            // 
            this.camView.BackColor = System.Drawing.Color.DarkGray;
            this.camView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.camView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camView.Location = new System.Drawing.Point(0, 0);
            this.camView.Name = "camView";
            this.camView.Size = new System.Drawing.Size(1000, 626);
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
            this.loadingPanel.Size = new System.Drawing.Size(1198, 626);
            this.loadingPanel.TabIndex = 6;
            this.loadingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.loadingPanel_Paint);
            // 
            // logoTextPanel
            // 
            this.logoTextPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoTextPanel.Controls.Add(this.loadingLogo);
            this.logoTextPanel.Controls.Add(this.loadingLabel);
            this.logoTextPanel.Location = new System.Drawing.Point(406, 156);
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
            // AttendanceScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 626);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.loadingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Label nameLabel;
        private Emgu.CV.UI.ImageBox camView;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel loadingPanel;
        private System.Windows.Forms.PictureBox loadingLogo;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Panel logoTextPanel;
        private System.Windows.Forms.Label titleLabel;
    }
}