using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiaryPlanner_Pro
{
    public partial class LoadingScreenForm : Form
    {
        public LoadingScreenForm()
        {
            InitializeComponent();
        }

        private void FlashingScreenForm_Load(object sender, EventArgs e)
        {
            // When the form loads, start the background worker.
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // This method runs in a separate background thread.

            for (int i = 0; i <= 100; i++)
            {
                // Simulate a delay of 50 milliseconds to represent work being done.
                System.Threading.Thread.Sleep(50);

                // Increase the value of the progress bar by 1.
                progressBar.Value += 1;

                // Use Invoke to update the 'loadingPercent' label's text from a different thread.
                loadingPercent.Invoke((MethodInvoker)delegate
                {
                    // Update the label text to show the current progress as a percentage.
                    loadingPercent.Text = $"{progressBar.Value} %";
                });
            }

            // This block of code is executed after the progress bar reaches 100%.
            this.Invoke((MethodInvoker)delegate
            {
                // Hide the current form (FlashingScreenForm).
                this.Hide();

                // Create a new instance of the 'LoginForm'.
                var loginForm = new LoginForm();

                // Attach an event handler to the 'FormClosed' event of the 'LoginForm'.
                loginForm.FormClosed += (s, args) => this.Close();

                // Show the 'LoginForm'.
                loginForm.Show();
            });
        }
    }
}
