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
        TextureSelection selection = new TextureSelection();

        public TextureSynthesizer()
        {
            InitializeComponent();
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
                selection = new TextureSelection();
                selection.SetSourceUI(this);
                selection.SetSourceImage(ref sourceImage);
                UpdateImage();
            }
        }

        public void UpdateImage()
        {
            TextureSelector.Image = selection.displayedImage;
        }

        private void TextureSelector_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseMode == MOUSE_MODE_IDLE)
            {
                if (MouseIsInsideSelection(e.X, e.Y))
                {
                    mouseMode = MOUSE_MODE_DRAGGING;
                }
                else if (MouseIsInSelectionBounds(e.X, e.Y))
                {
                    mouseMode = MOUSE_MODE_RESIZING;
                    originalSize = selection.size;
                }
            }

            originalMouse_x = e.X;
            originalMouse_y = e.Y;
        }

        public bool MouseIsInSelectionBounds(int mouse_x, int mouse_y)
        {
            int selectorCenter_x = TextureSelector.Width / 2;
            int selectorCenter_y = TextureSelector.Height / 2;

            if ((!MouseIsInsideSelection(mouse_x, mouse_y)) &&
                (mouse_x > (selectorCenter_x + selection.center_x - (selection.size / 2 + 2))) &&
                (mouse_x < (selectorCenter_x + selection.center_x + (selection.size / 2 + 2))) &&
                (mouse_y < (selectorCenter_y + selection.center_y + (selection.size / 2 + 2))) &&
                (mouse_y > (selectorCenter_y + selection.center_y - (selection.size / 2 + 2))))
            {
                return true;
            }
            else
                return false;
        }

        public bool MouseIsInsideSelection(int mouse_x, int mouse_y)
        {
            int selectorCenter_x = TextureSelector.Width / 2;
            int selectorCenter_y = TextureSelector.Height / 2;

            if ((mouse_x > (selectorCenter_x + selection.center_x - (selection.size / 2 - 1))) &&
                (mouse_x < (selectorCenter_x + selection.center_x + (selection.size / 2 - 1))) &&
                (mouse_y < (selectorCenter_y + selection.center_y + (selection.size / 2 - 1))) &&
                (mouse_y > (selectorCenter_y + selection.center_y - (selection.size / 2 - 1))))
            {
                return true;
            }
            else
                return false;
        }

        private void TextureSelector_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseMode != MOUSE_MODE_IDLE)
            {
                mouseMode = MOUSE_MODE_IDLE;
            }
        }

        private void TextureSelector_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseMode == MOUSE_MODE_IDLE)
            {
                if (MouseIsInsideSelection(e.X, e.Y))
                {
                    TextureSelector.Cursor = Cursors.Hand;
                }
                else if (MouseIsInSelectionBounds(e.X, e.Y))
                {
                    TextureSelector.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    TextureSelector.Cursor = Cursors.Default;
                }
            }
            else if (mouseMode == MOUSE_MODE_DRAGGING)
            {
                selection.MoveCenter(e.X - lastMouse_x, e.Y - lastMouse_y);
            }
            else if (mouseMode == MOUSE_MODE_RESIZING)
            {
                int dist = (int)Math.Round(Math.Sqrt(Math.Pow(originalMouse_x - e.X, 2) + Math.Pow(originalMouse_y - e.Y, 2)));
                selection.ChangeSize(originalSize + dist);
            }

            lastMouse_x = e.X;
            lastMouse_y = e.Y;
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
    }
}
