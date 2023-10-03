using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DiaryPlanner_Pro
{
    public partial class LoginForm : Form
    {
        #region CLASSES

        UserPersonalData userData = new UserPersonalData();
        Functionality functions = new Functionality();
        DBAccess objDBAccess = new DBAccess();

        #endregion

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            GetImageAndFirstName();

            // When the login form loads, center the 'userLabel' horizontally within the 'userPanel'.
            userLabel.Location = new Point((userPanel.Width - userLabel.Width) / 2, userLabel.Location.Y);
        }

        #region FUNCTIONS TO ACCESS THE DATABASE

        private void GetImageAndFirstName()
        {
            DataTable dtUserData = new DataTable();

            string query = "SELECT Image, FirstName FROM UserPersonalData";
            objDBAccess.readDatathroughAdapter(query, dtUserData);

            if (dtUserData.Rows.Count == 1)
            {
                userData.FirstName = dtUserData.Rows[0]["FirstName"].ToString();
                userLabel.Text = $"Welcome, {userData.FirstName}";
            }
        }

        #endregion

        #region FUNCTIONS FOR DRAGGING FUNCTIONALITY OF FORM

        private void loginFormPanel_MouseMove(object sender, MouseEventArgs e)
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

        private void loginFormPanel_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);

        #endregion

        #region FUNCTION FOR PASSWORD VISIBILITY TOGGLE

        private void passwordBox_IconRightClick(object sender, EventArgs e)
        {
            // This event handler is called when the right icon of the 'passwordBox' control is clicked.

            // If the 'UseSystemPasswordChar' property is true, it means that the password is currently hidden.
            if (passwordBox.UseSystemPasswordChar)
            {
                // Change the right icon to an "open eye" icon.
                passwordBox.IconRight = Properties.Resources.eye__1_;

                // Set the 'PasswordChar' property to '\0' to reveal the actual characters in the password.
                // Set 'UseSystemPasswordChar' to false to indicate that the password is no longer hidden.
                passwordBox.PasswordChar = '\0';
                passwordBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Change the right icon to a "closed eye" icon.
                passwordBox.IconRight = Properties.Resources.eye;

                // Set the 'PasswordChar' property to '●' to hide the actual characters in the password.
                // Set 'UseSystemPasswordChar' to true to indicate that the password should be hidden.
                passwordBox.PasswordChar = '●';
                passwordBox.UseSystemPasswordChar = true;
            }
        }

        #endregion
    }
}
