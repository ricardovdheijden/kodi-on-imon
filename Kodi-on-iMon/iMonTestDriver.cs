using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iMon;

namespace Kodi_on_iMon
{
    public partial class iMonTestDriver : Form
    {
        iMon imon;

        public iMonTestDriver()
        {
            InitializeComponent();
            imon = new iMon();
            txtRefreshRate.Text = Properties.Settings.Default.VfdRefreshRate.ToString();
            txtScrollDelay.Text = Properties.Settings.Default.VfdScrollDelay.ToString();
        }

        private void btnInitialise_Click(object sender, EventArgs e)
        {
            lblStateOutput.Text = imon.initialise();
            tmrFormRefreshRate.Enabled = true;
        }
        private void btnDeinitialise_Click(object sender, EventArgs e)
        {
            lblStateOutput.Text = imon.deinitialise();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            imon.setText(txtInputLine1.Text, txtInputLine2.Text);
        }

        private void tmrFormRefreshRate_Tick(object sender, EventArgs e)
        {
            lblLine1.Text = imon.getVFDText(0);
            lblLine2.Text = imon.getVFDText(1);
        }

        private void btnRefreshRate_Click(object sender, EventArgs e)
        {
            tmrFormRefreshRate.Interval = int.Parse(txtRefreshRate.Text);
            imon.setRefreshRate(int.Parse(txtRefreshRate.Text));
        }

        private void btnScrollDelay_Click(object sender, EventArgs e)
        {
            imon.setScrollDelay(int.Parse(txtScrollDelay.Text));
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.VfdRefreshRate = int.Parse(txtRefreshRate.Text);
            Properties.Settings.Default.VfdScrollDelay = int.Parse(txtScrollDelay.Text);
            Properties.Settings.Default.Save();
        }
    }
}
