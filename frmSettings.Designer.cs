namespace Wordle_SDD
{
    partial class frmSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHardModeWarning = new System.Windows.Forms.Label();
            this.lblChkDictWarning = new System.Windows.Forms.Label();
            this.chkHardMode = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkHighContrast = new System.Windows.Forms.CheckBox();
            this.chkCheckDictionary = new System.Windows.Forms.CheckBox();
            this.lblGraphicsTitle = new System.Windows.Forms.Label();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblHardModeWarning);
            this.panel1.Controls.Add(this.lblChkDictWarning);
            this.panel1.Controls.Add(this.chkHardMode);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.chkHighContrast);
            this.panel1.Controls.Add(this.chkCheckDictionary);
            this.panel1.Controls.Add(this.lblGraphicsTitle);
            this.panel1.Controls.Add(this.chkDarkMode);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 549);
            this.panel1.TabIndex = 0;
            // 
            // lblHardModeWarning
            // 
            this.lblHardModeWarning.AutoSize = true;
            this.lblHardModeWarning.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHardModeWarning.Location = new System.Drawing.Point(57, 226);
            this.lblHardModeWarning.Name = "lblHardModeWarning";
            this.lblHardModeWarning.Size = new System.Drawing.Size(198, 48);
            this.lblHardModeWarning.TabIndex = 7;
            this.lblHardModeWarning.Text = "*Removes the restrictions on the\r\n word pool, meaning the correct\r\n word can be e" +
    "xtremely obscure\r\n";
            // 
            // lblChkDictWarning
            // 
            this.lblChkDictWarning.AutoSize = true;
            this.lblChkDictWarning.ForeColor = System.Drawing.SystemColors.Control;
            this.lblChkDictWarning.Location = new System.Drawing.Point(57, 160);
            this.lblChkDictWarning.Name = "lblChkDictWarning";
            this.lblChkDictWarning.Size = new System.Drawing.Size(203, 32);
            this.lblChkDictWarning.TabIndex = 5;
            this.lblChkDictWarning.Text = "*Unchecking this will allow you to \r\nenter any possible 5 letter word.";
            // 
            // chkHardMode
            // 
            this.chkHardMode.AutoSize = true;
            this.chkHardMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHardMode.ForeColor = System.Drawing.SystemColors.Control;
            this.chkHardMode.Location = new System.Drawing.Point(33, 199);
            this.chkHardMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkHardMode.Name = "chkHardMode";
            this.chkHardMode.Size = new System.Drawing.Size(161, 32);
            this.chkHardMode.TabIndex = 6;
            this.chkHardMode.Text = "Hard Mode";
            this.chkHardMode.UseVisualStyleBackColor = true;
            this.chkHardMode.CheckedChanged += new System.EventHandler(this.chkHardMode_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::Wordle_SDD.Properties.Resources.imgCrossIconLight;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClose.Location = new System.Drawing.Point(296, 12);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkHighContrast
            // 
            this.chkHighContrast.AutoSize = true;
            this.chkHighContrast.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHighContrast.ForeColor = System.Drawing.SystemColors.Control;
            this.chkHighContrast.Location = new System.Drawing.Point(33, 95);
            this.chkHighContrast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkHighContrast.Name = "chkHighContrast";
            this.chkHighContrast.Size = new System.Drawing.Size(194, 32);
            this.chkHighContrast.TabIndex = 3;
            this.chkHighContrast.Text = "High Contrast";
            this.chkHighContrast.UseVisualStyleBackColor = true;
            this.chkHighContrast.CheckedChanged += new System.EventHandler(this.chkHighContrast_CheckedChanged);
            // 
            // chkCheckDictionary
            // 
            this.chkCheckDictionary.AutoSize = true;
            this.chkCheckDictionary.Checked = true;
            this.chkCheckDictionary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckDictionary.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckDictionary.ForeColor = System.Drawing.SystemColors.Control;
            this.chkCheckDictionary.Location = new System.Drawing.Point(33, 133);
            this.chkCheckDictionary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCheckDictionary.Name = "chkCheckDictionary";
            this.chkCheckDictionary.Size = new System.Drawing.Size(234, 32);
            this.chkCheckDictionary.TabIndex = 2;
            this.chkCheckDictionary.Text = "Check Dictionary";
            this.chkCheckDictionary.UseVisualStyleBackColor = true;
            this.chkCheckDictionary.CheckedChanged += new System.EventHandler(this.chkCheckDictionary_CheckedChanged);
            // 
            // lblGraphicsTitle
            // 
            this.lblGraphicsTitle.AutoSize = true;
            this.lblGraphicsTitle.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphicsTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblGraphicsTitle.Location = new System.Drawing.Point(12, 12);
            this.lblGraphicsTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGraphicsTitle.Name = "lblGraphicsTitle";
            this.lblGraphicsTitle.Size = new System.Drawing.Size(147, 38);
            this.lblGraphicsTitle.TabIndex = 1;
            this.lblGraphicsTitle.Text = "Settings:";
            // 
            // chkDarkMode
            // 
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.Checked = true;
            this.chkDarkMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDarkMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDarkMode.ForeColor = System.Drawing.SystemColors.Control;
            this.chkDarkMode.Location = new System.Drawing.Point(33, 58);
            this.chkDarkMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkDarkMode.Name = "chkDarkMode";
            this.chkDarkMode.Size = new System.Drawing.Size(160, 32);
            this.chkDarkMode.TabIndex = 0;
            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.UseVisualStyleBackColor = true;
            this.chkDarkMode.CheckedChanged += new System.EventHandler(this.chkDarkMode_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(352, 417);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(370, 464);
            this.MinimumSize = new System.Drawing.Size(370, 464);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGraphicsTitle;
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkHighContrast;
        private System.Windows.Forms.CheckBox chkCheckDictionary;
        private System.Windows.Forms.Label lblChkDictWarning;
        private System.Windows.Forms.CheckBox chkHardMode;
        private System.Windows.Forms.Label lblHardModeWarning;
    }
}