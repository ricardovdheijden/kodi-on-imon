namespace Kodi_on_iMon
{
    partial class iMonMenu
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
            this.lblLine2 = new System.Windows.Forms.Label();
            this.lblLine1 = new System.Windows.Forms.Label();
            this.tmrFormRefreshRate = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblLine2
            // 
            this.lblLine2.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLine2.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLine2.Location = new System.Drawing.Point(7, 131);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(270, 30);
            this.lblLine2.TabIndex = 8;
            // 
            // lblLine1
            // 
            this.lblLine1.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblLine1.Font = new System.Drawing.Font("Courier New", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblLine1.Location = new System.Drawing.Point(7, 101);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(270, 30);
            this.lblLine1.TabIndex = 7;
            // 
            // tmrFormRefreshRate
            // 
            this.tmrFormRefreshRate.Interval = 250;
            this.tmrFormRefreshRate.Tick += new System.EventHandler(this.tmrFormRefreshRate_Tick);
            // 
            // iMonMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.lblLine1);
            this.KeyPreview = true;
            this.Name = "iMonMenu";
            this.Text = "iMonMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLine2;
        private System.Windows.Forms.Label lblLine1;
        private System.Windows.Forms.Timer tmrFormRefreshRate;

    }
}