using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryPlanner_Pro
{
    public partial class MainForm : Form
    {
        #region FIELDS

            private UserPersonalData userData;

        #endregion

        public MainForm(UserPersonalData userData)
        {
            InitializeComponent();

            this.userData = userData;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadUserInformation();
        }

        #region FUNCTION TO LOAD THE USER'S INFORMATION

        private void LoadUserInformation()
        {
            userImage.Image = userData.Image;
            usernameLabel.Text = $"{userData.LastName}, {userData.FirstName}";

            // When the login form loads, center the 'usernameLabel' horizontally within the 'usernameLabel'.
            usernameLabel.Location = new Point((headTabPanel.Width - usernameLabel.Width) / 2, usernameLabel.Location.Y);

            // Align the usernameLabelLine to the usernameLabel in size and location.
            usernameLabelLine.Size = new Size(usernameLabel.Width, usernameLabelLine.Height);
            usernameLabelLine.Location = new Point((headTabPanel.Width - usernameLabelLine.Width) / 2, usernameLabelLine.Location.Y);
        }

        #endregion

        #region FUNCTION TO UPDATE THE TIME AND DATE LABEL EVERY 100 MILLISECONDS 

        private void timerTick_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToShortTimeString();
            dateLabel.Text = DateTime.Now.ToShortDateString();
        }

        #endregion

        #region FUNCTIONS FOR DRAGGING FUNCTIONALITY OF FORM

        private void formPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is held down (mouse is being dragged).
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the new position of the form based on the mouse movement.
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        Point lastPoint;

        private void formPanel_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);

        #endregion
    }
}
