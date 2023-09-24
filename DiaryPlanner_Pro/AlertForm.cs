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
    public partial class AlertForm : Form
    {
        #region FIELDS AND ENUMS

        private int x, y;

        // Defines a public enumeration named Action with three possible values: wait, start, and close.
        // This enumeration represents different states of the alert form.
        public enum Action
        {
            wait,
            start,
            close
        }

        // Defines a public enumeration named Type with four possible values: Success, Warning, Error, and Info.
        // This enumeration represents different types of alerts.
        public enum Type
        {
            Success,
            Warning,
            Error,
            Info
        }

        private AlertForm.Action action;

        #endregion

        public AlertForm()
        {
            InitializeComponent();
        }

        #region FUNCTION FOR TIMER TICK

        private void timer_Tick(object sender, EventArgs e)
        {
            // Event handler for the Timer's tick event.

            switch (action)
            {
                case Action.wait:
                    // If the action is "wait", set the timer interval to 5 seconds and change the action to "close".
                    timer.Interval = 2500;
                    action = Action.close;
                    break;
                case Action.start:
                    // If the action is "start", set the timer interval to 1 millisecond and gradually increase opacity.
                    timer.Interval = 1;
                    Opacity += 0.1;

                    // Move the form to the left until its X coordinate matches the target X coordinate.
                    if (x < Location.X)
                        Left--;
                    else
                        if (Opacity == 1.0)
                        action = Action.wait;
                    break;
                case Action.close:
                    // If the action is "close", set the timer interval to 1 millisecond and gradually decrease opacity.
                    timer.Interval = 1;
                    Opacity -= 0.1;

                    // Move the form to the left and close it when opacity reaches 0.
                    Left -= 3;
                    if (base.Opacity == 0.0)
                        base.Close();
                    break;
            }
        }

        #endregion
    }
}
