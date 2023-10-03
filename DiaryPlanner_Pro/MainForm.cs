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
        private UserPersonalData userData;

        public MainForm(UserPersonalData userData)
        {
            InitializeComponent();

            this.userData = userData;
        }

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
