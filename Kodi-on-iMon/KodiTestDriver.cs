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
            KodiGetProperties propertiesResponse = kodi.getProperties();

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
                    txtActivePlayers.Text = activePlayers.result[0].type;
                    if (activePlayers.result[0].type == "video")
                    {
                        KodiResponse itemResponse = kodi.getVideoItem();
                        txtTime.Text = propertiesResponse.result.time.ToString();
                        txtField.Text = "File Name: " + itemResponse.result.item.file + Environment.NewLine
                                        + "Title: " + itemResponse.result.item.title + Environment.NewLine
                                        + "Season: " + itemResponse.result.item.season + Environment.NewLine
                                        + "Episode: " + itemResponse.result.item.episode + Environment.NewLine
                                        + "Show Title: " + itemResponse.result.item.showtitle + Environment.NewLine
                                        + "Album: " + itemResponse.result.item.album + Environment.NewLine
                                        + "Artist: " + itemResponse.result.item.artist[0] + Environment.NewLine //todo: write out all artists
                                        + "Year: " + itemResponse.result.item.year + Environment.NewLine
                                        + "Type: " + itemResponse.result.item.type + Environment.NewLine
                                        + "Label: " + itemResponse.result.item.label;
                    }
                    else if (activePlayers.result[0].type == "audio")
                    {
                        KodiResponse itemResponse = kodi.getAudioItem();
                        //txtTime.Text = propertiesResponse.result.time.ToString();

                        //txtField.Text = kodi.getAudioItemJson();
                        txtField.Text = "File Name: " + itemResponse.result.item.file + Environment.NewLine
                                        + "Title: " + itemResponse.result.item.title;
                    }
                    else if (activePlayers.result[0].type == "picture")
                    {
                        KodiResponse itemResponse = kodi.getPictureItem();

                        //txtField.Text = kodi.getPictureItemJson();
                        txtField.Text = "File Name: " + itemResponse.result.item.file + Environment.NewLine
                                        + "Label: " + itemResponse.result.item.label;
                    }
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            txtActivePlayers.Text = "";
            tmrRefreshRate.Enabled = true;
        }
    }
}
