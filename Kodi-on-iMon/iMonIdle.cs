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

        public iMonIdle()
        {
            init(" MediaCenter-PC                 IP: 192.168.1.11", "");   
        }

        public iMonIdle(string textLine1, string textLine2)
        {
            init(textLine1,textLine2);
        }

        public iMonIdle(string text)
        {
            init(text, "");
        }

        private void init(string textLine1, string textLine2)
        {
            InitializeComponent();

            imon = new iMon();
            imon.initialise();
            imon.setRefreshRate(500);
            imon.setScrollDelay(5000);
            imon.setText(textLine1, textLine2);

            tmrFormRefreshRate.Interval = 500;
            tmrFormRefreshRate.Enabled = true;
        }

        private void tmrFormRefreshRate_Tick(object sender, EventArgs e)
        {
            lblLine1.Text = imon.getVFDText(0);
            lblLine2.Text = imon.getVFDText(1);
        }
    }
}
