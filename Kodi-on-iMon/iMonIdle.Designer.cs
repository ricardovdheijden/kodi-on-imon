namespace Kodi_on_iMon
{
    partial class iMonIdle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iMonIdle));
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.tmrFormRefreshRate = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // lblLine2
            // 
            this.lblLine2.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLine2.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLine2.Location = new System.Drawing.Point(12, 39);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(270, 30);
            this.lblLine2.TabIndex = 6;
            // 
            // lblLine1
            // 
            this.lblLine1.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLine1.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLine1.Location = new System.Drawing.Point(12, 9);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(270, 30);
            this.lblLine1.TabIndex = 5;
            // 
            // tmrFormRefreshRate
            // 
            this.tmrFormRefreshRate.Interval = 250;
            this.tmrFormRefreshRate.Tick += new System.EventHandler(this.tmrFormRefreshRate_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "iMon Idle";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // iMonIdle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 79);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblLine1);
            this.Name = "iMonIdle";
            this.Text = "iMonIdle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Timer tmrFormRefreshRate;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}