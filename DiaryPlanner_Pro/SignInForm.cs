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
    public partial class SignInForm : Form
    {
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

    }
}
