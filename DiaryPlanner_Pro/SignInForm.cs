using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryPlanner_Pro
{
    public partial class SignInForm : Form
    {
        #region CLASSES

        // Instance of class that will store the validated data.
        UserPersonalData userPersonalData = new UserPersonalData();
        Functionality functions = new Functionality();

        #endregion

        #region FIELDS

        int strength;

        #endregion

        public SignInForm()
        {
            InitializeComponent();
        }

        #region FUNCTIONS FOR PASSWORD AND CONFIRM PASSWORD BOX VISIBILITY TOGGLE

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

        private void conPasswordBox_IconRightClick(object sender, EventArgs e)
        {
            // This event handler is called when the right icon of the 'conPasswordBox' control is clicked.

            // If the 'UseSystemPasswordChar' property is true, it means that the password is currently hidden.
            if (conPasswordBox.UseSystemPasswordChar)
            {
                // Change the right icon to an "open eye" icon.
                conPasswordBox.IconRight = Properties.Resources.eye__1_;

                // Set the 'PasswordChar' property to '\0' to reveal the actual characters in the password.
                // Set 'UseSystemPasswordChar' to false to indicate that the password is no longer hidden.
                conPasswordBox.PasswordChar = '\0';
                conPasswordBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Change the right icon to a "closed eye" icon.
                conPasswordBox.IconRight = Properties.Resources.eye;

                // Set the 'PasswordChar' property to '●' to hide the actual characters in the password.
                // Set 'UseSystemPasswordChar' to true to indicate that the password should be hidden.
                conPasswordBox.PasswordChar = '●';
                conPasswordBox.UseSystemPasswordChar = true;
            }
        }

        #endregion

        #region FUNCTIONS FOR STRONG PASSWORD INDICATOR

        private async void passwordBox_TextChanged(object sender, EventArgs e)
        {
            // Retrieve the entered password.
            string password = passwordBox.Text;

            // Check if the password length is less than or equal to 6 characters.
            if (password.Length <= 6)
            {
                // If it is, display a message indicating that a minimum of 6 characters is required.
                strengthLabel.Text = "Minimum 6 characters";
                strengthLabel.ForeColor = Color.Gray;

                strength = 0;
                return;
            }

            // Use Task.Run to perform the strength evaluation asynchronously.
            strength = await Task.Run(() => CalculatePasswordStrength(password));

            // Update the UI to reflect the password strength.
            UpdateStrengthLabel(strength);
        }

        private int CalculatePasswordStrength(string password)
        {
            int length = password.Length;
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;
                else if (char.IsLower(c))
                    hasLowerCase = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
                else if (char.IsSymbol(c) || char.IsPunctuation(c))
                    hasSpecialChar = true;
            }

            int strength = 0;

            // Calculate the password strength based on criteria.
            // Criteria: Length, Uppercase, Lowercase, Digit, Special Character
            if (length >= 8)
                strength++;
            if (hasUpperCase)
                strength++;
            if (hasLowerCase)
                strength++;
            if (hasDigit)
                strength++;
            if (hasSpecialChar)
                strength++;


            return strength;
        }

        private void UpdateStrengthLabel(int strength)
        {
            // Update the UI to reflect the password strength.
            if (strength <= 2)
            {
                // If the strength is low, display a weak password message in red.
                strengthLabel.Text = "Password is weak";
                strengthLabel.ForeColor = Color.DarkRed;
            }
            else if (strength <= 4)
            {
                // If the strength is moderate, display a moderate password message in blue.
                strengthLabel.Text = "Password is moderate";
                strengthLabel.ForeColor = Color.RoyalBlue;
            }
            else
            {
                // If the strength is strong, display a strong password message in green.
                strengthLabel.Text = "Password is strong";
                strengthLabel.ForeColor = Color.Green;
            }
        }

        #endregion

        #region FUNCTIONS TO SELECT PHOTO WITH VALIDATION BY CLICKING A BUTTON

        private void selectPictureBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to allow only JPEG and PNG image files.
            openFileDialog.Filter = "Image Files|*.jpeg;*.jpg;*.png|All Files|*.*";

            // To handle any exceptions that might occur during the process.
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap selectedImage = new Bitmap(openFileDialog.FileName);

                    // Check if the loaded image is square using the IsSquareImage function.
                    // If the image is square, set it as the student's picture.
                    // Else, display a warning message.
                    if (IsSquareImage(selectedImage))
                    {
                        userPictureBox.Image = selectedImage;
                    }
                    else
                        functions.Alert("Select a square image", AlertForm.Type.Info);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting photo: {ex.Message}", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // This method checks if an image is square based on its width and height.
        private bool IsSquareImage(Bitmap image) => image.Width == image.Height;

        #endregion

        #region FUNCTION FOR VALIDATING THE INFORMATION BEFORE THE APPROVAL OF SUBMISSION

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (ValidateInformation())
            {
                
            }
        }

        #region FUNCTION FOR INFORMATION'S VALIDATION

        private bool ValidateInformation()
        {
            bool ifReturn = true;

            #region LIST OF CONTROLS THAT CONTAIN INFORMATION TO BE VALIDATED

            List<Control> controlList = new List<Control>
            {
                lastNameBox,
                firstNameBox,
                middleNameBox,
                genderPanel,
                birthdatePanel,
                gmailAddressBox,
                contactNumberBox,
                userPictureBox,
                usernameBox,
                passwordBox,
                conPasswordBox
            };

            #endregion

            // Loop through each control in controlList to be validated.
            foreach (Control control in controlList)
            {
                switch (control)
                {
                    // Handling user picture
                    case PictureBox pictureBox when pictureBox == userPictureBox:
                        // If user picture is empty, show an error message. Return false to indicate validation failure.
                        // Else, store the user picture in user personal data.
                        if (functions.ImageEquals(pictureBox.Image, DiaryPlanner_Pro.Properties.Resources.profile_gradient))
                        {
                            pictureWarning.Visible = true;

                            functions.Alert("Select your formal picture", AlertForm.Type.Error);
                            return false;
                        }
                        else
                        {
                            userPersonalData.Image = pictureBox.Image;
                            pictureWarning.Visible = false;
                        }
                        break;
                    // Handling gender selection
                    case Guna2Panel panel when panel == genderPanel:
                        // If user selected gender is empty, show an error message. Return false to indicate validation failure.
                        // Else, set gender in user personal data.
                        if (!maleBtn.Checked && !femaleBtn.Checked)
                        {
                            genderWarning.Visible = true;

                            functions.Alert("Select your gender", AlertForm.Type.Error);
                            return false;
                        }
                        else
                        {
                            userPersonalData.Gender = (maleBtn.Checked) ? "Male" : "Female";
                            genderWarning.Visible = false;
                        }
                        break;
                    // Handling birthdate selection
                    case Guna2Panel panel when panel == birthdatePanel:
                        // If user selected birthdate is empty, show an error message. Return false to indicate validation failure.
                        // Else, set birthdate in user personal data.
                        foreach (Control panelControl in panel.Controls)
                            if (panelControl is Guna2ComboBox comboBox)
                                if (comboBox.SelectedIndex == 0)
                                {
                                    birthdateWarning.Visible = true;

                                    functions.Alert("Complete your birth date", AlertForm.Type.Error);
                                    return false;
                                }

                        birthdateWarning.Visible = false;
                        break;
                    // Handling the validation of gmail address
                    case Guna2TextBox textBox when textBox == gmailAddressBox:
                        ifReturn = ValidateAndAssign(textBox, userPersonalData, "Gmail address", "GmailAddress");
                        break;
                    // Handling the validation of gmail address
                    case Guna2TextBox textBox when textBox == contactNumberBox:
                        ifReturn = ValidateAndAssign(textBox, userPersonalData, "phone number", "ContactNumber");
                        break;
                    // Handling the validation of password strength
                    case Guna2TextBox textBox when textBox == passwordBox:
                        if (String.IsNullOrEmpty(passwordBox.Text))
                        {
                            textBox.IconLeft = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                            textBox.Focus();

                            functions.Alert("Enter your desired password", AlertForm.Type.Error);
                            return false;
                        }
                        else
                        {
                            // Check the length of the password, to ensure that it is six or above characters
                            if (passwordBox.Text.Length < 6)
                            {
                                textBox.IconLeft = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                                textBox.Focus();

                                functions.Alert("Minimum 6 characters", AlertForm.Type.Info);
                                return false;
                            }
                            else
                            {
                                // Check the strength of the password if it's weak
                                if (strength <= 2)
                                {
                                    textBox.IconLeft = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                                    textBox.Focus();

                                    functions.Alert("Must be moderate or strong", AlertForm.Type.Info);
                                    return false;
                                }
                                else
                                    textBox.IconLeft = null;
                            }
                        }
                        break;
                    // Handling the validation of password confirmation
                    case Guna2TextBox textBox when textBox == conPasswordBox:
                        if (String.IsNullOrEmpty(conPasswordBox.Text))
                        {
                            textBox.IconLeft = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                            textBox.Focus();

                            functions.Alert("Enter the password confirmation", AlertForm.Type.Error);
                            return false;
                        }
                        else
                        {
                            // Check if the confirmation password does not match the original password
                            if (conPasswordBox.Text != passwordBox.Text)
                            {
                                textBox.IconLeft = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                                textBox.Focus();

                                functions.Alert("Password does not match", AlertForm.Type.Error);
                                return false;
                            }
                            else
                            {
                                textBox.IconLeft = null;

                                // Set the password in userPersonalData to the password entered in the original password box
                                userPersonalData.Password = passwordBox.Text;
                            }
                        }
                        break;
                    // Handling other Guna2TextBox controls : LastNameBox, FirstNameBox, MiddleNameBox
                    case Guna2TextBox textBox:
                        if (String.IsNullOrEmpty(textBox.Text))
                        {
                            textBox.IconRight = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                            textBox.Focus();

                            functions.Alert($"Enter your {textBox.PlaceholderText}", AlertForm.Type.Error);
                            return false;
                        }
                        else
                            textBox.IconRight = null;
                        break;
                }

                // If above statement return a false value for ifReturn, this statement will return false to indicate validation failure.
                if (!ifReturn)
                    return false;
            }

            // TO PASS THE REMAINING INFORMATION
            PassingInformation();
            return true;
        }

        #region FUNCTION FOR STORING THE REMAINING INFORMATION TO THE CLASS.

        private void PassingInformation()
        {
            userPersonalData.LastName = lastNameBox.Text;
            userPersonalData.FirstName = firstNameBox.Text;
            userPersonalData.MiddleName = middleNameBox.Text;
            userPersonalData.ExtensionName = extensionNameCBox.Text;
            userPersonalData.BirthDate = $"{monthBox.Text} {dayBox.Text}, {yearBox.Text}";
            userPersonalData.Username = usernameBox.Text;
        }

        #endregion

        #endregion

        #region FUNCTION TO VALIDATE GMAIL ADDRESS AND CONTACT NUMBER

        private bool ValidateAndAssign(Guna2TextBox textBox, UserPersonalData userData, string fieldName, string property)
        {
            string input = textBox.Text;

            // Show an error message using the field name if the input is null or empty, then focus on the textbox and return true (indicating validation failure)
            if (string.IsNullOrEmpty(input))
            {
                textBox.IconRight = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                textBox.Focus();

                functions.Alert($"Enter your valid {fieldName}", AlertForm.Type.Error);
                return false;
            }
            else
            {
                // Using reflection, set the value of the specified property in the 'userData' object to the 'input'
                userData.GetType().GetProperty(property).SetValue(userData, input);

                // Using reflection, get the value of the specified property in the 'userData' object,
                // convert it to a string, check if it's empty or null
                if (string.IsNullOrEmpty(userData.GetType().GetProperty(property).GetValue(userData) as string))
                {
                    textBox.IconRight = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                    textBox.Focus();

                    return false;
                }
                else
                    textBox.IconRight = null;
            }

            return true;
        }

        #endregion

        #endregion

        #region FUNCTION TO ACCESS THE DATABASE AND STORE THE USER'S INFORMATION

        private void DatabaseAccessAsync()
        {
            DBAccess objDBAccess = new DBAccess(); // Create an instance of the DBAccess class for database operations.

            SqlCommand insertCommand = new SqlCommand("INSERT INTO UserPersonalData (Image, LastName, FirstName, ExtensionName, Gender, BirthDate, GmailAddress, ContactNumber, UserName, Password) VALUES (@Image, @LastName, @FirstName, @ExtensionName, @Gender, @BirthDate, @GmailAddress, @ContactNumber, @UserName, @Password");

            // Add parameters to the insert command with values from UserPersonalData.
            // Parameters are placeholders for data that will be inserted into the database.
            insertCommand.Parameters.AddWithValue("@UserPhoto", functions.getPhoto(userPersonalData.Image));
            insertCommand.Parameters.AddWithValue("@LastName", userPersonalData.LastName);
            insertCommand.Parameters.AddWithValue("@FirstName", userPersonalData.FirstName);
            insertCommand.Parameters.AddWithValue("@MiddleName", userPersonalData.MiddleName);
            insertCommand.Parameters.AddWithValue("@ExtensionName", userPersonalData.ExtensionName);
            insertCommand.Parameters.AddWithValue("@Gender", userPersonalData.Gender);
            insertCommand.Parameters.AddWithValue("@BirthDate", userPersonalData.BirthDate);
            insertCommand.Parameters.AddWithValue("@GmailAddress", userPersonalData.GmailAddress);
            insertCommand.Parameters.AddWithValue("@ContactNumber", userPersonalData.ContactNumber);
            insertCommand.Parameters.AddWithValue("@UserName", userPersonalData.Username);
            insertCommand.Parameters.AddWithValue("@Password", userPersonalData.Password);

            // Execute the insert command to insert data into the database.
            int row = objDBAccess.executeQuery(insertCommand);

            if (row == 1)
            {
                // If the insertion was successful, display a success message.
                functions.Alert("Finalized Successfully", AlertForm.Type.Success);
                objDBAccess.closeConn(); // Close the database connection.
            }
            else // If the insertion failed, display an error message and enable the finalizeAllBtn.
                functions.Alert("Error Occured. Try Again!", AlertForm.Type.Error);
        }

        #endregion

        #region FUNCTIONS FOR DRAGGING FUNCTIONALITY OF FORM

        private void dragControls_MouseMove(object sender, MouseEventArgs e)
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

        private void dragControls_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);

        #endregion
    }
}
