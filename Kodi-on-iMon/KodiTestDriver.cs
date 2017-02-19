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
            KodiGetProperties propertiesResponse = kodi.getProperties();


            if (activePlayers.result.Length > 0)
            {
                txtActivePlayersJSON.Text = activePlayers.result[0].type;
                if (activePlayers.result[0].type == "video")
                {
                    KodiResponse itemResponse = kodi.getVideoItem();
                    txtFileName.Text = itemResponse.result.item.file;
                    txtTime.Text = propertiesResponse.result.time.ToString();

                    txtField.Text = "Title: " + itemResponse.result.item.title + Environment.NewLine
                                    + "Season: " + itemResponse.result.item.season + Environment.NewLine
                                    + "Episode: " + itemResponse.result.item.episode + Environment.NewLine
                                    + "Show Title: " + itemResponse.result.item.showtitle + Environment.NewLine
                                    + "Album: " + itemResponse.result.item.album + Environment.NewLine
                                    + "Label: " + itemResponse.result.item.label;
                }
                else if (activePlayers.result[0].type == "audio")
                {
                    KodiResponse itemResponse = kodi.getAudioItem();
                    txtFileName.Text = itemResponse.result.item.file;
                    //txtTime.Text = propertiesResponse.result.time.ToString();

                    //txtField.Text = kodi.getAudioItemJson();
                    txtField.Text = "Title: " + itemResponse.result.item.title;
                }
                else if (activePlayers.result[0].type == "picture")
                {
                    KodiResponse itemResponse = kodi.getPictureItem();
                    txtFileName.Text = itemResponse.result.item.file;

                    //txtField.Text = kodi.getPictureItemJson();
                    txtField.Text = "Label: " + itemResponse.result.item.label;
                }
                
            }

            

        }
    }
}
