using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                        MessageBox.Show("Select a Square Image", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ValidateInformation();
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

                            MessageBox.Show("Select your Formal Picture", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                            MessageBox.Show("Select your gender", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        {
                            if (panelControl is Guna2ComboBox comboBox)
                            {
                                if (comboBox.SelectedIndex == 0)
                                {
                                    birthdateWarning.Visible = true;

                                    MessageBox.Show("Complete your birth date", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
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

                            MessageBox.Show($"Enter your password", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        else
                        {
                            if (strength <= 2)
                            {
                                textBox.IconLeft = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                                textBox.Focus();

                                MessageBox.Show($"Password must be moderate or strong", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            else
                                textBox.IconLeft = null;
                        }
                        break;
                    // Handling other Guna2TextBox controls : LastNameBox, FirstNameBox, MiddleNameBox
                    case Guna2TextBox textBox:
                        if (String.IsNullOrEmpty(textBox.Text))
                        {
                            textBox.IconRight = DiaryPlanner_Pro.Properties.Resources.warningLogo;
                            textBox.Focus();

                            MessageBox.Show($"Enter your {textBox.PlaceholderText}", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            return true;
        }

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

                MessageBox.Show($"Enter your valid {fieldName}", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    }
}
