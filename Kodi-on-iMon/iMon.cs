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
    public partial class iMon : Form
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
        private bool swapLines = false; //If true: it swaps lines 0 and 1 after the end of the line is reached

        public iMon()
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
            lblStateOutput.Text = initialise();
            tmrFormRefreshRate.Enabled = true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            setText(txtInputLine1.Text, txtInputLine2.Text);
        }
        private void btnDeinitialise_Click(object sender, EventArgs e)
        {
            lblStateOutput.Text = deinitialise();
            tmrFormRefreshRate.Enabled = false;
            //lblStateOutput.Text = deInitialiseVFD();
        }
        private void btnCount_Click(object sender, EventArgs e)
        {
            tmrCount.Enabled = !tmrCount.Enabled;
            tmrCount.Interval = int.Parse(txtInterval.Text);
        }

        private void tmrFormRefreshRate_Tick(object sender, EventArgs e)
        {
            lblLine1.Text = getVFDText(0);
            lblLine2.Text = getVFDText(1);
        }

        /*
         * Only writes to the VFD if there is new data to write
         */
        private void tmrVfdRefreshrate_Tick(object sender, EventArgs e)
        {
            //Line 1
            if (strToVfdLine1.Length > 16) // if the string is too long for the screen (>16) then start scrolling
            {
                try
                {
                    strToVfdScreenLine1 = strToVfdLine1.Substring(intStartPosToVfdScreenLine1, 16);
                }
                catch //index out of bounds if the line gets shorter while scrolling
                {
                    intStartPosToVfdScreenLine1 = 0;
                    strToVfdScreenLine1 = strToVfdLine1.Substring(intStartPosToVfdScreenLine1, 16);
                }
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
                        break;
                }
                if (((intStartPosToVfdScreenLine1 + 16) == strToVfdLine1.Length) && (intScrollStateLine1 < 2)) //if end of line is there, next state
                {
                    intScrollStateLine1 = 2;
                }
                if (swapLines == true && intScrollStateLine1 == 3)
                {
                    intScrollStateLine1 = 0;
                    setText(strToVfdLine2, strToVfdLine1);
                }
                else if (swapLines == false && intScrollStateLine1 == 3)
                {
                    intScrollStateLine1 = 0;
                }
            }
            else //if <16 send the full string to the VFD (No Scrolling)
            {
                strToVfdScreenLine1 = strToVfdLine1;
            }

            //Line 2
            if (strToVfdLine2.Length > 16) // if the string is too long for the screen (>16) then start scrolling
            {
                try 
                {
                    strToVfdScreenLine2 = strToVfdLine2.Substring(intStartPosToVfdScreenLine2, 16);
                }
                catch //index out of bounds if the line gets shorter while scrolling
                {
                    intStartPosToVfdScreenLine2 = 0;
                    strToVfdScreenLine2 = strToVfdLine2.Substring(intStartPosToVfdScreenLine2, 16);
                }
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
                        break;
                }
                if (((intStartPosToVfdScreenLine2 + 16) == strToVfdLine2.Length) && (intScrollStateLine2 < 2)) //if end of line is there, next state
                {
                    intScrollStateLine2 = 2;
                }
                if (swapLines == true && intScrollStateLine2 == 3)
                {
                    intScrollStateLine2 = 0;
                    setText(strToVfdLine2, strToVfdLine1);
                }
                else if (swapLines == false && intScrollStateLine2 == 3)
                {
                    intScrollStateLine2 = 0;
                }
            }
            else //if <16 send the full string to the VFD (No Scrolling)
            {
                strToVfdScreenLine2 = strToVfdLine2;
            }
            
            // Write both lines to VFD
            if (!((strToVfdLine1.Equals(previousToVfdScreenLine1)) && (strToVfdLine2.Equals(previousToVfdScreenLine2))))
            {
                lblStateOutput.Text = sendToScreen(strToVfdScreenLine1, strToVfdScreenLine2,true);
            }
        }

        private void btnRefreshRate_Click(object sender, EventArgs e)
        {
            setRefreshRate(int.Parse(txtRefreshRate.Text));
            tmrFormRefreshRate.Interval = int.Parse(txtRefreshRate.Text);
            //tmrVfdRefreshRate.Interval = int.Parse(txtRefreshRate.Text);
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

        // Public getters and setter

        /*
         * Sets the text that can be shown on the screen, it can be live updated
         */
        public void setText(string Line1, string Line2)
        {
            strToVfdLine1 = Line1;
            strToVfdLine2 = Line2;
        }

        public void setText(string Line, bool swapAfterEveryCycle)
        {
            strToVfdLine1 = Line;
            swapLines = swapAfterEveryCycle;
        }

        /*
         * Sets the time on a given line on the screen
         * lineNumber:                              0 for the first line / 1 for the second line
         * currentHour/currentMinute/currentSecond: hour, minute, second as int
         * totalHour/totalMinute/totalSecond:       hour, minute, second as int
         */
        public void setTime(int lineNumber, int currentHour, int currentMinute, int currentSecond, int totalHour, int totalMinute, int totalSecond)
        {

        }
        
        /*
         * Sets refreshrate of screen: value in ms between refreshes
         * 100 scrolls faster then 200
         */
        public void setRefreshRate (int refreshRate)
        {
            tmrVfdRefreshRate.Interval = refreshRate;
        }

        public void setScrollDelay (int delay)
        {
            setScrollDelay(-1, delay);
        }
        /*
         * Sets delay in ms to wait when line is scrolled to the end
         * Also applies for the time to wait at the start of a scrolling text
         * 
         */
        public void setScrollDelay (int lineNumber, int delay)
        {
            if (lineNumber == 0)
            {
                tmrScrollingLine1.Interval = delay;
            }
            else if (lineNumber == 1)
            {
                tmrScrollingLine2.Interval = delay;
            }
            else if (lineNumber == -1)
            {
                tmrScrollingLine1.Interval = delay;
                tmrScrollingLine2.Interval = delay;
            }

        }

        /*
         * returns the full text that is being shown on the display (in case of scrolling, the full string is still being returned)
         * lineNumber: 0 for first line / 1 for second line
         */
        public string getText(int lineNumber)
        {
            if (lineNumber == 0)
            {
                return strToVfdLine1;
            }
            else if (lineNumber == 1)
            {
                return strToVfdLine2;
            }
            else
            {
                return "";
            }
        }

        /*
         * returns the exact text that is displayed on the VFD (in case of scrolling, only the part that is visible)
         * lineNumber: 0 for first line / 1 for second line
         */
        public string getVFDText(int lineNumber)
        {
            if (lineNumber == 0)
            {
                return strToVfdScreenLine1;
            }
            else if (lineNumber == 1)
            {
                return strToVfdScreenLine2;
            }
            else
            {
                return "";
            }
        }

        public string initialise()
        {
            tmrVfdRefreshRate.Enabled = true;
            return initialiseVFD();
        }
        
        public string deinitialise()
        {
            tmrVfdRefreshRate.Enabled = false; //TODO: this line needs to be tested on the real VFD!
            return deInitialiseVFD();
        }
    }
}
