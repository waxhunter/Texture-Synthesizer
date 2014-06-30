namespace TextureSynthesys
{
    partial class TextureSynthesizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureSynthesizer));
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.modeLabel = new System.Windows.Forms.Label();
            this.modeN1Button = new System.Windows.Forms.RadioButton();
            this.modeN2Button = new System.Windows.Forms.RadioButton();
            this.modeN3Button = new System.Windows.Forms.RadioButton();
            this.selectionPictureBox = new System.Windows.Forms.PictureBox();
            this.tileSizeBox = new System.Windows.Forms.ComboBox();
            this.tileSizeLabel = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.saveOutputDialog = new System.Windows.Forms.SaveFileDialog();
            this.linearThresholdStart = new System.Windows.Forms.NumericUpDown();
            this.linearThresholdEnd = new System.Windows.Forms.NumericUpDown();
            this.angularThresholdEnd = new System.Windows.Forms.NumericUpDown();
            this.colThreshold = new System.Windows.Forms.NumericUpDown();
            this.angularThresholdStart = new System.Windows.Forms.NumericUpDown();
            this.linTHSTLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearThresholdStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearThresholdEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angularThresholdEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angularThresholdStart)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sourcePictureBox.BackgroundImage")));
            this.sourcePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sourcePictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.sourcePictureBox.Location = new System.Drawing.Point(12, 53);
            this.sourcePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(1260, 756);
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openImageToolStripMenuItem.Text = "Open image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = "JPEG Image|*.jpg|All files|*.*";
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Enabled = false;
            this.modeLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeLabel.Location = new System.Drawing.Point(9, 28);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(45, 13);
            this.modeLabel.TabIndex = 2;
            this.modeLabel.Text = "Mode:";
            // 
            // modeN1Button
            // 
            this.modeN1Button.AutoSize = true;
            this.modeN1Button.Enabled = false;
            this.modeN1Button.Location = new System.Drawing.Point(56, 26);
            this.modeN1Button.Name = "modeN1Button";
            this.modeN1Button.Size = new System.Drawing.Size(56, 17);
            this.modeN1Button.TabIndex = 5;
            this.modeN1Button.TabStop = true;
            this.modeN1Button.Text = "n = 0";
            this.modeN1Button.UseVisualStyleBackColor = true;
            this.modeN1Button.CheckedChanged += new System.EventHandler(this.modeN1Button_CheckedChanged);
            // 
            // modeN2Button
            // 
            this.modeN2Button.AutoSize = true;
            this.modeN2Button.Enabled = false;
            this.modeN2Button.Location = new System.Drawing.Point(118, 26);
            this.modeN2Button.Name = "modeN2Button";
            this.modeN2Button.Size = new System.Drawing.Size(56, 17);
            this.modeN2Button.TabIndex = 6;
            this.modeN2Button.TabStop = true;
            this.modeN2Button.Text = "n = 1";
            this.modeN2Button.UseVisualStyleBackColor = true;
            this.modeN2Button.CheckedChanged += new System.EventHandler(this.modeN2Button_CheckedChanged);
            // 
            // modeN3Button
            // 
            this.modeN3Button.AutoSize = true;
            this.modeN3Button.Enabled = false;
            this.modeN3Button.Location = new System.Drawing.Point(180, 26);
            this.modeN3Button.Name = "modeN3Button";
            this.modeN3Button.Size = new System.Drawing.Size(56, 17);
            this.modeN3Button.TabIndex = 7;
            this.modeN3Button.TabStop = true;
            this.modeN3Button.Text = "n = 2";
            this.modeN3Button.UseVisualStyleBackColor = true;
            this.modeN3Button.CheckedChanged += new System.EventHandler(this.modeN3Button_CheckedChanged);
            // 
            // selectionPictureBox
            // 
            this.selectionPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.selectionPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.selectionPictureBox.ErrorImage = null;
            this.selectionPictureBox.InitialImage = null;
            this.selectionPictureBox.Location = new System.Drawing.Point(12, 53);
            this.selectionPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.selectionPictureBox.Name = "selectionPictureBox";
            this.selectionPictureBox.Size = new System.Drawing.Size(1260, 756);
            this.selectionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectionPictureBox.TabIndex = 8;
            this.selectionPictureBox.TabStop = false;
            this.selectionPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectionPictureBox_MouseDown);
            this.selectionPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.selectionPictureBox_MouseMove);
            this.selectionPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.selectionPictureBox_MouseUp);
            // 
            // tileSizeBox
            // 
            this.tileSizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tileSizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tileSizeBox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileSizeBox.FormattingEnabled = true;
            this.tileSizeBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tileSizeBox.Items.AddRange(new object[] {
            "16",
            "32",
            "64",
            "128",
            "256"});
            this.tileSizeBox.Location = new System.Drawing.Point(314, 25);
            this.tileSizeBox.Name = "tileSizeBox";
            this.tileSizeBox.Size = new System.Drawing.Size(48, 21);
            this.tileSizeBox.TabIndex = 9;
            this.tileSizeBox.SelectedIndexChanged += new System.EventHandler(this.tileSizeBox_SelectedIndexChanged);
            this.tileSizeBox.TextUpdate += new System.EventHandler(this.tileSizeBox_TextUpdate);
            // 
            // tileSizeLabel
            // 
            this.tileSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tileSizeLabel.AutoSize = true;
            this.tileSizeLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileSizeLabel.Location = new System.Drawing.Point(242, 28);
            this.tileSizeLabel.Name = "tileSizeLabel";
            this.tileSizeLabel.Size = new System.Drawing.Size(66, 13);
            this.tileSizeLabel.TabIndex = 10;
            this.tileSizeLabel.Text = "Tile Size:";
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.generateButton.Location = new System.Drawing.Point(1197, 23);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 11;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // linearThresholdStart
            // 
            this.linearThresholdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linearThresholdStart.Location = new System.Drawing.Point(496, 26);
            this.linearThresholdStart.Name = "linearThresholdStart";
            this.linearThresholdStart.Size = new System.Drawing.Size(46, 21);
            this.linearThresholdStart.TabIndex = 12;
            this.linearThresholdStart.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            // 
            // linearThresholdEnd
            // 
            this.linearThresholdEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linearThresholdEnd.Location = new System.Drawing.Point(671, 25);
            this.linearThresholdEnd.Name = "linearThresholdEnd";
            this.linearThresholdEnd.Size = new System.Drawing.Size(46, 21);
            this.linearThresholdEnd.TabIndex = 13;
            this.linearThresholdEnd.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // angularThresholdEnd
            // 
            this.angularThresholdEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angularThresholdEnd.Location = new System.Drawing.Point(1151, 25);
            this.angularThresholdEnd.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.angularThresholdEnd.Name = "angularThresholdEnd";
            this.angularThresholdEnd.Size = new System.Drawing.Size(37, 21);
            this.angularThresholdEnd.TabIndex = 14;
            this.angularThresholdEnd.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // colThreshold
            // 
            this.colThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colThreshold.Location = new System.Drawing.Point(812, 25);
            this.colThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colThreshold.Name = "colThreshold";
            this.colThreshold.Size = new System.Drawing.Size(43, 21);
            this.colThreshold.TabIndex = 15;
            this.colThreshold.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // angularThresholdStart
            // 
            this.angularThresholdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.angularThresholdStart.Location = new System.Drawing.Point(983, 26);
            this.angularThresholdStart.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.angularThresholdStart.Name = "angularThresholdStart";
            this.angularThresholdStart.Size = new System.Drawing.Size(40, 21);
            this.angularThresholdStart.TabIndex = 16;
            this.angularThresholdStart.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // linTHSTLabel
            // 
            this.linTHSTLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linTHSTLabel.AutoSize = true;
            this.linTHSTLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linTHSTLabel.Location = new System.Drawing.Point(373, 28);
            this.linTHSTLabel.Name = "linTHSTLabel";
            this.linTHSTLabel.Size = new System.Drawing.Size(117, 13);
            this.linTHSTLabel.TabIndex = 17;
            this.linTHSTLabel.Text = "Lin. Thrsh. % (a)";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(548, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Lin. Thrsh. % (b)";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(861, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ang. Thrsh. º (a)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1029, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Ang. Thrsh. º (b)";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(730, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Col. Thrsh.";
            // 
            // TextureSynthesizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1284, 821);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linTHSTLabel);
            this.Controls.Add(this.angularThresholdStart);
            this.Controls.Add(this.colThreshold);
            this.Controls.Add(this.angularThresholdEnd);
            this.Controls.Add(this.linearThresholdEnd);
            this.Controls.Add(this.linearThresholdStart);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.tileSizeLabel);
            this.Controls.Add(this.tileSizeBox);
            this.Controls.Add(this.selectionPictureBox);
            this.Controls.Add(this.modeN3Button);
            this.Controls.Add(this.modeN2Button);
            this.Controls.Add(this.modeN1Button);
            this.Controls.Add(this.modeLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.sourcePictureBox);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TextureSynthesizer";
            this.Text = "Texture Synthesizer";
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearThresholdStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearThresholdEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angularThresholdEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angularThresholdStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.RadioButton modeN1Button;
        private System.Windows.Forms.RadioButton modeN2Button;
        private System.Windows.Forms.RadioButton modeN3Button;
        private System.Windows.Forms.PictureBox selectionPictureBox;
        private System.Windows.Forms.ComboBox tileSizeBox;
        private System.Windows.Forms.Label tileSizeLabel;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.SaveFileDialog saveOutputDialog;
        private System.Windows.Forms.NumericUpDown linearThresholdStart;
        private System.Windows.Forms.NumericUpDown linearThresholdEnd;
        private System.Windows.Forms.NumericUpDown angularThresholdEnd;
        private System.Windows.Forms.NumericUpDown colThreshold;
        private System.Windows.Forms.NumericUpDown angularThresholdStart;
        private System.Windows.Forms.Label linTHSTLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

