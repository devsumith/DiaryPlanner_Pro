using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryPlanner_Pro
{
    class Functionality
    {
        #region FUNCTION TO COMPARE TWO IMAGES

        public bool ImageEquals(Image image1, Image image2)
        {
            // Enter a using block to ensure proper disposal of resources
            using (MemoryStream ms1 = new MemoryStream(), ms2 = new MemoryStream())
            {
                // Save the content of the first and second image to the MemoryStream ms1 and ms2.
                image1.Save(ms1, image1.RawFormat);
                image2.Save(ms2, image2.RawFormat);

                // Return the result of the comparison between the byte arrays obtained from ms1 and ms2
                // StructuralComparisons.StructuralEqualityComparer.Equals() is used to compare the arrays
                return StructuralComparisons.StructuralEqualityComparer.Equals(ms1.ToArray(), ms2.ToArray());
            }
        }

        #endregion

        #region FUNCTION TO DISPLAY ALERT

        // This method is used to display an alert message using a custom AlertForm.
        public void Alert(string msg, AlertForm.Type type)
        {
            AlertForm alertForm = new AlertForm();

            // Call the ShowAlert method of the AlertForm instance, passing the message and alert type as parameters.
            alertForm.ShowAlert(msg, type);
        }

        #endregion

        #region FUNCTION TO CONVERT THE IMAGE INTO BYTE ARRAY

        // This method retrieves the byte array representation of a student's image.
        public byte[] getPhoto(Image studentImage)
        {
            // Create a new memory stream to store the image data.
            MemoryStream stream = new MemoryStream();

            // Save the student's image to the memory stream using the original image format.
            studentImage.Save(stream, studentImage.RawFormat);

            // Get the byte array representation of the image data from the memory stream.
            return stream.GetBuffer();
        }

        #endregion
    }
}
