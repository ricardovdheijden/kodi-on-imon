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
            KodiGetItem itemResponse = kodi.getItem();
            KodiGetProperties propertiesResponse = kodi.getProperties();


            if (activePlayers.result.Length > 0)
            {
                txtActivePlayersJSON.Text = activePlayers.result[0].type;
                if (activePlayers.result[0].type == "video")
                {
                    txtFileName.Text = itemResponse.result.item.file;
                    txtTime.Text = propertiesResponse.result.time.ToString();

                    txtField.Text = "Title: " + itemResponse.result.item.title + Environment.NewLine
                                    + "Season: " + itemResponse.result.item.season + Environment.NewLine
                                    + "Episode: " + itemResponse.result.item.episode + Environment.NewLine
                                    + "Show Title: " + itemResponse.result.item.showtitle + Environment.NewLine
                                    + "Album: " + itemResponse.result.item.album + Environment.NewLine;
                }
                else if (activePlayers.result[0].type == "audio")
                {
                    txtActivePlayersJSON.Text = activePlayers.result[0].type + " woohoo";
                }
                else if (activePlayers.result[0].type == "picture")
                {
                    txtActivePlayersJSON.Text = activePlayers.result[0].type + " woohoo2";
                }
                
            }

            

        }
    }
}
