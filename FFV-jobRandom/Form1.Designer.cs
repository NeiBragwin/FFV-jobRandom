namespace FFV_jobRandom
{
    partial class Form1
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
            this.patchROMbutton = new System.Windows.Forms.Button();
            this.pathROMtextBox = new System.Windows.Forms.TextBox();
            this.openROMbutton = new System.Windows.Forms.Button();
            this.labelCheckROM = new System.Windows.Forms.Label();
            this.PathToSRMtextBox = new System.Windows.Forms.TextBox();
            this.OpenSRMbutton = new System.Windows.Forms.Button();
            this.RestoreROMbutton = new System.Windows.Forms.Button();
            this.RestoreSRMbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // patchROMbutton
            // 
            this.patchROMbutton.Location = new System.Drawing.Point(316, 12);
            this.patchROMbutton.Name = "patchROMbutton";
            this.patchROMbutton.Size = new System.Drawing.Size(75, 23);
            this.patchROMbutton.TabIndex = 0;
            this.patchROMbutton.Text = "Patch ROM";
            this.patchROMbutton.UseVisualStyleBackColor = true;
            this.patchROMbutton.Click += new System.EventHandler(this.PatchROMbutton_Click);
            // 
            // pathROMtextBox
            // 
            this.pathROMtextBox.Location = new System.Drawing.Point(12, 12);
            this.pathROMtextBox.Name = "pathROMtextBox";
            this.pathROMtextBox.Size = new System.Drawing.Size(217, 20);
            this.pathROMtextBox.TabIndex = 1;
            // 
            // openROMbutton
            // 
            this.openROMbutton.Location = new System.Drawing.Point(235, 12);
            this.openROMbutton.Name = "openROMbutton";
            this.openROMbutton.Size = new System.Drawing.Size(75, 23);
            this.openROMbutton.TabIndex = 2;
            this.openROMbutton.Text = "Open ROM";
            this.openROMbutton.UseVisualStyleBackColor = true;
            this.openROMbutton.Click += new System.EventHandler(this.OpenROMbutton_Click);
            // 
            // labelCheckROM
            // 
            this.labelCheckROM.AutoSize = true;
            this.labelCheckROM.Location = new System.Drawing.Point(12, 35);
            this.labelCheckROM.Name = "labelCheckROM";
            this.labelCheckROM.Size = new System.Drawing.Size(0, 13);
            this.labelCheckROM.TabIndex = 3;
            // 
            // PathToSRMtextBox
            // 
            this.PathToSRMtextBox.Location = new System.Drawing.Point(12, 78);
            this.PathToSRMtextBox.Name = "PathToSRMtextBox";
            this.PathToSRMtextBox.Size = new System.Drawing.Size(217, 20);
            this.PathToSRMtextBox.TabIndex = 4;
            // 
            // OpenSRMbutton
            // 
            this.OpenSRMbutton.Location = new System.Drawing.Point(235, 78);
            this.OpenSRMbutton.Name = "OpenSRMbutton";
            this.OpenSRMbutton.Size = new System.Drawing.Size(75, 23);
            this.OpenSRMbutton.TabIndex = 5;
            this.OpenSRMbutton.Text = "Open SRM";
            this.OpenSRMbutton.UseVisualStyleBackColor = true;
            // 
            // RestoreROMbutton
            // 
            this.RestoreROMbutton.Location = new System.Drawing.Point(235, 41);
            this.RestoreROMbutton.Name = "RestoreROMbutton";
            this.RestoreROMbutton.Size = new System.Drawing.Size(156, 23);
            this.RestoreROMbutton.TabIndex = 6;
            this.RestoreROMbutton.Text = "Restore ROM";
            this.RestoreROMbutton.UseVisualStyleBackColor = true;
            this.RestoreROMbutton.Click += new System.EventHandler(this.RestoreROMbutton_Click);
            // 
            // RestoreSRMbutton
            // 
            this.RestoreSRMbutton.Location = new System.Drawing.Point(316, 78);
            this.RestoreSRMbutton.Name = "RestoreSRMbutton";
            this.RestoreSRMbutton.Size = new System.Drawing.Size(75, 23);
            this.RestoreSRMbutton.TabIndex = 7;
            this.RestoreSRMbutton.Text = "Restore SRM";
            this.RestoreSRMbutton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 138);
            this.Controls.Add(this.RestoreSRMbutton);
            this.Controls.Add(this.RestoreROMbutton);
            this.Controls.Add(this.OpenSRMbutton);
            this.Controls.Add(this.PathToSRMtextBox);
            this.Controls.Add(this.labelCheckROM);
            this.Controls.Add(this.openROMbutton);
            this.Controls.Add(this.pathROMtextBox);
            this.Controls.Add(this.patchROMbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FFV Job Randomizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button patchROMbutton;
        private System.Windows.Forms.TextBox pathROMtextBox;
        private System.Windows.Forms.Button openROMbutton;
        private System.Windows.Forms.Label labelCheckROM;
        private System.Windows.Forms.TextBox PathToSRMtextBox;
        private System.Windows.Forms.Button OpenSRMbutton;
        private System.Windows.Forms.Button RestoreROMbutton;
        private System.Windows.Forms.Button RestoreSRMbutton;
    }
}

