namespace ezDoomCrossPlatform
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.AddIWADButton = new System.Windows.Forms.Button();
            this.DeleteIWADButton = new System.Windows.Forms.Button();
            this.DeletePWADButton = new System.Windows.Forms.Button();
            this.AddPWADButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.IWADSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.PWADSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddIWADButton
            // 
            this.AddIWADButton.Location = new System.Drawing.Point(290, 320);
            this.AddIWADButton.Name = "AddIWADButton";
            this.AddIWADButton.Size = new System.Drawing.Size(52, 23);
            this.AddIWADButton.TabIndex = 2;
            this.AddIWADButton.Text = "Add";
            this.AddIWADButton.UseVisualStyleBackColor = true;
            // 
            // DeleteIWADButton
            // 
            this.DeleteIWADButton.Location = new System.Drawing.Point(370, 320);
            this.DeleteIWADButton.Name = "DeleteIWADButton";
            this.DeleteIWADButton.Size = new System.Drawing.Size(46, 23);
            this.DeleteIWADButton.TabIndex = 3;
            this.DeleteIWADButton.Text = "Delete";
            this.DeleteIWADButton.UseVisualStyleBackColor = true;
            // 
            // DeletePWADButton
            // 
            this.DeletePWADButton.Location = new System.Drawing.Point(370, 367);
            this.DeletePWADButton.Name = "DeletePWADButton";
            this.DeletePWADButton.Size = new System.Drawing.Size(46, 23);
            this.DeletePWADButton.TabIndex = 6;
            this.DeletePWADButton.Text = "Delete";
            this.DeletePWADButton.UseVisualStyleBackColor = true;
            // 
            // AddPWADButton
            // 
            this.AddPWADButton.Location = new System.Drawing.Point(290, 367);
            this.AddPWADButton.Name = "AddPWADButton";
            this.AddPWADButton.Size = new System.Drawing.Size(52, 23);
            this.AddPWADButton.TabIndex = 5;
            this.AddPWADButton.Text = "Add";
            this.AddPWADButton.UseVisualStyleBackColor = true;
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(192, 422);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 7;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // IWADSelectionComboBox
            // 
            this.IWADSelectionComboBox.FormattingEnabled = true;
            this.IWADSelectionComboBox.Location = new System.Drawing.Point(146, 320);
            this.IWADSelectionComboBox.Name = "IWADSelectionComboBox";
            this.IWADSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.IWADSelectionComboBox.TabIndex = 8;
            // 
            // PWADSelectionComboBox
            // 
            this.PWADSelectionComboBox.FormattingEnabled = true;
            this.PWADSelectionComboBox.Location = new System.Drawing.Point(146, 369);
            this.PWADSelectionComboBox.Name = "PWADSelectionComboBox";
            this.PWADSelectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.PWADSelectionComboBox.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(71, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 190);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select PWAD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Select IWAD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Welcome to ezDoom, the easy way to play Doom and many of its mods for free!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(371, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Please choose a game from the options below and click \"Play\" to get started.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 470);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mono version programmed by Edwin Jones and Jason Browne.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(376, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "All other trademarks and copyrights are the property of their respective owners.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 501);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Powered by ZDOOM ";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 523);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PWADSelectionComboBox);
            this.Controls.Add(this.IWADSelectionComboBox);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.DeletePWADButton);
            this.Controls.Add(this.AddPWADButton);
            this.Controls.Add(this.DeleteIWADButton);
            this.Controls.Add(this.AddIWADButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ezDoom - The easy way to play Doom!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddIWADButton;
        private System.Windows.Forms.Button DeleteIWADButton;
        private System.Windows.Forms.Button DeletePWADButton;
        private System.Windows.Forms.Button AddPWADButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.ComboBox IWADSelectionComboBox;
        private System.Windows.Forms.ComboBox PWADSelectionComboBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

    }
}

