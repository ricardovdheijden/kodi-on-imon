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
    public partial class iMonMenu : Form
    {
        iMon imon;
        string[,] menu = { {"item 1", "value 1" }, {"item 2", "value 2" }, {"item 3", "value 3" } };
        int cursorAt = 0;
        
        public iMonMenu()
        {
            InitializeComponent();

            imon = new iMon();
            imon.initialise();
            imon.setRefreshRate(100);
            imon.setScrollDelay(5000);
            refreshScreen();

            tmrFormRefreshRate.Interval = 100;
            tmrFormRefreshRate.Enabled = true;
        }

        // direction 0 = up (cursorAt - 1)
        // direction 1 = down (cursorAt + 1)
        public void scroll(int direction)
        {
            if (direction == 0 && cursorAt > 0)
            {
                cursorAt--;
                refreshScreen();
            }
            else if (direction == 1 && cursorAt < menu.GetLength(0) - 1)
            {
                cursorAt++;
                refreshScreen();
            }
        }

        public void refreshScreen()
        {
            if (cursorAt + 1 < menu.GetLength(0))
            {
                imon.setText("> " + menu[cursorAt, 0], "  " + menu[cursorAt + 1, 0]);
            }
            else
            {
                imon.setText("> " + menu[cursorAt, 0], "");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                scroll(0);
            }
            else if (keyData == Keys.Down)
            {
                scroll(1);
            }
            else if (keyData == Keys.Enter)
            {
                MessageBox.Show("You selected " + menu[cursorAt, 0] + ", which has data " + menu[cursorAt, 1] + " in it.");
                //return true; //possibly not needed
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tmrFormRefreshRate_Tick(object sender, EventArgs e)
        {
            lblLine1.Text = imon.getVFDText(0);
            lblLine2.Text = imon.getVFDText(1);
        }
    }
}
