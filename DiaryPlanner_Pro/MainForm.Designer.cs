namespace DiaryPlanner_Pro
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.userPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.sidePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dateLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timeLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.selectPictureBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.headTabPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.usernameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.userImage = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.usernameLabelLine = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.loginFormPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.userPanel.SuspendLayout();
            this.sidePanel.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.headTabPanel.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.loginFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // userPanel
            // 
            resources.ApplyResources(this.userPanel, "userPanel");
            this.userPanel.BackColor = System.Drawing.Color.Transparent;
            this.userPanel.BorderColor = System.Drawing.Color.Black;
            this.userPanel.BorderRadius = 10;
            this.userPanel.Controls.Add(this.guna2HtmlLabel2);
            this.userPanel.Controls.Add(this.sidePanel);
            this.userPanel.Controls.Add(this.guna2ControlBox3);
            this.userPanel.Controls.Add(this.panel1);
            this.userPanel.Controls.Add(this.guna2ControlBox2);
            this.userPanel.Controls.Add(this.guna2ControlBox1);
            this.userPanel.FillColor = System.Drawing.Color.White;
            this.userPanel.Name = "userPanel";
            this.userPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseDown);
            this.userPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseMove);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.guna2HtmlLabel2, "guna2HtmlLabel2");
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Indigo;
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            // 
            // sidePanel
            // 
            resources.ApplyResources(this.sidePanel, "sidePanel");
            this.sidePanel.BorderColor = System.Drawing.Color.Transparent;
            this.sidePanel.Controls.Add(this.guna2Panel2);
            this.sidePanel.Controls.Add(this.guna2TabControl1);
            this.sidePanel.Controls.Add(this.headTabPanel);
            this.sidePanel.Name = "sidePanel";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Indigo;
            this.guna2Panel2.Controls.Add(this.dateLabel);
            this.guna2Panel2.Controls.Add(this.timeLabel);
            this.guna2Panel2.Controls.Add(this.selectPictureBtn);
            resources.ApplyResources(this.guna2Panel2, "guna2Panel2");
            this.guna2Panel2.Name = "guna2Panel2";
            // 
            // dateLabel
            // 
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.ForeColor = System.Drawing.Color.Thistle;
            this.dateLabel.Name = "dateLabel";
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.timeLabel, "timeLabel");
            this.timeLabel.ForeColor = System.Drawing.Color.Thistle;
            this.timeLabel.Name = "timeLabel";
            // 
            // selectPictureBtn
            // 
            this.selectPictureBtn.Animated = true;
            this.selectPictureBtn.BorderColor = System.Drawing.Color.White;
            this.selectPictureBtn.BorderRadius = 6;
            this.selectPictureBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.selectPictureBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.selectPictureBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.selectPictureBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.selectPictureBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.selectPictureBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(45)))), ((int)(((byte)(226)))));
            resources.ApplyResources(this.selectPictureBtn, "selectPictureBtn");
            this.selectPictureBtn.ForeColor = System.Drawing.Color.White;
            this.selectPictureBtn.Name = "selectPictureBtn";
            // 
            // guna2TabControl1
            // 
            resources.ApplyResources(this.guna2TabControl1, "guna2TabControl1");
            this.guna2TabControl1.Controls.Add(this.tabPage1);
            this.guna2TabControl1.Controls.Add(this.tabPage5);
            this.guna2TabControl1.Controls.Add(this.tabPage7);
            this.guna2TabControl1.Controls.Add(this.tabPage4);
            this.guna2TabControl1.Controls.Add(this.tabPage2);
            this.guna2TabControl1.Controls.Add(this.tabPage8);
            this.guna2TabControl1.Controls.Add(this.tabPage6);
            this.guna2TabControl1.Controls.Add(this.tabPage3);
            this.guna2TabControl1.ImageList = this.imageList;
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.Purple;
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.LavenderBlush;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.Orchid;
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Indigo;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.Thistle;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.BlueViolet;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.DarkMagenta;
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.LavenderBlush;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.MediumOrchid;
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.Indigo;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            resources.ApplyResources(this.tabPage7, "tabPage7");
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            resources.ApplyResources(this.tabPage8, "tabPage8");
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            resources.ApplyResources(this.tabPage6, "tabPage6");
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "calendar.png");
            this.imageList.Images.SetKeyName(1, "home-icon-silhouette.png");
            this.imageList.Images.SetKeyName(2, "reading-book.png");
            this.imageList.Images.SetKeyName(3, "user.png");
            // 
            // headTabPanel
            // 
            this.headTabPanel.BackColor = System.Drawing.Color.Indigo;
            this.headTabPanel.Controls.Add(this.usernameLabel);
            this.headTabPanel.Controls.Add(this.guna2CustomGradientPanel2);
            this.headTabPanel.Controls.Add(this.usernameLabelLine);
            resources.ApplyResources(this.headTabPanel, "headTabPanel");
            this.headTabPanel.Name = "headTabPanel";
            // 
            // usernameLabel
            // 
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.usernameLabel, "usernameLabel");
            this.usernameLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.usernameLabel.Name = "usernameLabel";
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.BorderRadius = 61;
            this.guna2CustomGradientPanel2.Controls.Add(this.userImage);
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(45)))), ((int)(((byte)(226)))));
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(0)))), ((int)(((byte)(224)))));
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(37)))));
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.guna2CustomGradientPanel2, "guna2CustomGradientPanel2");
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            // 
            // userImage
            // 
            this.userImage.BackColor = System.Drawing.Color.Transparent;
            this.userImage.FillColor = System.Drawing.Color.Transparent;
            this.userImage.Image = global::DiaryPlanner_Pro.Properties.Resources.profile_gradient;
            this.userImage.ImageRotate = 0F;
            resources.ApplyResources(this.userImage, "userImage");
            this.userImage.Name = "userImage";
            this.userImage.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.userImage.TabStop = false;
            this.userImage.UseTransparentBackground = true;
            // 
            // usernameLabelLine
            // 
            this.usernameLabelLine.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabelLine.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(101)))), ((int)(((byte)(190)))));
            resources.ApplyResources(this.usernameLabelLine, "usernameLabelLine");
            this.usernameLabelLine.Name = "usernameLabelLine";
            // 
            // guna2ControlBox3
            // 
            resources.ApplyResources(this.guna2ControlBox3, "guna2ControlBox3");
            this.guna2ControlBox3.Animated = true;
            this.guna2ControlBox3.BorderRadius = 10;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Name = "panel1";
            // 
            // guna2ControlBox2
            // 
            resources.ApplyResources(this.guna2ControlBox2, "guna2ControlBox2");
            this.guna2ControlBox2.Animated = true;
            this.guna2ControlBox2.BorderRadius = 10;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            // 
            // guna2ControlBox1
            // 
            resources.ApplyResources(this.guna2ControlBox1, "guna2ControlBox1");
            this.guna2ControlBox1.Animated = true;
            this.guna2ControlBox1.BorderRadius = 10;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.White;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            // 
            // loginFormPanel
            // 
            this.loginFormPanel.Controls.Add(this.userPanel);
            resources.ApplyResources(this.loginFormPanel, "loginFormPanel");
            this.loginFormPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(45)))), ((int)(((byte)(226)))));
            this.loginFormPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(0)))), ((int)(((byte)(224)))));
            this.loginFormPanel.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(37)))));
            this.loginFormPanel.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.loginFormPanel.Name = "loginFormPanel";
            this.loginFormPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseDown);
            this.loginFormPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.formPanel_MouseMove);
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginFormPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.sidePanel.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2TabControl1.ResumeLayout(false);
            this.headTabPanel.ResumeLayout(false);
            this.headTabPanel.PerformLayout();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.loginFormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel loginFormPanel;
        private Guna.UI2.WinForms.Guna2Panel userPanel;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage6;
        private Guna.UI2.WinForms.Guna2Panel headTabPanel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox userImage;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2Panel sidePanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel usernameLabel;
        private Guna.UI2.WinForms.Guna2Separator usernameLabelLine;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2GradientButton selectPictureBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel timeLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel dateLabel;
        private System.Windows.Forms.Timer timerTick;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}