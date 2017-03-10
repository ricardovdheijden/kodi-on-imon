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
    public partial class KodiTestDriver : Form
    {
        Kodi kodi;
        public KodiTestDriver()
        {
            InitializeComponent();
            kodi = new Kodi();
            tmrRefreshRate.Enabled = true;
        }

        private void tmrRefreshRate_Tick(object sender, EventArgs e)
        {
            KodiActivePlayers activePlayers = kodi.getActivePlayers();
            

            if (activePlayers.error != null && activePlayers.error.Length > 0)
            {
                txtActivePlayers.Text = activePlayers.error;
                tmrRefreshRate.Enabled = false;
                btnConnect.Enabled = true;
            }
            else
            {
                if (activePlayers.result.Length > 0)
                {
                    int playerid = getPlayerId(activePlayers);
                    KodiGetProperties propertiesResponse = kodi.getProperties(playerid);
                    txtActivePlayers.Text = activePlayers.result[0].type;
                    for (int i = 0; i < activePlayers.result.Length; i++)
                    {
                        if (activePlayers.result[i].type == "video" && activePlayers.result[i].playerid == playerid)
                        {
                            KodiResponse itemResponse = kodi.getVideoItem(playerid);
                            txtTime.Text = propertiesResponse.result.time.ToString();
                            txtField.Text = "File Name: " + itemResponse.result.item.file + Environment.NewLine
                                            + "Title: " + itemResponse.result.item.title + Environment.NewLine
                                            + "Season: " + itemResponse.result.item.season + Environment.NewLine
                                            + "Episode: " + itemResponse.result.item.episode + Environment.NewLine
                                            + "Show Title: " + itemResponse.result.item.showtitle + Environment.NewLine
                                            + "Album: " + itemResponse.result.item.album + Environment.NewLine
                                            + "Year: " + itemResponse.result.item.year + Environment.NewLine
                                            + "Type: " + itemResponse.result.item.type + Environment.NewLine
                                            + "Label: " + itemResponse.result.item.label + Environment.NewLine
                                            + "Artist: ";
                            foreach (String artist in itemResponse.result.item.artist)
                            {
                                if (artist != itemResponse.result.item.artist.Last()) txtField.Text += artist + " -- ";
                                else txtField.Text += artist;
                            }
                            if (itemResponse.result.item.type == "movie") txtToDisplay.Text = itemResponse.result.item.movieToString();
                            else if (itemResponse.result.item.type == "episode") txtToDisplay.Text = itemResponse.result.item.episodeToString();
                            else if (itemResponse.result.item.type == "musicvideo") txtToDisplay.Text = itemResponse.result.item.musicvideoToString();
                            else if (itemResponse.result.item.type == "unknown") txtToDisplay.Text = itemResponse.result.item.unknownTypeToString();
                        }
                        else if (activePlayers.result[i].type == "audio" && activePlayers.result[i].playerid == playerid)
                        {
                            KodiResponse itemResponse = kodi.getAudioItem(playerid);
                            txtTime.Text = propertiesResponse.result.time.ToString();

                            //txtField.Text = kodi.getAudioItemJson();
                            txtField.Text = "File Name: " + itemResponse.result.item.file + Environment.NewLine
                                            + "Title: " + itemResponse.result.item.title + Environment.NewLine
                                            + "Album: " + itemResponse.result.item.album + Environment.NewLine
                                            + "Year: " + itemResponse.result.item.year + Environment.NewLine
                                            + "Type: " + itemResponse.result.item.type + Environment.NewLine
                                            + "Label: " + itemResponse.result.item.label + Environment.NewLine
                                            + "Artist: ";
                            foreach (String artist in itemResponse.result.item.artist)
                            {
                                if (artist != itemResponse.result.item.artist.Last()) txtField.Text += artist + " -- ";
                                else txtField.Text += artist;
                            }
                            if (itemResponse.result.item.type == "song") txtToDisplay.Text = itemResponse.result.item.songToString();
                        }
                        else if (activePlayers.result[i].type == "picture" && activePlayers.result[i].playerid == playerid)
                        {
                            KodiResponse itemResponse = kodi.getPictureItem(playerid);

                            //txtField.Text = kodi.getPictureItemJson();
                            txtField.Text = "File Name: " + itemResponse.result.item.file + Environment.NewLine
                                            + "Type: " + itemResponse.result.item.type + Environment.NewLine
                                            + "Label: " + itemResponse.result.item.label;
                            if (itemResponse.result.item.type == "picture") txtToDisplay.Text = itemResponse.result.item.pictureToString();
                        }
                    }
                }
            }
        }

        private int getPlayerId(KodiActivePlayers activePlayers)
        {
            int playerid = 0;
            int foundType = 3; //1 = audio; 2 = video; 3 = picture
            for (int i = 0; i < activePlayers.result.Length; i++)
            {
                if (activePlayers.result[i].type == "audio") { playerid = activePlayers.result[i].playerid; foundType = 1; }
                else if (activePlayers.result[i].type == "video" && foundType >= 2) { playerid = activePlayers.result[i].playerid; foundType = 2; }
                else if (activePlayers.result[i].type == "picture" && foundType >=3) { playerid = activePlayers.result[i].playerid; foundType = 3; }
            }
            return playerid;
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            txtActivePlayers.Text = "";
            tmrRefreshRate.Enabled = true;
        }
    }
}
