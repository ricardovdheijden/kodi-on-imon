using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kodi_on_iMon
{
    public partial class iMonIdle : Form
    {
        iMon imon;
        int refreshRate = 500; //500
        int scrollDelay = 5000; //5000

        public iMonIdle()
        {
            string initText = " MediaCenter-PC                 IP: 192.168.1.11";
            init(initText, false);
            //tmrSwapLines.Interval = 5 * ( 2 * scrollDelay + (initText.Length - 16) * refreshRate);
            //tmrSwapLines.Enabled = true;
        }

        public iMonIdle(string textLine1, string textLine2)
        {
            init(textLine1,textLine2);
        }

        public iMonIdle(string textLine, bool swapAfterEveryCycle)
        {

        }
        public iMonIdle(string text)
        {
            init(text, "");
        }

        private void init(string textLine1, string textLine2)
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            notifyIcon.Visible = true;
            this.WindowState = FormWindowState.Minimized;

            imon = new iMon();
            imon.initialise();
            imon.setRefreshRate(refreshRate);
            imon.setScrollDelay(scrollDelay);
            imon.setText(textLine1, textLine2);

            tmrFormRefreshRate.Interval = refreshRate;
            tmrFormRefreshRate.Enabled = true;
        }

        private void init(string textLine, bool swapAfterEveryCycle)
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            notifyIcon.Visible = true;
            this.WindowState = FormWindowState.Minimized;

            imon = new iMon();
            imon.initialise();
            imon.setRefreshRate(refreshRate);
            imon.setScrollDelay(scrollDelay);
            imon.setText(textLine, swapAfterEveryCycle);

            tmrFormRefreshRate.Interval = refreshRate;
            tmrFormRefreshRate.Enabled = true;
        }

        private void tmrFormRefreshRate_Tick(object sender, EventArgs e)
        {
            lblLine1.Text = imon.getVFDText(0);
            lblLine2.Text = imon.getVFDText(1);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void tmrSwapLines_Tick(object sender, EventArgs e)
        {
            //imon.setText(imon.getText(1), imon.getText(0));
        }
    }
}
