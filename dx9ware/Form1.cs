using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dx9ware
{
    public partial class Form1 : Form
    {
        private overlay _overlayForm;
        private IntPtr _targetWindowHandle;
        public Form1()
        {
            InitializeComponent();
        }
        // This is overlay shit
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        private void Form1_Load(object sender, EventArgs e)
        {
            // Start Overlay!
            _targetWindowHandle = FindWindow(null, "Roblox");

            if (_targetWindowHandle != IntPtr.Zero)
            {
                _overlayForm = new overlay(_targetWindowHandle);
                _overlayForm.Show();
            }
            else
            {
                MessageBox.Show("Roblox Not Found.");
            }
        }
    }
}
