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
using System.IO;
using Guna.UI2.WinForms;

namespace DiaryPlanner_Pro
{
    public partial class LoginForm : Form
    {
        #region CLASSES

        UserPersonalData userData = new UserPersonalData();
        Functionality functions = new Functionality();
        DBAccess objDBAccess = new DBAccess();

        #endregion

        DataTable dtUserData = new DataTable();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Load the user image and first name from the database.
            GetImageAndFirstName();

            // When the login form loads, center the 'userLabel' horizontally within the 'userPanel'.
            userLabel.Location = new Point((userPanel.Width - userLabel.Width) / 2, userLabel.Location.Y);
        }

        #region FUNCTION FOR LOGIN VALIDATION

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // Iterate through all controls within the 'userPanel' control.
            // Check if the current control is a Guna2TextBox and its text is empty.
            // Display an informational alert message and return early if any textbox is empty.
            foreach (Control control in userPanel.Controls)
                if (control is Guna2TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    functions.Alert("Complete the Requirements", AlertForm.Type.Info);
                    return;
                }

            // If all textboxes are filled, start the loading screen.
            var flashingScreenForm = new FlashingScreenForm();
            flashingScreenForm.ShowDialog();

            // Check the database for login credentials.
            CheckDatabaseToLogin();
        }

        #endregion

        #region FUNCTIONS TO ACCESS THE DATABASE

        #region FUNCTION TO GET THE IMAGE AND FIRST NAME FOR THE LoginForm LOAD

        private void GetImageAndFirstName()
        {
            // Define the SQL query to retrieve the 'Image' and 'FirstName' columns from the 'UserPersonalData' table.
            string query = "SELECT Image, FirstName FROM UserPersonalData";

            // Call a method to execute the SQL query and populate the 'dtUserData' DataTable.
            objDBAccess.readDatathroughAdapter(query, dtUserData);

            // Check if there's exactly one row of data retrieved from the database.
            if (dtUserData.Rows.Count == 1)
            {
                // Retrieve the 'Image' column data as a byte array from the first (and only) row.
                byte[] imageBytes = (byte[])dtUserData.Rows[0]["Image"];

                // Create a MemoryStream to store the image data to the 'Image' property of the 'userData'.
                using (MemoryStream ms = new MemoryStream(imageBytes))
                { 
                    Image image = Image.FromStream(ms);
                    userData.Image = image;
                }

                // Set the 'Image' property of the 'userImage' control to the retrieved image.
                userImage.Image = userData.Image;

                // Retrieve the 'FirstName' column data as a string from the first (and only) row.
                // Update the text of the 'userLabel' control to display a welcome message.
                userData.FirstName = dtUserData.Rows[0]["FirstName"].ToString();
                userLabel.Text = $"Welcome, {userData.FirstName}";
            }

            // Close the database connection here.
            objDBAccess.closeConn();
        }

        #endregion

        #region FUNCTION TO CHECK THE DATABASE TO BE ABLE TO LOGIN

        private void CheckDatabaseToLogin()
        {
            // Define a SQL query to retrieve user data based on provided username and password.
            string query = "SELECT * FROM UserPersonalData WHERE UserName = '" + usernameBox.Text + "' AND Password = '" + passwordBox.Text + "'";
            objDBAccess.readDatathroughAdapter(query, dtUserData);

            // Close the database connection when you're done with it.
            objDBAccess.closeConn();

            // Check if exactly one row of data was retrieved from the database.
            if (dtUserData.Rows.Count == 1)
            {
                // Check if the entered username/password from the database (in userData) are equal, considering character casing.
                bool ifUsername = string.Equals(usernameBox.Text, dtUserData.Rows[0]["UserName"].ToString(), StringComparison.Ordinal);
                bool ifPassword = string.Equals(passwordBox.Text, dtUserData.Rows[0]["Password"].ToString(), StringComparison.Ordinal);

                // If both username and password match (case-sensitive), then the login is successful.
                if (ifUsername && ifPassword)
                {
                    functions.Alert("Logged-In Successfully", AlertForm.Type.Success);

                    // Store the user's retrieved information from the database to the UserPersonalData class.
                    StoreInformation();

                    // Redirect to the main form after the sucessfull logged-in.
                    this.Hide();
                    var MainForm = new MainForm(userData);
                    MainForm.FormClosed += (s, args) => this.Close();
                    MainForm.Show();

                    return; // Exit the method after successful login.
                }
            }

            // Display an error alert message indicating incorrect username or password input.
            functions.Alert("Incorrect Input", AlertForm.Type.Error);
        }

        #endregion

        #endregion

        #region FUNCTION TO STORE THE RETRIEVE DATA FROM THE DATABASE TO THE UserPersonalData CLASS

        private void StoreInformation()
        {
            userData.FirstName = dtUserData.Rows[0]["FirstName"].ToString();
            userData.MiddleName = dtUserData.Rows[0]["MiddleName"].ToString();
            userData.LastName = dtUserData.Rows[0]["LastName"].ToString();
            userData.ExtensionName = dtUserData.Rows[0]["ExtensionName"].ToString();
            userData.Gender = dtUserData.Rows[0]["Gender"].ToString();
            userData.BirthDate = dtUserData.Rows[0]["BirthDate"].ToString();
            userData.GmailAddress = dtUserData.Rows[0]["GmailAddress"].ToString();
            userData.ContactNumber = dtUserData.Rows[0]["ContactNumber"].ToString();
            userData.Username = dtUserData.Rows[0]["Username"].ToString();
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
