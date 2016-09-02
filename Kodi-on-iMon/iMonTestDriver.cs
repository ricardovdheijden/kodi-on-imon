﻿using System;
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
            lblLine1.Text = imon.getText(0);
            lblLine2.Text = imon.getText(1);
        }

        private void btnRefreshRate_Click(object sender, EventArgs e)
        {
            
        }
    }
}