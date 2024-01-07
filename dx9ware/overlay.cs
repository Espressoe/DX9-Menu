using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dx9ware
{
    public partial class overlay : Form
    {
        private Point point1;
        private IntPtr _targetWindowHandle;
        public overlay(IntPtr targetWindowHandle)
        {
            InitializeComponent();
            _targetWindowHandle = targetWindowHandle;

            // Start Overlay
            var targetWindowRect = GetWindowRect(_targetWindowHandle);
            Width = targetWindowRect.Width;
            Height = targetWindowRect.Height;
            Left = targetWindowRect.Left;
            Top = targetWindowRect.Top;
            timer1.Start();
            controls.Start();
        }
        private static Rectangle GetWindowRect(IntPtr windowHandle)
        {
            NativeMethods.GetWindowRect(windowHandle, out var rect);
            return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Main UI Toggle
            guna2Button15.Visible = true;
            UI.Visible = false;
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Drag (i have no idea where i got this from, j ust found in an old project)
            point1 = new Point(e.X, e.Y);
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // Drag (i have no idea where i got this from, j ust found in an old project)
            if (e.Button == MouseButtons.Left)
            {
                UI.Left = e.X + UI.Left - point1.X;
                UI.Top = e.Y + UI.Top - point1.Y;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Overlay System Refresh
            var targetWindowRect = GetWindowRect(_targetWindowHandle);
            Width = targetWindowRect.Width;
            Height = targetWindowRect.Height;
            Left = targetWindowRect.Left;
            Top = targetWindowRect.Top;
            // Optional Slider Controls
            if (guna2ToggleSwitch12.Checked == true)
            {
                guna2TrackBar1.Visible = true;
            }
            else
            {
                guna2TrackBar1.Visible = false;
            }
            if (guna2ToggleSwitch17.Checked == true)
            {
                guna2TrackBar2.Visible = true;
            }
            else
            {
                guna2TrackBar2.Visible = false;
            }
        }

        private void controls_Tick(object sender, EventArgs e)
        {
            //Color Dialog Controls
            guna2Button7.FillColor = ESPcolor.Color;
            guna2Button8.FillColor = TraceColor.Color;
            guna2Button9.FillColor = HealthColor.Color;
            guna2Button10.FillColor = PlayerColor.Color;
            guna2Button11.FillColor = SkeletonColor.Color;
            guna2Button12.FillColor = BackgroundColor.Color;
            guna2Button13.FillColor = ChamsColors.Color;

            //Page Controls
            if (guna2Button1.Checked == true)
            {
                panel7.Visible = true;
            }
            else
            {
                panel7.Visible = false;
            }
            if (guna2Button2.Checked == true)
            {
                panel20.Visible = true;
            }
            else
            {
                panel20.Visible = false;
            }
            if (guna2Button6.Checked == true)
            {
                panel22.Visible = true;
            }
            else
            {
                panel22.Visible = false;
            }
            // Slider Value Controls
            rangeLabel.Text = aimbotrange.Value.ToString();
            fovlabel.Text = fovsize.Value.ToString();
            xlabel.Text = xvalue.Value.ToString();
            ylabel.Text = yvalue.Value.ToString();
            smoothlabel.Text = smoothness.Value.ToString();
            senselabel.Text = sense.Value.ToString();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ESPcolor.ShowDialog();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            TraceColor.ShowDialog();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            HealthColor.ShowDialog();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            PlayerColor.ShowDialog();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            SkeletonColor.ShowDialog();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            ChamsColors.ShowDialog();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            BackgroundColor.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            // Toggle UI Control
            guna2Button15.Visible = false;
            UI.Visible = true;
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            // Exit Control
            Environment.Exit(0);
        }
    }
}
































































// THIS WAS MADE BY espresso0069 on discord
