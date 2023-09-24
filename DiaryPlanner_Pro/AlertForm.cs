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
    }
}
