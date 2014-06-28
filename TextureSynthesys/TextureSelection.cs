using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureSynthesys
{
    class TextureSelection
    {
        TextureSynthesizer userInterface;

        Bitmap sourceImage;
        public Bitmap selectionImage;

        Pen selectionPen = new Pen(Color.Red, 1);
        Graphics selectionGraphics;

        public int pos_x = 0;
        public int pos_y = 0;

        public int size = 32;

        public TextureSelection(int width, int height, TextureSynthesizer sourceUI)
        {
            userInterface = sourceUI;
            selectionImage = new Bitmap(width, height);
            selectionGraphics = Graphics.FromImage(selectionImage);
            UpdateImage();
        }

        public void SetSourceImage(ref Bitmap img)
        {
            sourceImage = img;
            UpdateImage();
        }

        public void MovePosition(int offset_x, int offset_y)
        {
            pos_x += offset_x;
            pos_y += offset_y;
            UpdateImage();
        }

        public void ChangeSize(int newSize)
        {
            size = newSize;
            UpdateImage();
        }

        public void UpdateImage()
        {
            DrawSelection();
            userInterface.RedrawSelection();
        }

        void DrawSelection()
        {
            selectionGraphics.Clear(Color.Transparent);
            Console.WriteLine("drawing");
            if (userInterface.textureMode >= TextureSynthesizer.TEX_MODE_N0)
            {
                Point squareUpperLeft = new Point(pos_x, pos_y);
                Point squareLowerLeft = new Point(pos_x,  pos_y + size);
                Point squareUpperRight = new Point(pos_x + size, pos_y);
                Point squareLowerRight = new Point(pos_x + size, pos_y + size);

                selectionGraphics.DrawLine(selectionPen, squareUpperLeft, squareUpperRight);
                selectionGraphics.DrawLine(selectionPen, squareUpperRight, squareLowerRight);
                selectionGraphics.DrawLine(selectionPen, squareLowerRight, squareLowerLeft);
                selectionGraphics.DrawLine(selectionPen, squareLowerLeft, squareUpperLeft);
            }
            /*if (userInterface.textureMode >= TextureSynthesizer.TEX_MODE_N1)
            {
                Point imageCenter = new Point(selectionImage.Width / 2, selectionImage.Height / 2);
                Point squareUpperCenter = new Point((imageCenter.X + pos_x), (imageCenter.Y + pos_y + (size / 2)));
                Point squareLowerCenter = new Point((imageCenter.X + pos_x), (imageCenter.Y + pos_y - (size / 2)));
                Point squareLeftCenter = new Point((imageCenter.X + pos_x - (size / 2)), (imageCenter.Y + pos_y));
                Point squareRightCenter = new Point((imageCenter.X + pos_x + (size / 2)), (imageCenter.Y + pos_y));

                selectionGraphics.DrawLine(selectionPen, squareUpperCenter, squareLowerCenter);
                selectionGraphics.DrawLine(selectionPen, squareLeftCenter, squareRightCenter);
            }*/
        }

        public bool MouseIsInSelectionBounds(int mouse_x, int mouse_y)
        {
            if ((!MouseIsInsideSelection(mouse_x, mouse_y)) &&
                (mouse_x > pos_x) &&
                (mouse_x < pos_x + size) &&
                (mouse_y < pos_y + size) &&
                (mouse_y > pos_y))
            {
                return true;
            }
            else
                return false;
        }

        public bool MouseIsInsideSelection(int mouse_x, int mouse_y)
        {
            if ((mouse_x > pos_x - 2) &&
                (mouse_x < pos_x + size + 2) &&
                (mouse_y < pos_y + size + 2) &&
                (mouse_y > pos_y - 2))
            {
                return true;
            }
            else
                return false;
        }
    }
}
