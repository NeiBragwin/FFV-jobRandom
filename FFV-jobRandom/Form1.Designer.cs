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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelCheckROM = new System.Windows.Forms.Label();
            this.PathToSRMtextBox = new System.Windows.Forms.TextBox();
            this.OpenSRMbutton = new System.Windows.Forms.Button();
            this.RestoreSRMbutton = new System.Windows.Forms.Button();
            this.RandomizeButton = new System.Windows.Forms.Button();
            this.SaveSRMbutton = new System.Windows.Forms.Button();
            this.SaveMessage = new System.Windows.Forms.Label();
            this.CharacterFourthBox = new System.Windows.Forms.PictureBox();
            this.CharacterThirdBox = new System.Windows.Forms.PictureBox();
            this.CharacterSecondBox = new System.Windows.Forms.PictureBox();
            this.CharacterFirstBox = new System.Windows.Forms.PictureBox();
            this.SaveFileList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterFourthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterThirdBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterSecondBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterFirstBox)).BeginInit();
            this.SuspendLayout();
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
            this.PathToSRMtextBox.Location = new System.Drawing.Point(12, 12);
            this.PathToSRMtextBox.Name = "PathToSRMtextBox";
            this.PathToSRMtextBox.Size = new System.Drawing.Size(217, 20);
            this.PathToSRMtextBox.TabIndex = 4;
            // 
            // OpenSRMbutton
            // 
            this.OpenSRMbutton.Location = new System.Drawing.Point(235, 12);
            this.OpenSRMbutton.Name = "OpenSRMbutton";
            this.OpenSRMbutton.Size = new System.Drawing.Size(75, 23);
            this.OpenSRMbutton.TabIndex = 5;
            this.OpenSRMbutton.Text = "Open SRM";
            this.OpenSRMbutton.UseVisualStyleBackColor = true;
            this.OpenSRMbutton.Click += new System.EventHandler(this.OpenSRMbutton_Click);
            // 
            // RestoreSRMbutton
            // 
            this.RestoreSRMbutton.Enabled = false;
            this.RestoreSRMbutton.Location = new System.Drawing.Point(316, 12);
            this.RestoreSRMbutton.Name = "RestoreSRMbutton";
            this.RestoreSRMbutton.Size = new System.Drawing.Size(75, 23);
            this.RestoreSRMbutton.TabIndex = 7;
            this.RestoreSRMbutton.Text = "Restore SRM";
            this.RestoreSRMbutton.UseVisualStyleBackColor = true;
            this.RestoreSRMbutton.Click += new System.EventHandler(this.RestoreSRMbutton_Click);
            // 
            // RandomizeButton
            // 
            this.RandomizeButton.Location = new System.Drawing.Point(112, 187);
            this.RandomizeButton.Name = "RandomizeButton";
            this.RandomizeButton.Size = new System.Drawing.Size(80, 23);
            this.RandomizeButton.TabIndex = 9;
            this.RandomizeButton.Text = "Randomize";
            this.RandomizeButton.UseVisualStyleBackColor = true;
            this.RandomizeButton.Click += new System.EventHandler(this.RandomizeButton_Click);
            // 
            // SaveSRMbutton
            // 
            this.SaveSRMbutton.Location = new System.Drawing.Point(210, 187);
            this.SaveSRMbutton.Name = "SaveSRMbutton";
            this.SaveSRMbutton.Size = new System.Drawing.Size(80, 23);
            this.SaveSRMbutton.TabIndex = 10;
            this.SaveSRMbutton.Text = "Save";
            this.SaveSRMbutton.UseVisualStyleBackColor = true;
            this.SaveSRMbutton.Click += new System.EventHandler(this.SaveSRMbutton_Click);
            // 
            // SaveMessage
            // 
            this.SaveMessage.AutoSize = true;
            this.SaveMessage.Location = new System.Drawing.Point(328, 191);
            this.SaveMessage.Name = "SaveMessage";
            this.SaveMessage.Size = new System.Drawing.Size(0, 13);
            this.SaveMessage.TabIndex = 11;
            this.SaveMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CharacterFourthBox
            // 
            this.CharacterFourthBox.Location = new System.Drawing.Point(307, 53);
            this.CharacterFourthBox.Name = "CharacterFourthBox";
            this.CharacterFourthBox.Size = new System.Drawing.Size(80, 120);
            this.CharacterFourthBox.TabIndex = 8;
            this.CharacterFourthBox.TabStop = false;
            // 
            // CharacterThirdBox
            // 
            this.CharacterThirdBox.Location = new System.Drawing.Point(210, 53);
            this.CharacterThirdBox.Name = "CharacterThirdBox";
            this.CharacterThirdBox.Size = new System.Drawing.Size(80, 120);
            this.CharacterThirdBox.TabIndex = 8;
            this.CharacterThirdBox.TabStop = false;
            // 
            // CharacterSecondBox
            // 
            this.CharacterSecondBox.Location = new System.Drawing.Point(112, 53);
            this.CharacterSecondBox.Name = "CharacterSecondBox";
            this.CharacterSecondBox.Size = new System.Drawing.Size(80, 120);
            this.CharacterSecondBox.TabIndex = 8;
            this.CharacterSecondBox.TabStop = false;
            // 
            // CharacterFirstBox
            // 
            this.CharacterFirstBox.Location = new System.Drawing.Point(15, 53);
            this.CharacterFirstBox.Name = "CharacterFirstBox";
            this.CharacterFirstBox.Size = new System.Drawing.Size(80, 120);
            this.CharacterFirstBox.TabIndex = 8;
            this.CharacterFirstBox.TabStop = false;
            // 
            // SaveFileList
            // 
            this.SaveFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SaveFileList.Enabled = false;
            this.SaveFileList.FormattingEnabled = true;
            this.SaveFileList.Items.AddRange(new object[] {
            "Save 1",
            "Save 2",
            "Save 3",
            "Save 4"});
            this.SaveFileList.Location = new System.Drawing.Point(15, 188);
            this.SaveFileList.Name = "SaveFileList";
            this.SaveFileList.Size = new System.Drawing.Size(80, 21);
            this.SaveFileList.TabIndex = 13;
            this.SaveFileList.SelectedIndexChanged += new System.EventHandler(this.SaveFileList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 219);
            this.Controls.Add(this.SaveFileList);
            this.Controls.Add(this.SaveMessage);
            this.Controls.Add(this.SaveSRMbutton);
            this.Controls.Add(this.RandomizeButton);
            this.Controls.Add(this.CharacterFourthBox);
            this.Controls.Add(this.CharacterThirdBox);
            this.Controls.Add(this.CharacterSecondBox);
            this.Controls.Add(this.CharacterFirstBox);
            this.Controls.Add(this.RestoreSRMbutton);
            this.Controls.Add(this.OpenSRMbutton);
            this.Controls.Add(this.PathToSRMtextBox);
            this.Controls.Add(this.labelCheckROM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FFV Job Randomizer";
            ((System.ComponentModel.ISupportInitialize)(this.CharacterFourthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterThirdBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterSecondBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterFirstBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCheckROM;
        private System.Windows.Forms.TextBox PathToSRMtextBox;
        private System.Windows.Forms.Button OpenSRMbutton;
        private System.Windows.Forms.Button RestoreSRMbutton;
        private System.Windows.Forms.PictureBox CharacterFirstBox;
        private System.Windows.Forms.PictureBox CharacterSecondBox;
        private System.Windows.Forms.PictureBox CharacterThirdBox;
        private System.Windows.Forms.PictureBox CharacterFourthBox;
        private System.Windows.Forms.Button RandomizeButton;
        private System.Windows.Forms.Button SaveSRMbutton;
        private System.Windows.Forms.Label SaveMessage;
        private System.Windows.Forms.ComboBox SaveFileList;
    }
}

