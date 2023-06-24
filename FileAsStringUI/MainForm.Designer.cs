namespace FileAsStringUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSerialize = new System.Windows.Forms.TabPage();
            this.textBoxSerialize = new System.Windows.Forms.TextBox();
            this.labelSelectedFile = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.tabDeserialize = new System.Windows.Forms.TabPage();
            this.labelOutputFile = new System.Windows.Forms.Label();
            this.textBoxDeserialize = new System.Windows.Forms.TextBox();
            this.buttonDeserialize = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.textBoxSerialize.Location = new System.Drawing.Point(9, 35);
            this.textBoxSerialize.MaxLength = 999999999;
            this.textBoxSerialize.Multiline = true;
            this.textBoxSerialize.Name = "textBoxSerialize";
            this.textBoxSerialize.ReadOnly = true;
            this.textBoxSerialize.Size = new System.Drawing.Size(753, 359);
            this.textBoxSerialize.TabIndex = 2;
            this.textBoxSerialize.WordWrap = false;
            // 
            // labelSelectedFile
            // 
            this.labelSelectedFile.AutoSize = true;
            this.labelSelectedFile.Location = new System.Drawing.Point(87, 11);
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
            this.tabDeserialize.Controls.Add(this.labelOutputFile);
            this.tabDeserialize.Controls.Add(this.textBoxDeserialize);
            this.tabDeserialize.Controls.Add(this.buttonDeserialize);
            this.tabDeserialize.Location = new System.Drawing.Point(4, 22);
            this.tabDeserialize.Name = "tabDeserialize";
            this.tabDeserialize.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeserialize.Size = new System.Drawing.Size(768, 400);
            this.tabDeserialize.TabIndex = 1;
            this.tabDeserialize.Text = "Deserialize";
            this.tabDeserialize.UseVisualStyleBackColor = true;
            // 
            // labelOutputFile
            // 
            this.labelOutputFile.AutoSize = true;
            this.labelOutputFile.Location = new System.Drawing.Point(87, 11);
            this.labelOutputFile.Name = "labelOutputFile";
            this.labelOutputFile.Size = new System.Drawing.Size(70, 13);
            this.labelOutputFile.TabIndex = 4;
            this.labelOutputFile.Text = "No output file";
            // 
            // textBoxDeserialize
            // 
            this.textBoxDeserialize.Location = new System.Drawing.Point(9, 36);
            this.textBoxDeserialize.MaxLength = 999999999;
            this.textBoxDeserialize.Multiline = true;
            this.textBoxDeserialize.Name = "textBoxDeserialize";
            this.textBoxDeserialize.Size = new System.Drawing.Size(756, 358);
            this.textBoxDeserialize.TabIndex = 3;
            this.textBoxDeserialize.WordWrap = false;
            // 
            // buttonDeserialize
            // 
            this.buttonDeserialize.Location = new System.Drawing.Point(6, 6);
            this.buttonDeserialize.Name = "buttonDeserialize";
            this.buttonDeserialize.Size = new System.Drawing.Size(75, 23);
            this.buttonDeserialize.TabIndex = 2;
            this.buttonDeserialize.Text = "Deserialize";
            this.buttonDeserialize.UseVisualStyleBackColor = true;
            this.buttonDeserialize.Click += new System.EventHandler(this.buttonDeserialize_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 444);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(772, 23);
            this.progressBar.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "File As String";
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
        private System.Windows.Forms.Button buttonDeserialize;
        private System.Windows.Forms.TextBox textBoxDeserialize;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelOutputFile;
    }
}

