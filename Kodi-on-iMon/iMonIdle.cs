﻿using System;
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
        int refreshRate = 500;
        int scrollDelay = 5000;

        public iMonIdle()
        {
            string initText = " MediaCenter-PC                 IP: 192.168.1.11";
            init(initText, true);
        }

        public iMonIdle(string textLine1, string textLine2)
        {
            init(textLine1,textLine2);
        }

        public iMonIdle(string textLine, bool swapAfterEveryCycle)
        {
            init(textLine, swapAfterEveryCycle);
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
    }
}
