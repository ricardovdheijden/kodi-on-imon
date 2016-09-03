namespace Kodi_on_iMon
{
    partial class iMonTestDriver
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
            this.lblStateOutput = new System.Windows.Forms.Label();
            this.btnInitialise = new System.Windows.Forms.Button();
            this.btnDeinitialise = new System.Windows.Forms.Button();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblDirectWrite = new System.Windows.Forms.Label();
            this.txtInputLine1 = new System.Windows.Forms.TextBox();
            this.txtInputLine2 = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.lblRefreshRate = new System.Windows.Forms.Label();
            this.txtRefreshRate = new System.Windows.Forms.TextBox();
            this.btnRefreshRate = new System.Windows.Forms.Button();
            this.tmrFormRefreshRate = new System.Windows.Forms.Timer(this.components);
            this.txtScrollDelay = new System.Windows.Forms.TextBox();
            this.btnScrollDelay = new System.Windows.Forms.Button();
            this.lblScrollDelay = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStateOutput
            // 
            this.lblStateOutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStateOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStateOutput.Location = new System.Drawing.Point(75, 9);
            this.lblStateOutput.Name = "lblStateOutput";
            this.lblStateOutput.Size = new System.Drawing.Size(209, 23);
            this.lblStateOutput.TabIndex = 0;
            this.lblStateOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInitialise
            // 
            this.btnInitialise.Location = new System.Drawing.Point(12, 44);
            this.btnInitialise.Name = "btnInitialise";
            this.btnInitialise.Size = new System.Drawing.Size(122, 33);
            this.btnInitialise.TabIndex = 1;
            this.btnInitialise.Text = "Initialise";
            this.btnInitialise.UseVisualStyleBackColor = true;
            this.btnInitialise.Click += new System.EventHandler(this.btnInitialise_Click);
            // 
            // btnDeinitialise
            // 
            this.btnDeinitialise.Location = new System.Drawing.Point(164, 44);
            this.btnDeinitialise.Name = "btnDeinitialise";
            this.btnDeinitialise.Size = new System.Drawing.Size(120, 33);
            this.btnDeinitialise.TabIndex = 2;
            this.btnDeinitialise.Text = "Deinitialise";
            this.btnDeinitialise.UseVisualStyleBackColor = true;
            this.btnDeinitialise.Click += new System.EventHandler(this.btnDeinitialise_Click);
            // 
            // lblLine1
            // 
            this.lblLine1.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLine1.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLine1.Location = new System.Drawing.Point(15, 138);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(270, 30);
            this.lblLine1.TabIndex = 3;
            // 
            // lblLine2
            // 
            this.lblLine2.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLine2.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLine2.Location = new System.Drawing.Point(15, 168);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(270, 30);
            this.lblLine2.TabIndex = 4;
            // 
            // lblDirectWrite
            // 
            this.lblDirectWrite.AutoSize = true;
            this.lblDirectWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectWrite.Location = new System.Drawing.Point(12, 210);
            this.lblDirectWrite.Name = "lblDirectWrite";
            this.lblDirectWrite.Size = new System.Drawing.Size(115, 13);
            this.lblDirectWrite.TabIndex = 5;
            this.lblDirectWrite.Text = "Direct write to VFD";
            // 
            // txtInputLine1
            // 
            this.txtInputLine1.Location = new System.Drawing.Point(13, 227);
            this.txtInputLine1.Name = "txtInputLine1";
            this.txtInputLine1.Size = new System.Drawing.Size(121, 20);
            this.txtInputLine1.TabIndex = 6;
            this.txtInputLine1.Text = "The.Hunger.Games.Catching.Fire.2013.1080p.BluRay.X264-AMIABLE.mp4";
            // 
            // txtInputLine2
            // 
            this.txtInputLine2.Location = new System.Drawing.Point(13, 254);
            this.txtInputLine2.Name = "txtInputLine2";
            this.txtInputLine2.Size = new System.Drawing.Size(121, 20);
            this.txtInputLine2.TabIndex = 7;
            this.txtInputLine2.Text = "0:50:21  2:15:43";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(164, 227);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 47);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Show on VFD";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(13, 13);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(56, 13);
            this.lblState.TabIndex = 15;
            this.lblState.Text = "VFD State";
            // 
            // lblRefreshRate
            // 
            this.lblRefreshRate.AutoSize = true;
            this.lblRefreshRate.Location = new System.Drawing.Point(12, 89);
            this.lblRefreshRate.Name = "lblRefreshRate";
            this.lblRefreshRate.Size = new System.Drawing.Size(106, 13);
            this.lblRefreshRate.TabIndex = 16;
            this.lblRefreshRate.Text = "VFD refresh rate (ms)";
            // 
            // txtRefreshRate
            // 
            this.txtRefreshRate.Location = new System.Drawing.Point(124, 86);
            this.txtRefreshRate.Name = "txtRefreshRate";
            this.txtRefreshRate.Size = new System.Drawing.Size(45, 20);
            this.txtRefreshRate.TabIndex = 17;
            // 
            // btnRefreshRate
            // 
            this.btnRefreshRate.Location = new System.Drawing.Point(205, 83);
            this.btnRefreshRate.Name = "btnRefreshRate";
            this.btnRefreshRate.Size = new System.Drawing.Size(79, 23);
            this.btnRefreshRate.TabIndex = 18;
            this.btnRefreshRate.Text = "Apply";
            this.btnRefreshRate.UseVisualStyleBackColor = true;
            this.btnRefreshRate.Click += new System.EventHandler(this.btnRefreshRate_Click);
            // 
            // tmrFormRefreshRate
            // 
            this.tmrFormRefreshRate.Interval = 250;
            this.tmrFormRefreshRate.Tick += new System.EventHandler(this.tmrFormRefreshRate_Tick);
            // 
            // txtScrollDelay
            // 
            this.txtScrollDelay.Location = new System.Drawing.Point(124, 112);
            this.txtScrollDelay.Name = "txtScrollDelay";
            this.txtScrollDelay.Size = new System.Drawing.Size(45, 20);
            this.txtScrollDelay.TabIndex = 19;
            // 
            // btnScrollDelay
            // 
            this.btnScrollDelay.Location = new System.Drawing.Point(205, 110);
            this.btnScrollDelay.Name = "btnScrollDelay";
            this.btnScrollDelay.Size = new System.Drawing.Size(79, 23);
            this.btnScrollDelay.TabIndex = 20;
            this.btnScrollDelay.Text = "Apply";
            this.btnScrollDelay.UseVisualStyleBackColor = true;
            this.btnScrollDelay.Click += new System.EventHandler(this.btnScrollDelay_Click);
            // 
            // lblScrollDelay
            // 
            this.lblScrollDelay.AutoSize = true;
            this.lblScrollDelay.Location = new System.Drawing.Point(12, 114);
            this.lblScrollDelay.Name = "lblScrollDelay";
            this.lblScrollDelay.Size = new System.Drawing.Size(105, 13);
            this.lblScrollDelay.TabIndex = 21;
            this.lblScrollDelay.Text = "VFD scroll delay (ms)";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(164, 280);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(120, 29);
            this.btnSaveSettings.TabIndex = 22;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // iMonTestDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 318);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.lblScrollDelay);
            this.Controls.Add(this.btnScrollDelay);
            this.Controls.Add(this.txtScrollDelay);
            this.Controls.Add(this.btnRefreshRate);
            this.Controls.Add(this.txtRefreshRate);
            this.Controls.Add(this.lblRefreshRate);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInputLine2);
            this.Controls.Add(this.txtInputLine1);
            this.Controls.Add(this.lblDirectWrite);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.btnDeinitialise);
            this.Controls.Add(this.btnInitialise);
            this.Controls.Add(this.lblStateOutput);
            this.Name = "iMonTestDriver";
            this.Text = "iMonTestDriver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStateOutput;
        private System.Windows.Forms.Button btnInitialise;
        private System.Windows.Forms.Button btnDeinitialise;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblDirectWrite;
        private System.Windows.Forms.TextBox txtInputLine1;
        private System.Windows.Forms.TextBox txtInputLine2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblRefreshRate;
        private System.Windows.Forms.TextBox txtRefreshRate;
        private System.Windows.Forms.Button btnRefreshRate;
        private System.Windows.Forms.Timer tmrFormRefreshRate;
        private System.Windows.Forms.TextBox txtScrollDelay;
        private System.Windows.Forms.Button btnScrollDelay;
        private System.Windows.Forms.Label lblScrollDelay;
        private System.Windows.Forms.Button btnSaveSettings;

    }
}