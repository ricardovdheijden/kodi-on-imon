using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iMon.DisplayApi;

namespace Kodi_on_iMon
{
    public partial class iMonWindow : Form
    {
        private uint WM_COMMAND = 12345;
        private String previousToVfdScreenLine1 = ""; //The 16 positions long string that is sent to VFD perviously
        private String previousToVfdScreenLine2 = "";
        private String strToVfdLine1 = ""; //The full string that needs to be sent to VFD (can ben longer than 16)
        private String strToVfdLine2 = "";
        private String strToVfdScreenLine1 = ""; //The 16 positions long string that is sent to VFD
        private String strToVfdScreenLine2 = "";
        private int intStartPosToVfdScreenLine1 = 0; //Start index of the visible part of the string on VFD
        private int intStartPosToVfdScreenLine2 = 0;
        private int intScrollStateLine1 = 0;
        private int intScrollStateLine2 = 0;
        private int counter = 1;

        public iMonWindow()
        {
            InitializeComponent();
        }

        private String initialiseVFD()
        {
            iMonNativeApi.iMonDisplayResult result = iMonNativeApi.IMON_Display_Init(this.Handle, (WM_COMMAND));
            String strResult = result.ToString();
            return strResult;
        }

        private String deInitialiseVFD()
        {
            iMonNativeApi.iMonDisplayResult result = iMonNativeApi.IMON_Display_Uninit();
            String strResult = result.ToString();
            return strResult;
        }

        /*
         * Sending strings Line1 and Line2 to the iMon API
         */
        private String sendToVfdApi(String Line1, String Line2)
        {
            iMonNativeApi.iMonDisplayResult result = iMonNativeApi.IMON_Display_SetVfdText(Line1, Line2);
            String strResult = result.ToString();
            return strResult;
        }

        /*
         * Sending strings Line1 and Line2 to the iMon screen using the sendToVfdApi method
         */
        private String sendToScreen(String Line1, String Line2, bool onlyVFD)
        {
            if (!onlyVFD) { lblLine1.Text = Line1; lblLine2.Text = Line2; }
            return sendToVfdApi(Line1,Line2);
        }

        /*
         * Sending strings Line1 and Line2 to the iMon screen using the sendToVfdApi method
         */
        private String sendToScreen(String Line1, String Line2) 
        {
            return sendToScreen(Line1, Line2, false);
        }

        //Form handlers
        private void btnInitialise_Click(object sender, EventArgs e)
        {
            lblStateOutput.Text = initialiseVFD();
            tmrVfdRefreshRate.Enabled = true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            strToVfdLine1 = txtInputLine1.Text;
            strToVfdLine2 = txtInputLine2.Text;
            //lblLine1.Text = txtInputLine1.Text;
            //lblLine2.Text = txtInputLine2.Text;
            //lblStateOutput.Text = sendToVfdApi(txtInputLine1.Text, txtInputLine2.Text);
        }
        private void btnDeinitialise_Click(object sender, EventArgs e)
        {
            lblStateOutput.Text = deInitialiseVFD();
        }
        private void btnCount_Click(object sender, EventArgs e)
        {
            tmrCount.Enabled = !tmrCount.Enabled;
            tmrCount.Interval = int.Parse(txtInterval.Text);
        }

        /*
         * Only writes to the VFD if there is new data to write
         */
        private void tmrVfdRefreshrate_Tick(object sender, EventArgs e)
        {
            //Line 1
            if (strToVfdLine1.Length > 16) // if the string is too long for the screen (>16) then start scrolling
            {
                strToVfdScreenLine1 = strToVfdLine1.Substring(intStartPosToVfdScreenLine1, 16);
                //lblState.Text = "STATE " + intScrollStateLine1; //Debugging purposes, shows the current state
                switch (intScrollStateLine1)
                {
                    case 0:
                        tmrScrollingLine1.Enabled = true; //Enables this timer, once done the timer proceeds the state to the next one
                        break;
                    case 1:
                        intStartPosToVfdScreenLine1++;
                        break;
                    case 2:
                        tmrScrollingLine1.Enabled = true; //Enables this timer, once done the timer proceeds the state to the next one
                        break;
                    case 3:
                        intStartPosToVfdScreenLine1 = 0;
                        intScrollStateLine1 = 0;
                        break;
                }
                if (((intStartPosToVfdScreenLine1 + 16) == strToVfdLine1.Length) && (intScrollStateLine1 < 2)) //if end of line is there, next state
                {
                    intScrollStateLine1 = 2;
                }
            }
            else //if <16 send the full string to the VFD (No Scrolling)
            {
                strToVfdScreenLine1 = strToVfdLine1;
            }

            //Line 2
            if (strToVfdLine2.Length > 16) // if the string is too long for the screen (>16) then start scrolling
            {
                strToVfdScreenLine2 = strToVfdLine2.Substring(intStartPosToVfdScreenLine2, 16);
                //lblState.Text = "STATE " + intScrollStateLine2; //Debugging purposes, shows the current state
                switch (intScrollStateLine2)
                {
                    case 0:
                        tmrScrollingLine2.Enabled = true; //Enables this timer, once done the timer proceeds the state to the next one
                        break;
                    case 1:
                        intStartPosToVfdScreenLine2++;
                        break;
                    case 2:
                        tmrScrollingLine2.Enabled = true; //Enables this timer, once done the timer proceeds the state to the next one
                        break;
                    case 3:
                        intStartPosToVfdScreenLine2 = 0;
                        intScrollStateLine2 = 0;
                        break;
                }
                if (((intStartPosToVfdScreenLine2 + 16) == strToVfdLine2.Length) && (intScrollStateLine2 < 2)) //if end of line is there, next state
                {
                    intScrollStateLine2 = 2;
                }
            }
            else //if <16 send the full string to the VFD (No Scrolling)
            {
                strToVfdScreenLine2 = strToVfdLine2;
            }
            
            // Write both lines to VFD
            if (!((strToVfdLine1.Equals(previousToVfdScreenLine1)) && (strToVfdLine2.Equals(previousToVfdScreenLine2))))
            {
                lblStateOutput.Text = sendToScreen(strToVfdScreenLine1, strToVfdScreenLine2);
            }
        }

        private void btnRefreshRate_Click(object sender, EventArgs e)
        {
            tmrVfdRefreshRate.Interval = int.Parse(txtRefreshRate.Text);
        }

        private void tmrCount_Tick(object sender, EventArgs e)
        {
            strToVfdLine1 = "Counting...";
            strToVfdLine2 = counter+"";
            counter++;
        }

        private void tmrScrollingLine1_Tick(object sender, EventArgs e)
        {
            intScrollStateLine1++;
            tmrScrollingLine1.Enabled = false;
        }

        private void tmrScrollingLine2_Tick(object sender, EventArgs e)
        {
            intScrollStateLine2++;
            tmrScrollingLine2.Enabled = false;
        }
    }
}
