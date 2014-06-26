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
            this.TextureSelector = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.modeN1Button = new System.Windows.Forms.RadioButton();
            this.modeN2Button = new System.Windows.Forms.RadioButton();
            this.modeN3Button = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.TextureSelector)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextureSelector
            // 
            this.TextureSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextureSelector.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TextureSelector.BackgroundImage")));
            this.TextureSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextureSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextureSelector.Location = new System.Drawing.Point(12, 53);
            this.TextureSelector.Name = "TextureSelector";
            this.TextureSelector.Padding = new System.Windows.Forms.Padding(10);
            this.TextureSelector.Size = new System.Drawing.Size(774, 508);
            this.TextureSelector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.TextureSelector.TabIndex = 0;
            this.TextureSelector.TabStop = false;
            this.TextureSelector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextureSelector_MouseDown);
            this.TextureSelector.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextureSelector_MouseMove);
            this.TextureSelector.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextureSelector_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 24);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mode:";
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
            // TextureSynthesizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(798, 573);
            this.Controls.Add(this.modeN3Button);
            this.Controls.Add(this.modeN2Button);
            this.Controls.Add(this.modeN1Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TextureSelector);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TextureSynthesizer";
            this.Text = "Texture Synthesizer";
            ((System.ComponentModel.ISupportInitialize)(this.TextureSelector)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TextureSelector;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton modeN1Button;
        private System.Windows.Forms.RadioButton modeN2Button;
        private System.Windows.Forms.RadioButton modeN3Button;
    }
}

