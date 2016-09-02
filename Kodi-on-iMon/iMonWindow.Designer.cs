namespace Kodi_on_iMon
{
    partial class iMonWindow
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
            this.lblCount = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.btnCount = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.tmrVfdRefreshRate = new System.Windows.Forms.Timer(this.components);
            this.lblRefreshRate = new System.Windows.Forms.Label();
            this.txtRefreshRate = new System.Windows.Forms.TextBox();
            this.btnRefreshRate = new System.Windows.Forms.Button();
            this.tmrCount = new System.Windows.Forms.Timer(this.components);
            this.tmrScrollingLine1 = new System.Windows.Forms.Timer(this.components);
            this.tmrScrollingLine2 = new System.Windows.Forms.Timer(this.components);
            this.tmrFormRefreshRate = new System.Windows.Forms.Timer(this.components);
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
            this.lblLine1.Location = new System.Drawing.Point(15, 130);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(270, 30);
            this.lblLine1.TabIndex = 3;
            // 
            // lblLine2
            // 
            this.lblLine2.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLine2.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLine2.Location = new System.Drawing.Point(15, 160);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(270, 30);
            this.lblLine2.TabIndex = 4;
            // 
            // lblDirectWrite
            // 
            this.lblDirectWrite.AutoSize = true;
            this.lblDirectWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectWrite.Location = new System.Drawing.Point(12, 204);
            this.lblDirectWrite.Name = "lblDirectWrite";
            this.lblDirectWrite.Size = new System.Drawing.Size(115, 13);
            this.lblDirectWrite.TabIndex = 5;
            this.lblDirectWrite.Text = "Direct write to VFD";
            // 
            // txtInputLine1
            // 
            this.txtInputLine1.Location = new System.Drawing.Point(13, 221);
            this.txtInputLine1.Name = "txtInputLine1";
            this.txtInputLine1.Size = new System.Drawing.Size(121, 20);
            this.txtInputLine1.TabIndex = 6;
            this.txtInputLine1.Text = "The.Hunger.Games.Catching.Fire.2013.1080p.BluRay.X264-AMIABLE.mp4";
            // 
            // txtInputLine2
            // 
            this.txtInputLine2.Location = new System.Drawing.Point(13, 248);
            this.txtInputLine2.Name = "txtInputLine2";
            this.txtInputLine2.Size = new System.Drawing.Size(121, 20);
            this.txtInputLine2.TabIndex = 7;
            this.txtInputLine2.Text = "0:50:21  2:15:43";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(164, 221);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(120, 47);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Show on VFD";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(13, 292);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(40, 13);
            this.lblCount.TabIndex = 9;
            this.lblCount.Text = "Count";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(13, 315);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(29, 13);
            this.lblStart.TabIndex = 10;
            this.lblStart.Text = "Start";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(89, 312);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(45, 20);
            this.txtStart.TabIndex = 11;
            this.txtStart.Text = "1";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(13, 335);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(64, 13);
            this.lblInterval.TabIndex = 12;
            this.lblInterval.Text = "Interval (ms)";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(89, 332);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(45, 20);
            this.txtInterval.TabIndex = 13;
            this.txtInterval.Text = "250";
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(164, 310);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(120, 42);
            this.btnCount.TabIndex = 14;
            this.btnCount.Text = "Count Start/Stop";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
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
            // tmrVfdRefreshRate
            // 
            this.tmrVfdRefreshRate.Interval = 250;
            this.tmrVfdRefreshRate.Tick += new System.EventHandler(this.tmrVfdRefreshrate_Tick);
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
            this.txtRefreshRate.Location = new System.Drawing.Point(121, 86);
            this.txtRefreshRate.Name = "txtRefreshRate";
            this.txtRefreshRate.Size = new System.Drawing.Size(45, 20);
            this.txtRefreshRate.TabIndex = 17;
            this.txtRefreshRate.Text = "250";
            // 
            // btnRefreshRate
            // 
            this.btnRefreshRate.Location = new System.Drawing.Point(209, 84);
            this.btnRefreshRate.Name = "btnRefreshRate";
            this.btnRefreshRate.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshRate.TabIndex = 18;
            this.btnRefreshRate.Text = "Apply";
            this.btnRefreshRate.UseVisualStyleBackColor = true;
            this.btnRefreshRate.Click += new System.EventHandler(this.btnRefreshRate_Click);
            // 
            // tmrCount
            // 
            this.tmrCount.Interval = 250;
            this.tmrCount.Tick += new System.EventHandler(this.tmrCount_Tick);
            // 
            // tmrScrollingLine1
            // 
            this.tmrScrollingLine1.Interval = 1000;
            this.tmrScrollingLine1.Tick += new System.EventHandler(this.tmrScrollingLine1_Tick);
            // 
            // tmrScrollingLine2
            // 
            this.tmrScrollingLine2.Interval = 1000;
            this.tmrScrollingLine2.Tick += new System.EventHandler(this.tmrScrollingLine2_Tick);
            // 
            // tmrFormRefreshRate
            // 
            this.tmrFormRefreshRate.Interval = 250;
            this.tmrFormRefreshRate.Tick += new System.EventHandler(this.tmrFormRefreshRate_Tick);
            // 
            // iMonWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 377);
            this.Controls.Add(this.btnRefreshRate);
            this.Controls.Add(this.txtRefreshRate);
            this.Controls.Add(this.lblRefreshRate);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.lblInterval);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInputLine2);
            this.Controls.Add(this.txtInputLine1);
            this.Controls.Add(this.lblDirectWrite);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.btnDeinitialise);
            this.Controls.Add(this.btnInitialise);
            this.Controls.Add(this.lblStateOutput);
            this.Name = "iMonWindow";
            this.Text = "iMon";
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
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Timer tmrVfdRefreshRate;
        private System.Windows.Forms.Label lblRefreshRate;
        private System.Windows.Forms.TextBox txtRefreshRate;
        private System.Windows.Forms.Button btnRefreshRate;
        private System.Windows.Forms.Timer tmrCount;
        private System.Windows.Forms.Timer tmrScrollingLine1;
        private System.Windows.Forms.Timer tmrScrollingLine2;
        private System.Windows.Forms.Timer tmrFormRefreshRate;
    }
}

