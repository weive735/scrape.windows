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

namespace scrape.windows.inspector
{
    public partial class SelectPointForm : Form
    {
        private Point SelectedCusorPoint { get; set; }

        private SelectPointForm(EventWaitHandle waitHandle)
        {
            InitializeComponent();
        }

        private void SelectPointForm_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedCusorPoint = e.Location;
            Close();
        }

        public static Point ShowSelectPointForm(Form owner, double opacity = 0.30)
        {
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);

            var form = new SelectPointForm(waitHandle)
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                Opacity = opacity,
            };

            form.ShowDialog(owner);

            return form.SelectedCusorPoint;
        }
    }
}
