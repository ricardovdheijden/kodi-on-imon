namespace Kodi_on_iMon
{
    partial class KodiTestDriver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtActivePlayersJSON = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.tmrRefreshRate = new System.Windows.Forms.Timer(this.components);
            this.txtNowPlayingJSON = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtActivePlayersJSON
            // 
            this.txtActivePlayersJSON.Location = new System.Drawing.Point(24, 12);
            this.txtActivePlayersJSON.Name = "txtActivePlayersJSON";
            this.txtActivePlayersJSON.Size = new System.Drawing.Size(697, 20);
            this.txtActivePlayersJSON.TabIndex = 0;
            this.txtActivePlayersJSON.Text = "Active Players";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(24, 181);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(697, 20);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "Email: ";
            // 
            // tmrRefreshRate
            // 
            this.tmrRefreshRate.Tick += new System.EventHandler(this.tmrRefreshRate_Tick);
            // 
            // txtNowPlayingJSON
            // 
            this.txtNowPlayingJSON.Location = new System.Drawing.Point(24, 38);
            this.txtNowPlayingJSON.Name = "txtNowPlayingJSON";
            this.txtNowPlayingJSON.Size = new System.Drawing.Size(697, 20);
            this.txtNowPlayingJSON.TabIndex = 2;
            this.txtNowPlayingJSON.Text = "Now Playing";
            // 
            // KodiTestDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 213);
            this.Controls.Add(this.txtNowPlayingJSON);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtActivePlayersJSON);
            this.Name = "KodiTestDriver";
            this.Text = "KodiTestDriver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivePlayersJSON;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Timer tmrRefreshRate;
        private System.Windows.Forms.TextBox txtNowPlayingJSON;

    }
}