using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryPlanner_Pro
{
    class UserPersonalData
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        private string _contactNumber;

        public string ContactNumber
        {
            get { return _contactNumber; }
            set
            {
                // Regular expression pattern for a valid Philippine contact number.
                string pattern = @"^(09\d{9}|(\+63|0)[2-8]\d{7})$";

                //Validate(pattern, ref _contactNumber, value, "Phone Number");
            }
        }
    }
}
