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
    public partial class iMonMenu : Form
    {
        iMon imon;
        string[] menu = {"item 1","item 2","item 3","item 4","item 5", "item 6", "item 7", "item 8"};
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
            else if (direction == 1 && cursorAt < menu.Length - 1)
            {
                cursorAt++;
                refreshScreen();
            }
        }

        public void refreshScreen()
        {
            if (cursorAt + 1 < menu.Length)
            {
                imon.setText("> " + menu[cursorAt], "  " + menu[cursorAt + 1]);
            }
            else
            {
                imon.setText("> " + menu[cursorAt], "");
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
                MessageBox.Show("You pressed Enter key");
                return true;
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
