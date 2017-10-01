using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scrape.windows.inspector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInspect_Click(object sender, EventArgs e)
        {
            var point = SelectPointForm.ShowSelectPointForm(this);

            var winHandle = Win32API.WindowFromPoint(new POINT { X = point.X, Y = point.Y });
            var info = WindowUtil.GetWindowInfo(winHandle);

            var msg =
$@"Handle: {info.WindowHandle}
ClassName: {info.ClassName}
Title: {info.Title}
Style: {info.Style}
PointXY: [{point.X}, {point.Y}]";

            MessageBox.Show(msg);
        }
    }
}
