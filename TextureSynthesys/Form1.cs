using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureSynthesys
{
    public partial class TextureSynthesizer : Form
    {
        const int MOUSE_MODE_IDLE = 0;
        const int MOUSE_MODE_DRAGGING = 1;
        const int MOUSE_MODE_RESIZING = 2;

        public const int TEX_NOMODE = 0;
        public const int TEX_MODE_N0 = 1;
        public const int TEX_MODE_N1 = 2;
        public const int TEX_MODE_N2 = 3;

        int mouseMode = MOUSE_MODE_IDLE;
        public int textureMode = TEX_NOMODE;

        int originalSize = 0;

        int lastMouse_x = 0;
        int lastMouse_y = 0;

        int originalMouse_x = 0;
        int originalMouse_y = 0;

        Bitmap sourceImage;
        TextureSelection selection;

        public TextureSynthesizer()
        {
            InitializeComponent();

            // Transforma o picture box frontal (onde é desenhado o quadrado da seleção)
            // em um filho do picture box de trás (onde é desenhada a imagem de entrada)
            // para poder torná-lo transparente.
            selectionPictureBox.Parent = sourcePictureBox;
            //selectionPictureBox.BackColor = Color.Transparent;
            selectionPictureBox.Location = new Point(0, 0);

            selection = new TextureSelection(selectionPictureBox.Width, selectionPictureBox.Height, this);
            selectionPictureBox.Image = selection.selectionImage;
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult chosenFile = openImageDialog.ShowDialog();
            if (chosenFile == DialogResult.Cancel || chosenFile == DialogResult.Abort)
            {

            }
            else
            {
                EnableControls();
                sourceImage = new Bitmap(openImageDialog.FileName);
                selection.SetSourceImage(ref sourceImage);
                sourcePictureBox.Image = sourceImage;
            }
        }

        private void EnableControls()
        {
            modeN1Button.Enabled = true;
            modeN2Button.Enabled = true;
            modeN3Button.Enabled = true;
            label1.Enabled = true;
        }

        private void modeN1Button_CheckedChanged(object sender, EventArgs e)
        {
            textureMode = TEX_MODE_N0;
            selection.UpdateImage();
        }

        private void modeN2Button_CheckedChanged(object sender, EventArgs e)
        {
            textureMode = TEX_MODE_N1;
            selection.UpdateImage();
        }

        private void modeN3Button_CheckedChanged(object sender, EventArgs e)
        {
            textureMode = TEX_MODE_N2;
            selection.UpdateImage();
            
        }

        public void RedrawSelection()
        {
            selectionPictureBox.Refresh();
        }

        private void selectionPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (textureMode != TEX_NOMODE)
            {
                if (mouseMode == MOUSE_MODE_IDLE)
                {
                    if (selection.MouseIsInsideSelection(e.X, e.Y))
                    {
                        mouseMode = MOUSE_MODE_DRAGGING;
                    }
                    else if (selection.MouseIsInSelectionBounds(e.X, e.Y))
                    {
                        mouseMode = MOUSE_MODE_RESIZING;
                        originalSize = selection.size;
                    }
                }

                originalMouse_x = e.X;
                originalMouse_y = e.Y;
            }
        }

        private void selectionPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (textureMode != TEX_NOMODE)
            {
                if (mouseMode != MOUSE_MODE_IDLE)
                {
                    mouseMode = MOUSE_MODE_IDLE;
                }
            }
        }

        private void selectionPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (textureMode != TEX_NOMODE)
            {
                if (mouseMode == MOUSE_MODE_IDLE)
                {
                    if (selection.MouseIsInsideSelection(e.X, e.Y))
                    {
                        sourcePictureBox.Cursor = Cursors.Hand;
                    }
                    else if (selection.MouseIsInSelectionBounds(e.X, e.Y))
                    {
                        sourcePictureBox.Cursor = Cursors.SizeNWSE;
                    }
                    else
                    {
                        sourcePictureBox.Cursor = Cursors.Default;
                    }
                }
                else if (mouseMode == MOUSE_MODE_DRAGGING)
                {
                    selection.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                }
                else if (mouseMode == MOUSE_MODE_RESIZING)
                {
                    int dist = (int)Math.Round(Math.Sqrt(Math.Pow(originalMouse_x - e.X, 2) + Math.Pow(originalMouse_y - e.Y, 2)));
                    selection.ChangeSize(originalSize + dist);
                }

                lastMouse_x = e.X;
                lastMouse_y = e.Y;
            }
        }
    }
}
