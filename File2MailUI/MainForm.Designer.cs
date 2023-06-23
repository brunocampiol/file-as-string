namespace File2MailUI
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSerialize = new System.Windows.Forms.TabPage();
            this.textBoxSerialize = new System.Windows.Forms.TextBox();
            this.labelSelectedFile = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.tabDeserialize = new System.Windows.Forms.TabPage();
            this.textBoxDeserialize = new System.Windows.Forms.TextBox();
            this.buttonDeserialize = new System.Windows.Forms.Button();
            this.labelDestinationFile = new System.Windows.Forms.Label();
            this.textBoxDestinationFileName = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabSerialize.SuspendLayout();
            this.tabDeserialize.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabSerialize);
            this.tabControl.Controls.Add(this.tabDeserialize);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 426);
            this.tabControl.TabIndex = 0;
            // 
            // tabSerialize
            // 
            this.tabSerialize.Controls.Add(this.textBoxSerialize);
            this.tabSerialize.Controls.Add(this.labelSelectedFile);
            this.tabSerialize.Controls.Add(this.buttonSelectFile);
            this.tabSerialize.Location = new System.Drawing.Point(4, 22);
            this.tabSerialize.Name = "tabSerialize";
            this.tabSerialize.Padding = new System.Windows.Forms.Padding(3);
            this.tabSerialize.Size = new System.Drawing.Size(768, 400);
            this.tabSerialize.TabIndex = 0;
            this.tabSerialize.Text = "Serialize";
            this.tabSerialize.UseVisualStyleBackColor = true;
            // 
            // textBoxSerialize
            // 
            this.textBoxSerialize.Location = new System.Drawing.Point(9, 59);
            this.textBoxSerialize.MaxLength = 9999999;
            this.textBoxSerialize.Multiline = true;
            this.textBoxSerialize.Name = "textBoxSerialize";
            this.textBoxSerialize.Size = new System.Drawing.Size(753, 335);
            this.textBoxSerialize.TabIndex = 2;
            // 
            // labelSelectedFile
            // 
            this.labelSelectedFile.AutoSize = true;
            this.labelSelectedFile.Location = new System.Drawing.Point(6, 32);
            this.labelSelectedFile.Name = "labelSelectedFile";
            this.labelSelectedFile.Size = new System.Drawing.Size(80, 13);
            this.labelSelectedFile.TabIndex = 1;
            this.labelSelectedFile.Text = "No selected file";
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(6, 6);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectFile.TabIndex = 0;
            this.buttonSelectFile.Text = "Select File";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // tabDeserialize
            // 
            this.tabDeserialize.Controls.Add(this.textBoxDeserialize);
            this.tabDeserialize.Controls.Add(this.buttonDeserialize);
            this.tabDeserialize.Controls.Add(this.labelDestinationFile);
            this.tabDeserialize.Controls.Add(this.textBoxDestinationFileName);
            this.tabDeserialize.Location = new System.Drawing.Point(4, 22);
            this.tabDeserialize.Name = "tabDeserialize";
            this.tabDeserialize.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeserialize.Size = new System.Drawing.Size(768, 400);
            this.tabDeserialize.TabIndex = 1;
            this.tabDeserialize.Text = "Deserialize";
            this.tabDeserialize.UseVisualStyleBackColor = true;
            // 
            // textBoxDeserialize
            // 
            this.textBoxDeserialize.Location = new System.Drawing.Point(9, 36);
            this.textBoxDeserialize.MaxLength = 9999999;
            this.textBoxDeserialize.Multiline = true;
            this.textBoxDeserialize.Name = "textBoxDeserialize";
            this.textBoxDeserialize.Size = new System.Drawing.Size(756, 358);
            this.textBoxDeserialize.TabIndex = 3;
            // 
            // buttonDeserialize
            // 
            this.buttonDeserialize.Location = new System.Drawing.Point(687, 7);
            this.buttonDeserialize.Name = "buttonDeserialize";
            this.buttonDeserialize.Size = new System.Drawing.Size(75, 23);
            this.buttonDeserialize.TabIndex = 2;
            this.buttonDeserialize.Text = "Deserialize";
            this.buttonDeserialize.UseVisualStyleBackColor = true;
            this.buttonDeserialize.Click += new System.EventHandler(this.buttonDeserialize_Click);
            // 
            // labelDestinationFile
            // 
            this.labelDestinationFile.AutoSize = true;
            this.labelDestinationFile.Location = new System.Drawing.Point(6, 12);
            this.labelDestinationFile.Name = "labelDestinationFile";
            this.labelDestinationFile.Size = new System.Drawing.Size(54, 13);
            this.labelDestinationFile.TabIndex = 1;
            this.labelDestinationFile.Text = "File Name";
            // 
            // textBoxDestinationFileName
            // 
            this.textBoxDestinationFileName.Location = new System.Drawing.Point(66, 9);
            this.textBoxDestinationFileName.MaxLength = 50;
            this.textBoxDestinationFileName.Name = "textBoxDestinationFileName";
            this.textBoxDestinationFileName.Size = new System.Drawing.Size(333, 20);
            this.textBoxDestinationFileName.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.tabSerialize.ResumeLayout(false);
            this.tabSerialize.PerformLayout();
            this.tabDeserialize.ResumeLayout(false);
            this.tabDeserialize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSerialize;
        private System.Windows.Forms.TabPage tabDeserialize;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Label labelSelectedFile;
        private System.Windows.Forms.TextBox textBoxSerialize;
        private System.Windows.Forms.Label labelDestinationFile;
        private System.Windows.Forms.TextBox textBoxDestinationFileName;
        private System.Windows.Forms.Button buttonDeserialize;
        private System.Windows.Forms.TextBox textBoxDeserialize;
    }
}

