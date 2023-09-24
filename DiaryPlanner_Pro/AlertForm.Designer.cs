namespace DiaryPlanner_Pro
{
    partial class AlertForm
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.noticeLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.removeBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.containerControl = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.containerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Bahnschrift", 14.25F);
            this.labelMessage.ForeColor = System.Drawing.Color.White;
            this.labelMessage.Location = new System.Drawing.Point(59, 50);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(124, 23);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Message Text";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // noticeLabel
            // 
            this.noticeLabel.BackColor = System.Drawing.Color.Transparent;
            this.noticeLabel.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.noticeLabel.ForeColor = System.Drawing.Color.White;
            this.noticeLabel.Location = new System.Drawing.Point(14, 4);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(49, 21);
            this.noticeLabel.TabIndex = 1;
            this.noticeLabel.Text = "Notice";
            // 
            // removeBtn
            // 
            this.removeBtn.BackColor = System.Drawing.Color.Transparent;
            this.removeBtn.CustomClick = true;
            this.removeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.removeBtn.FillColor = System.Drawing.Color.Transparent;
            this.removeBtn.IconColor = System.Drawing.Color.White;
            this.removeBtn.Location = new System.Drawing.Point(328, 0);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(39, 31);
            this.removeBtn.TabIndex = 0;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // containerControl
            // 
            this.containerControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(118)))), ((int)(((byte)(236)))));
            this.containerControl.Controls.Add(this.noticeLabel);
            this.containerControl.Controls.Add(this.removeBtn);
            this.containerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerControl.FillColor = System.Drawing.Color.Empty;
            this.containerControl.Location = new System.Drawing.Point(0, 0);
            this.containerControl.Name = "containerControl";
            this.containerControl.Size = new System.Drawing.Size(367, 31);
            this.containerControl.TabIndex = 4;
            this.containerControl.Text = "guna2ContainerControl1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DiaryPlanner_Pro.Properties.Resources.informationLogo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // AlertForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(171)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(367, 101);
            this.Controls.Add(this.containerControl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelMessage);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form_Alert";
            this.TopMost = true;
            this.containerControl.ResumeLayout(false);
            this.containerControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Timer timer;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ContainerControl containerControl;
        private Guna.UI2.WinForms.Guna2HtmlLabel noticeLabel;
        private Guna.UI2.WinForms.Guna2ControlBox removeBtn;
    }
}