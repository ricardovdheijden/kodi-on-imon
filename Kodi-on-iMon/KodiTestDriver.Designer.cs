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
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtField = new System.Windows.Forms.TextBox();
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
            this.txtEmail.Location = new System.Drawing.Point(24, 394);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(697, 20);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "Email: ";
            // 
            // tmrRefreshRate
            // 
            this.tmrRefreshRate.Tick += new System.EventHandler(this.tmrRefreshRate_Tick);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(181, 38);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(540, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(181, 87);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(540, 20);
            this.txtTime.TabIndex = 3;
            // 
            // txtField
            // 
            this.txtField.Location = new System.Drawing.Point(24, 127);
            this.txtField.Multiline = true;
            this.txtField.Name = "txtField";
            this.txtField.Size = new System.Drawing.Size(697, 139);
            this.txtField.TabIndex = 4;
            // 
            // KodiTestDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 426);
            this.Controls.Add(this.txtField);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.txtFileName);
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
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtField;
    }
}