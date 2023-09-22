using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryPlanner_Pro
{
    class UserPersonalData
    {
        public Image Image { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string ExtensionName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }

        private string _gmailAddress;

        public string GmailAddress
        {
            get { return _gmailAddress; }
            set
            {
                // Regular expression pattern for a valid Gmail address.
                string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

                Validate(pattern, ref _gmailAddress, value, "Gmail Address");
            }
        }

        private string _contactNumber;

        public string ContactNumber
        {
            get { return _contactNumber; }
            set
            {
                // Regular expression pattern for a valid Philippine contact number.
                string pattern = @"^(09\d{9}|(\+63|0)[2-8]\d{7})$";

                Validate(pattern, ref _contactNumber, value, "Phone Number");
            }
        }

        // This method is defined to validate a given value against a regular expression pattern.
        // If the value matches the pattern, it's assigned to the specified privateHolder variable.
        // If the value doesn't match, an error message is displayed and the privateHolder variable is set to null.
        public void Validate(string pattern, ref string privateHolder, string value, string name)
        {
            // Check if the provided value matches the specified regular expression pattern.
            if (Regex.IsMatch(value, pattern))
                privateHolder = value; // Assign the value to the privateHolder if it's valid.
            else
            {
                // Display an error message using string interpolation to include the invalid value and the expected type.
                MessageBox.Show($"Invalid {name}", "Diary Planner Pro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                privateHolder = null; // Set the privateHolder to null since the value is invalid.
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
