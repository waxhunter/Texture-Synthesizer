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
        public enum mouseModes
        {
            IDLE,
            DRAGGING_RED,
            DRAGGING_BLUE,
            RESIZING_BLUE
        }

        public enum textureModes
        {
            DEFAULT,
            MODE_N0,
            MODE_N1,
            MODE_N2
        }

        mouseModes mouseMode = mouseModes.IDLE;
        public textureModes textureMode = textureModes.DEFAULT;

        public int tileSize = 16;

        int originalSize = 0;

        int lastMouse_x = 0;
        int lastMouse_y = 0;

        int originalMouse_x = 0;
        int originalMouse_y = 0;

        Bitmap sourceImage;
        TextureSelection redOverlayTopLeft;
        TextureSelection redOverlayBottomLeft;
        TextureSelection redOverlayTopRight;
        TextureSelection blueOverlay;

        public Bitmap selectionImage;
        public Graphics selectionGraphics;

        public TextureSynthesizer()
        {
            InitializeComponent();

            // Transforma o picture box frontal (onde é desenhado o quadrado da seleção)
            // em um filho do picture box de trás (onde é desenhada a imagem de entrada)
            // para poder torná-lo transparente.
            selectionPictureBox.Parent = sourcePictureBox;
            //selectionPictureBox.BackColor = Color.Transparent;
            selectionPictureBox.Location = new Point(0, 0);

            selectionImage = new Bitmap(selectionPictureBox.Width, selectionPictureBox.Height);
            selectionGraphics = Graphics.FromImage(selectionImage);

            RecreateSelection();
        }

        void RecreateSelection()
        {
            selectionGraphics.Clear(Color.Transparent);

            redOverlayTopLeft = new TextureSelection(this, Color.Red);
            redOverlayBottomLeft = new TextureSelection(this, Color.Red);
            redOverlayTopRight = new TextureSelection(this, Color.Red);
            blueOverlay = new TextureSelection(this, Color.Blue);
            selectionPictureBox.Image = selectionImage;

            tileSizeBox.Text = "16";
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
                blueOverlay.ChangeSize(sourceImage.Width, sourceImage.Height);
                sourcePictureBox.Image = sourceImage;
            }
        }

        private void EnableControls()
        {
            modeN1Button.Enabled = true;
            modeN2Button.Enabled = true;
            modeN3Button.Enabled = true;
            modeLabel.Enabled = true;
        }

        private void modeN1Button_CheckedChanged(object sender, EventArgs e)
        {
            textureMode = textureModes.MODE_N0;
            redOverlayTopLeft.UpdateImage();
        }

        private void modeN2Button_CheckedChanged(object sender, EventArgs e)
        {
            textureMode = textureModes.MODE_N1;
            redOverlayTopLeft.UpdateImage();

            RemakeSelections();

            redOverlayBottomLeft.UpdateImage();
        }

        private void modeN3Button_CheckedChanged(object sender, EventArgs e)
        {
            textureMode = textureModes.MODE_N2;
            redOverlayTopLeft.UpdateImage();

            RemakeSelections();
            
            redOverlayBottomLeft.UpdateImage();
            redOverlayTopRight.UpdateImage();
            
        }

        void RedrawSelections()
        {
            if (textureMode == textureModes.MODE_N0)
            {
                redOverlayTopLeft.UpdateImage();
            }
            else if (textureMode == textureModes.MODE_N1)
            {
                redOverlayTopLeft.UpdateImage();
                redOverlayBottomLeft.UpdateImage();
            }
            else if (textureMode == textureModes.MODE_N2)
            {
                redOverlayTopLeft.UpdateImage();
                redOverlayBottomLeft.UpdateImage();
                redOverlayTopRight.UpdateImage();
            }
        }

        void RemakeSelections()
        {
            redOverlayBottomLeft.size_x = redOverlayTopLeft.size_x;
            redOverlayBottomLeft.size_y = redOverlayTopLeft.size_y;
            redOverlayBottomLeft.pos_x = redOverlayTopLeft.pos_x;
            redOverlayBottomLeft.pos_y = redOverlayTopLeft.pos_y + redOverlayTopLeft.size_y;

            redOverlayTopRight.size_x = redOverlayTopLeft.size_x;
            redOverlayTopRight.size_y = redOverlayTopLeft.size_y;
            redOverlayTopRight.pos_x = redOverlayTopLeft.pos_x + redOverlayTopLeft.size_x;
            redOverlayTopRight.pos_y = redOverlayTopLeft.pos_y;
        }

        public void RedrawSelection()
        {
            selectionGraphics.Clear(Color.Transparent);
            blueOverlay.DrawSelection();
            redOverlayTopLeft.DrawSelection();
            if (textureMode >= textureModes.MODE_N1)
            {
                redOverlayBottomLeft.DrawSelection();
                if (textureMode == textureModes.MODE_N2)
                {
                    redOverlayTopRight.DrawSelection();
                }
            }
            selectionPictureBox.Refresh();
        }

        private void selectionPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (textureMode != textureModes.DEFAULT)
            {
                if (mouseMode == mouseModes.IDLE)
                {
                    if (redOverlayTopLeft.MouseIsInsideSelection(e.X, e.Y) || redOverlayBottomLeft.MouseIsInsideSelection(e.X, e.Y) || redOverlayTopRight.MouseIsInsideSelection(e.X, e.Y))
                    {
                        mouseMode = mouseModes.DRAGGING_RED;
                    }
                    else if (blueOverlay.MouseIsInsideSelection(e.X, e.Y))
                    {
                        mouseMode = mouseModes.DRAGGING_BLUE;
                    }
                    else if (blueOverlay.MouseIsInSelectionBounds(e.X, e.Y))
                    {
                        mouseMode = mouseModes.RESIZING_BLUE;
                    }
                }

                originalMouse_x = e.X;
                originalMouse_y = e.Y;
            }
        }

        private void selectionPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (textureMode != textureModes.DEFAULT)
            {
                if (mouseMode != mouseModes.IDLE)
                {
                    mouseMode = mouseModes.IDLE;
                }
            }
        }

        private void selectionPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (textureMode != textureModes.DEFAULT)
            {
                if (mouseMode == mouseModes.IDLE)
                {
                    if (redOverlayTopLeft.MouseIsInsideSelection(e.X, e.Y) || blueOverlay.MouseIsInsideSelection(e.X, e.Y))
                    {
                        sourcePictureBox.Cursor = Cursors.Hand;
                    }
                    else if(blueOverlay.MouseIsInSelectionBounds(e.X, e.Y))
                    {
                        sourcePictureBox.Cursor = Cursors.SizeAll;
                    }
                    else
                    {
                        sourcePictureBox.Cursor = Cursors.Default;
                    }
                }
                else if (mouseMode == mouseModes.DRAGGING_RED)
                {
                    if (textureMode == textureModes.MODE_N0)
                    {
                        if ((redOverlayTopLeft.pos_x + e.X - lastMouse_x > 0) &&
                            (redOverlayTopLeft.pos_x + redOverlayTopLeft.size_x + e.X - lastMouse_x < sourceImage.Width) &&
                            (redOverlayTopLeft.pos_y + e.Y - lastMouse_y > 0) &&
                            (redOverlayTopLeft.pos_y + redOverlayTopLeft.size_y + e.Y - lastMouse_y < sourceImage.Height))
                        {
                            redOverlayTopLeft.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                        }
                    }
                    else if (textureMode == textureModes.MODE_N1)
                    {
                        if ((redOverlayTopLeft.pos_x + e.X - lastMouse_x > 0) &&
                            (redOverlayTopLeft.pos_x + redOverlayTopLeft.size_x + e.X - lastMouse_x < sourceImage.Width) &&
                            (redOverlayTopLeft.pos_y + e.Y - lastMouse_y > 0) &&
                            (redOverlayTopLeft.pos_y + redOverlayTopLeft.size_y + redOverlayBottomLeft.size_y + e.Y - lastMouse_y < sourceImage.Height))
                        {
                            redOverlayTopLeft.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                            redOverlayBottomLeft.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                        }
                    }
                    else if (textureMode == textureModes.MODE_N2)
                    {
                        if ((redOverlayTopLeft.pos_x + e.X - lastMouse_x > 0) &&
                            (redOverlayTopLeft.pos_x + redOverlayTopLeft.size_x + redOverlayTopRight.size_x + e.X - lastMouse_x < sourceImage.Width) &&
                            (redOverlayTopLeft.pos_y + e.Y - lastMouse_y > 0) &&
                            (redOverlayTopLeft.pos_y + redOverlayTopLeft.size_y + redOverlayBottomLeft.size_y + e.Y - lastMouse_y < sourceImage.Height))
                        {
                            redOverlayTopLeft.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                            redOverlayTopRight.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                            redOverlayBottomLeft.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                        }
                    }
                }
                else if (mouseMode == mouseModes.DRAGGING_BLUE)
                {
                    if ((blueOverlay.pos_x + e.X - lastMouse_x > 0) &&
                        (blueOverlay.pos_x + blueOverlay.size_x + e.X - lastMouse_x < sourceImage.Width) &&
                        (blueOverlay.pos_y + e.Y - lastMouse_y > 0) &&
                        (blueOverlay.pos_y + blueOverlay.size_y + e.Y - lastMouse_y < sourceImage.Height))
                    {
                        blueOverlay.MovePosition(e.X - lastMouse_x, e.Y - lastMouse_y);
                    }
                }
                else if (mouseMode == mouseModes.RESIZING_BLUE)
                {
                    blueOverlay.ChangeSize(Math.Abs(blueOverlay.pos_x - e.X), Math.Abs(blueOverlay.pos_y - e.Y));
                }

                lastMouse_x = e.X;
                lastMouse_y = e.Y;
            }
        }

        private void tileSizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tileSize = Convert.ToInt32(tileSizeBox.Text);
            if (textureMode != textureModes.DEFAULT)
            {
                redOverlayTopLeft.ChangeSize(tileSize, tileSize);
                RemakeSelections();
                RedrawSelections();
            }
        }

        private void tileSizeBox_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textureMode >= textureModes.MODE_N0)
            {
                Bitmap backgroundClip = new Bitmap(blueOverlay.size_x, blueOverlay.size_y);
                for (int i = 0; i < blueOverlay.size_x; i++)
                {
                    for (int j = 0; j < blueOverlay.size_y; j++)
                    {
                        Color pixel = sourceImage.GetPixel(i + blueOverlay.pos_x, j + blueOverlay.pos_y);
                        backgroundClip.SetPixel(i, j, pixel);
                    }
                }

                if (textureMode == textureModes.MODE_N0)
                {
                    Bitmap n0Clip = new Bitmap(tileSize, tileSize);

                    for (int i = 0; i < redOverlayTopLeft.size_x; i++)
                    {
                        for (int j = 0; j < redOverlayTopLeft.size_y; j++)
                        {
                            Color pixel = sourceImage.GetPixel(i + redOverlayTopLeft.pos_x, j + redOverlayTopLeft.pos_y);
                            n0Clip.SetPixel(i, j, pixel);
                        }
                    }

                    Bitmap boundaryTile = TileCreator.createBoundaryTileN0(tileSize, n0Clip);

                    Bitmap outputTexture = new Bitmap(4 * tileSize, 4 * tileSize);

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Bitmap outputTile = TileCreator.createRandomTile(tileSize, backgroundClip);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_BOTTOM, tileSize, boundaryTile, outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_RIGHT, tileSize, boundaryTile, outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_TOP, tileSize, boundaryTile, outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_LEFT, tileSize, boundaryTile, outputTile, 0.2f, 0.4f, 32);

                            for (int x = 0; x < outputTile.Width; x++)
                            {
                                for (int y = 0; y < outputTile.Height; y++)
                                {
                                    Color pixel = outputTile.GetPixel(x, y);
                                    outputTexture.SetPixel(tileSize * i + x, tileSize * j + y, pixel);
                                }
                            }
                        }
                    }

                    sourcePictureBox.Image = outputTexture;

                }
                if (textureMode == textureModes.MODE_N1)
                {
                    Bitmap n1Clip = new Bitmap(tileSize * 2, tileSize * 2);

                    for (int i = 0; i < redOverlayTopLeft.size_x * 2; i++)
                    {
                        for (int j = 0; j < redOverlayTopLeft.size_y * 2; j++)
                        {
                            Color pixel = sourceImage.GetPixel(i + redOverlayTopLeft.pos_x, j + redOverlayTopLeft.pos_y);
                            n1Clip.SetPixel(i, j, pixel);
                        }
                    }

                    Bitmap[,,] boundaryTiles = TileCreator.createBoundaryTileN1(tileSize * 2, n1Clip);

                    Bitmap outputTexture = new Bitmap(4 * tileSize, 4 * tileSize);

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            Bitmap outputTile = TileCreator.createRandomTile(tileSize, backgroundClip);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_BOTTOM, tileSize, boundaryTiles[i,j,0], outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_RIGHT, tileSize, boundaryTiles[i,j,1], outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_TOP, tileSize, boundaryTiles[i,j,2], outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_LEFT, tileSize, boundaryTiles[i,j,3], outputTile, 0.2f, 0.4f, 32);

                            for (int x = 0; x < outputTile.Width; x++)
                            {
                                for (int y = 0; y < outputTile.Height; y++)
                                {
                                    Color pixel = outputTile.GetPixel(x, y);
                                    outputTexture.SetPixel(tileSize * i + x, tileSize * j + y, pixel);
                                }
                            }
                        }
                    }

                    sourcePictureBox.Image = outputTexture;
                }
                if (textureMode == textureModes.MODE_N2)
                {
                    Bitmap n2Clip = new Bitmap(tileSize * 2, tileSize * 2);

                    for (int i = 0; i < redOverlayTopLeft.size_x * 2; i++)
                    {
                        for (int j = 0; j < redOverlayTopLeft.size_y * 2; j++)
                        {
                            Color pixel = sourceImage.GetPixel(i + redOverlayTopLeft.pos_x, j + redOverlayTopLeft.pos_y);
                            n2Clip.SetPixel(i, j, pixel);
                        }
                    }

                    Bitmap[, ,] boundaryTiles = TileCreator.createBoundaryTileN2(tileSize * 2, n2Clip);

                    Bitmap outputTexture = new Bitmap(16 * tileSize, 16 * tileSize);

                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            Bitmap outputTile = TileCreator.createRandomTile(tileSize, backgroundClip);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_BOTTOM, tileSize, boundaryTiles[i, j, 0], outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_RIGHT, tileSize, boundaryTiles[i, j, 1], outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_TOP, tileSize, boundaryTiles[i, j, 2], outputTile, 0.2f, 0.4f, 32);
                            outputTile = TileCreator.interiorBlend(TileCreator.edges.EDGE_LEFT, tileSize, boundaryTiles[i, j, 3], outputTile, 0.2f, 0.4f, 32);

                            for (int x = 0; x < outputTile.Width; x++)
                            {
                                for (int y = 0; y < outputTile.Height; y++)
                                {
                                    Color pixel = outputTile.GetPixel(x, y);
                                    outputTexture.SetPixel(tileSize * i + x, tileSize * j + y, pixel);
                                }
                            }
                        }
                    }

                    sourcePictureBox.Image = outputTexture;
                }
            }
        }
    }
}
