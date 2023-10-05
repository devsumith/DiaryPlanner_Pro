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

        #region BASIC FEATURES FUNCTIONALITY

        #region FUNCTION TO UPDATE THE TIME AND DATE LABEL EVERY 100 MILLISECONDS 

        private void timerTick_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToShortTimeString();
            dateLabel.Text = DateTime.Now.ToShortDateString();
        }

        #endregion

        #region FUNCTION TO LOGOUT THE USER'S ACCOUNT

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            // If all textboxes are filled, start the loading screen.
            var flashingScreenForm = new FlashingScreenForm();
            flashingScreenForm.ShowDialog();

            // Redirect to the login form after the sucessfull logged-out.
            this.Hide();
            var LoginForm = new LoginForm();
            LoginForm.FormClosed += (s, args) => this.Close();
            LoginForm.Show();
        }

        #endregion

        #endregion
    }
}
