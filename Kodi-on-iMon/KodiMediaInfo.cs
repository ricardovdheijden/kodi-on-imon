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
    public partial class KodiMediaInfo : Form
    {
        iMon imon;
        Kodi kodi;
        int imonRefreshRate = 250;
        int kodiRefreshRate = 500;
        int scrollDelay = 2500;
        int connectionAttempt = 1;

        public KodiMediaInfo()
        {
            InitializeComponent();

            notifyIcon.Visible = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            
            btnConnect.Enabled = false;

            imon = new iMon();
            imon.initialise();
            imon.setRefreshRate(imonRefreshRate);
            imon.setScrollDelay(scrollDelay);
            imon.setText("Connecting to", "Kodi...");

            kodi = new Kodi();

            tmrFormRefreshRate.Interval = imonRefreshRate;
            tmrKodiRefreshRate.Interval = kodiRefreshRate;
            tmrFormRefreshRate.Enabled = true;
            tmrKodiRefreshRate.Enabled = true;
        }

        private int getPlayerId(KodiActivePlayers activePlayers)
        {
            int playerid = 0;
            int foundType = 3; //1 = audio; 2 = video; 3 = picture
            for (int i = 0; i < activePlayers.result.Length; i++)
            {
                if (activePlayers.result[i].type == "audio") { playerid = activePlayers.result[i].playerid; foundType = 1; }
                else if (activePlayers.result[i].type == "video" && foundType >= 2) { playerid = activePlayers.result[i].playerid; foundType = 2; }
                else if (activePlayers.result[i].type == "picture" && foundType >= 3) { playerid = activePlayers.result[i].playerid; foundType = 3; }
            }
            return playerid;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void tmrFormRefreshRate_Tick(object sender, EventArgs e)
        {
            lblLine1.Text = imon.getVFDText(0);
            lblLine2.Text = imon.getVFDText(1);
        }

        private void tmrKodiRefreshRate_Tick(object sender, EventArgs e)
        {
            KodiActivePlayers activePlayers = kodi.getActivePlayers();
            string line1 = " ";
            string line2 = " ";

            if (activePlayers.error != null && activePlayers.error.Length > 0)
            {
                line1 = activePlayers.error;
                tmrKodiRefreshRate.Enabled = false;
                btnConnect.Enabled = true;
                tmrRetryConnecting.Enabled = true;
            }
            else
            {
                connectionAttempt = 0;
                if (activePlayers.result.Length > 0)
                {
                    int playerid = getPlayerId(activePlayers);
                    KodiGetProperties propertiesResponse = kodi.getProperties(playerid);
                    for (int i = 0; i < activePlayers.result.Length; i++)
                    {
                        if (activePlayers.result[i].type == "video" && activePlayers.result[i].playerid == playerid)
                        {
                            KodiResponse itemResponse = kodi.getVideoItem(playerid);
                            line2 = propertiesResponse.result.time.ToString() + "  " + propertiesResponse.result.totaltime.ToString();
                            if (itemResponse.result.item.type == "movie") line1 = itemResponse.result.item.movieToString();
                            else if (itemResponse.result.item.type == "episode") line1 = itemResponse.result.item.episodeToString();
                            else if (itemResponse.result.item.type == "musicvideo") line1 = itemResponse.result.item.musicvideoToString();
                            else if (itemResponse.result.item.type == "unknown") line1 = itemResponse.result.item.unknownTypeToString();
                        }
                        else if (activePlayers.result[i].type == "audio" && activePlayers.result[i].playerid == playerid)
                        {
                            KodiResponse itemResponse = kodi.getAudioItem(playerid);
                            line2 = propertiesResponse.result.time.ToString() + "  " + propertiesResponse.result.totaltime.ToString();
                            if (itemResponse.result.item.type == "song") line1 = itemResponse.result.item.songToString();
                        }
                        else if (activePlayers.result[i].type == "picture" && activePlayers.result[i].playerid == playerid)
                        {
                            KodiResponse itemResponse = kodi.getPictureItem(playerid);
                            if (itemResponse.result.item.type == "picture") line1 = itemResponse.result.item.pictureToString();
                        }
                    }
                }
            }
            imon.setText(line1, line2);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            imon.setText("Connecting to","Kodi...");
            tmrKodiRefreshRate.Enabled = true;
        }

        private void tmrRetryConnecting_Tick(object sender, EventArgs e)
        {
            tmrRetryConnecting.Enabled = false;
            btnConnect.Enabled = false;
            imon.setText("Connecting", "(" + ++connectionAttempt + ")");
            tmrKodiRefreshRate.Enabled = true;
        }
    }
}
