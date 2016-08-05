using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Kodi_on_iMon
{
    public class iMonVFD
    {
        private iMonVfdLine line1;
        private iMonVfdLine line2;
        private int refreshRate;

        public iMonVFD()
        {
            line1 = new iMonVfdLine();
            line2 = new iMonVfdLine();
            refreshRate = 250;
        }

        public iMonVFD(string line1, string line2, int refreshRate_ms)
        {
            this.line1 = new iMonVfdLine();
            this.line2 = new iMonVfdLine();
            refreshRate = refreshRate_ms;
        }
    }

    public class iMonVfdLine
    {
        private String text;
        private String previousVfdText;
        private int scrollPosition;
        private Timer tmrScrollDelay;
        private bool scrolling;
        private int scrollState;

        public iMonVfdLine()
        {
            this.previousVfdText = "";
            this.scrollPosition = 0;
            this.tmrScrollDelay.Interval = 1000;
            this.tmrScrollDelay.Elapsed += new ElapsedEventHandler(tmrScrollDelay_Elapsed);
            this.scrolling = false;
            this.scrollState = 0;
            setText("");
        }

        public iMonVfdLine(string text, int scrollDelay)
        {
            this.previousVfdText = "";
            this.scrolling = false;
            this.scrollPosition = 0;
            this.tmrScrollDelay.Interval = scrollDelay;
            this.scrollState = 0;
            setText(text);
        }
        
        void tmrScrollDelay_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.tmrScrollDelay.Enabled = false;
            this.scrollState++;
        }
        
        public void refreshVFD()
        {
            scrollPosition++; //todo END OF LINE hier moeten de scroll states in komen
        }

        public void setText(string text)
        {
            this.previousVfdText = getVfdText();
            this.text = text;
            if (text.Length > 16)
            {
                this.scrollState = 0;
                this.tmrScrollDelay.Enabled = true;
            }
            else
            {
                //todo, kan weg, geen ELSE nodig
            }
        }
        public void addScrollPosition()
        {
            //todo
        }
        public void setScrollPosition(int value)
        {
            this.scrollPosition = value;
        }
        public int getMaxScrollPosition()
        {
            if (this.text.Length > 16) { return this.text.Length - 16; }
            else { return 0; }
        }
        public int getScrollPosition()
        {
            return this.scrollPosition;
        }
        public string getVfdText()
        {
            return this.text.Substring(this.scrollPosition, 16);
        }
        public bool getScrolling()
        {
            if (this.text.Length > 16) { return true; }
            else { return false; }
        }
        public bool getTextChanged()
        {
            if (getVfdText().Equals(this.previousVfdText)) { return false; }
            else { return true; }
        }
    }
}
