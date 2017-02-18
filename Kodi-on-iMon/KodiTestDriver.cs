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
            KodiGetItem itemResponse = kodi.getItem();
            KodiGetProperties propertiesResponse = kodi.getProperties();
            KodiActivePlayers activePlayers = kodi.getActivePlayers();

            txtActivePlayersJSON.Text = activePlayers.result[0].type;

            txtFileName.Text = itemResponse.result.item.file;
            txtTime.Text = propertiesResponse.result.time.ToString();

            txtField.Text = "Title: " + itemResponse.result.item.title + Environment.NewLine
                            + "Season: " + itemResponse.result.item.season+ Environment.NewLine
                            + "Episode: " + itemResponse.result.item.episode + Environment.NewLine
                            + "Show Title: " + itemResponse.result.item.showtitle + Environment.NewLine
                            + "Album: " + itemResponse.result.item.album + Environment.NewLine;

        }
    }
}
